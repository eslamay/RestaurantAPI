using AutoMapper;
using MediatR;
using Restaurants.Application.Dishs.Dtos;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Dishs.Query.GetDishesByRestaurantId
{
	public class GetDishesByRestaurantIdQueryHandler(IRestaurantsRepository restaurantsRepository,IMapper mapper,
		IDishsRepository dishsRepository) : IRequestHandler<GetDishesByRestaurantIdQuery, IEnumerable<DishDto>>
	{
		public async Task<IEnumerable<DishDto>> Handle(GetDishesByRestaurantIdQuery request, CancellationToken cancellationToken)
		{
			var restaurant =await restaurantsRepository.GetByIdAsync(request.RestaurantId);

			if (restaurant == null)
			{
				throw new Exception("Restaurant not found");
			}
			
			var result=mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
			return result;
		}
	}
}
