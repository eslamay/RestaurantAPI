using Restaurants.Domain.Common;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.IRepositories
{
	public interface IRestaurantsRepository
	{
		Task <IEnumerable<Restaurant>> GetAllAsync();
		Task<(IEnumerable<Restaurant>, int)> GetAllMatchesAsync(string? search, int pageNumber, int pageSize, string? sortBy, SortDirection sortDirection);
		Task<Restaurant?> GetByIdAsync(int id);
		Task<int>Create(Restaurant restaurant);
		Task Delete(Restaurant restaurant);
		Task Update(Restaurant restaurant);
	}
}
