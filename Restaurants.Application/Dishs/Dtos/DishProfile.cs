using AutoMapper;
using Restaurants.Application.Dishs.Command.CreateDish;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishs.Dtos
{
	public class DishProfile:Profile
	{
		public DishProfile()
		{
			CreateMap<Dish, DishDto>();
			CreateMap<CreateDishCommand, Dish>();
		}
	}
}
