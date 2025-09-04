using AutoMapper;
using MediatR;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
	public class GetAllRestaurantsQueryHandler(IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuery, PagedResult<RestaurantDto>>
	{
		public async Task<PagedResult<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
		{
			var (restaurants, totalCount) = await restaurantsRepository
				.GetAllMatchesAsync
				(request.Search, request.PageNumber, request.PageSize,request.SortBy,request.SortDirection);

			var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

			var result = new PagedResult<RestaurantDto>(restaurantsDto, totalCount,request.PageSize, request.PageNumber);

			return result;
		}
	}
}
