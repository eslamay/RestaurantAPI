using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Common;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
	internal class RestaurantsRepository(RestaurantsDbContext dbcontext) : IRestaurantsRepository
	{
		public async Task<IEnumerable<Restaurant>> GetAllAsync()
		{
			var restaurants = await dbcontext.Restaurants.Include(r => r.Dishes).ToListAsync();
			return restaurants;
		}

		public async Task<(IEnumerable<Restaurant>, int)> 
			GetAllMatchesAsync(string? search, int pageNumber, int pageSize, string? sortBy, SortDirection sortDirection)
		{
			var searchLower = search?.ToLower();

			var baseQuery = dbcontext.Restaurants.Include(r => r.Dishes)
				.Where(r => searchLower == null || (r.Name.ToLower().Contains(searchLower)
				||
				r.Description.ToLower().Contains(searchLower)));

			var totalCount = await baseQuery.CountAsync();

			if (sortBy != null)
			{
				baseQuery = sortDirection == SortDirection.Ascending
					? baseQuery.OrderBy(x => EF.Property<object>(x, sortBy))
					: baseQuery.OrderByDescending(x => EF.Property<object>(x, sortBy));
			}

			var restaurants = await baseQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
			return (restaurants, totalCount);
		}

		public Task<Restaurant?> GetByIdAsync(int id)
		{
			return dbcontext.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(x => x.Id == id);
		}
		public async Task<int> Create(Restaurant restaurant)
		{
			dbcontext.Restaurants.Add(restaurant);
		    await dbcontext.SaveChangesAsync();
			return restaurant.Id;
		}

		public  Task Delete(Restaurant restaurant)
		{
             dbcontext.Restaurants.Remove(restaurant);
			return dbcontext.SaveChangesAsync();
		}

		public Task Update(Restaurant restaurant)
		{
            dbcontext.Restaurants.Update(restaurant);
			return dbcontext.SaveChangesAsync();
		}
	}
}
