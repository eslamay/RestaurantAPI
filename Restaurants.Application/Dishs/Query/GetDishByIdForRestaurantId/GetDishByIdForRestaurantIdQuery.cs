using MediatR;
using Restaurants.Application.Dishs.Dtos;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishs.Query.GetDishByIdForRestaurantId
{
	public class GetDishByIdForRestaurantIdQuery(int restaurantId,int DishId):IRequest<DishDto>
	{
		public int RestaurantId { get; set; }=restaurantId;
		public int DishId { get; set; }=DishId;
	}
}
