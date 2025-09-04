using AutoMapper;
using MediatR;
using Restaurants.Application.Dishs.Dtos;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Dishs.Query.GetDishByIdForRestaurantId
{
	public class GetDishByIdForRestaurantIdQueryHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper,
		IDishsRepository dishsRepository) : IRequestHandler<GetDishByIdForRestaurantIdQuery, DishDto>
	{
		public async Task<DishDto> Handle(GetDishByIdForRestaurantIdQuery request, CancellationToken cancellationToken)
		{
			var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);

			if (restaurant == null)
			{
				throw new Exception("Restaurant not found");
			}

			var dish=restaurant.Dishes.FirstOrDefault(x=>x.Id==request.DishId);
			if (dish == null)
			{
				throw new Exception("Dish not found");
			}

			var result = mapper.Map<DishDto>(dish);

			return result;
		}
	}
}
