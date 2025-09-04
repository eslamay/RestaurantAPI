using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishs.Command.DeleteDishByRestaurantId
{
	public class DeleteDishesByRestaurantIdCommand(int restaurantId):IRequest
	{
		public int RestaurantId { get; set; }=restaurantId;
	}
}
