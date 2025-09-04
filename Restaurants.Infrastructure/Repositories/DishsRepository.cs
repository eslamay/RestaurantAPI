using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Repositories
{
	internal class DishsRepository(RestaurantsDbContext dbcontext) : IDishsRepository
	{
		public async Task<int> Create(Dish dish)
		{
			dbcontext.Dishes.Add(dish);
			await dbcontext.SaveChangesAsync();
            return dish.Id;
		}

		public async Task Delete(IEnumerable<Dish> dish)
		{
            dbcontext.Dishes.RemoveRange(dish);
			await dbcontext.SaveChangesAsync();
		}
	}
}
