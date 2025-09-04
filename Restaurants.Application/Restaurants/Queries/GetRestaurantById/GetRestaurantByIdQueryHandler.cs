using AutoMapper;
using MediatR;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
	public class GetRestaurantByIdQueryHandler(IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
	{
		public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
		{
			var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

			var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

			return restaurantDto;
		}
	}
}
