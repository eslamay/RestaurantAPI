using MediatR;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Common;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
	public class GetAllRestaurantsQuery:IRequest<PagedResult<RestaurantDto>>
	{
		public string? Search { get; set; }
		public int PageSize { get; set; }
		public int PageNumber { get; set; }
		public string? SortBy { get; set; }
		public SortDirection SortDirection { get; set; }
	}
}
