using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos
{
	public class RestaurantProfile:Profile
	{
		public RestaurantProfile()
		{
			CreateMap<Restaurant, RestaurantDto>()
				.ForMember(d => d.City, o => o.MapFrom(s => s.Address == null ? null : s.Address.City))
				.ForMember(d => d.Street, o => o.MapFrom(s => s.Address == null ? null : s.Address.Street))
				.ForMember(d => d.PostalCode, o => o.MapFrom(s => s.Address == null ? null : s.Address.PostalCode))
				.ForMember(d => d.Dishes, o => o.MapFrom(s => s.Dishes));

			CreateMap<CreateRestaurantCommand, Restaurant>()
				.ForMember(d=>d.Address, o=>o.MapFrom(
					src=> new Address
					{
						City = src.City,
						Street = src.Street,
						PostalCode = src.PostalCode
					}
					));

			CreateMap<UpdateRestaurantCommand, Restaurant>();
		}
	}
}
