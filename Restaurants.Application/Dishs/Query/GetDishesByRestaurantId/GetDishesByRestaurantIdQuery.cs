using MediatR;
using Restaurants.Application.Dishs.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishs.Query.GetDishesByRestaurantId
{
	public class GetDishesByRestaurantIdQuery(int restaurantId):IRequest<IEnumerable<DishDto>>
	{
		public int RestaurantId { get; set; }=restaurantId;
	}
}
