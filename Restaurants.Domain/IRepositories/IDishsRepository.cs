using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.IRepositories
{
	public interface IDishsRepository
	{
		Task<int> Create(Dish dish);
		Task Delete(IEnumerable<Dish> dish);
	}
}
