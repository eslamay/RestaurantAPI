using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Domain.Constants;

namespace Restaurants.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class RestaurantsController : ControllerBase
	{
		private readonly IMediator mediator;

		public RestaurantsController(IMediator mediator)
		{ 
			this.mediator = mediator;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetRestaurants([FromQuery] GetAllRestaurantsQuery query)
		{
			var restaurants =await mediator.Send(query);
			return Ok(restaurants);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetRestaurant([FromRoute]int id)
		{
			var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
			if (restaurant == null)
			{
                return NotFound();
			}
			return Ok(restaurant);
		}

		[HttpPost]
		[Authorize(Roles = UserRoles.Owner)]
		public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantCommand)
		{
			var id = await mediator.Send(createRestaurantCommand);

			return CreatedAtAction(nameof(GetRestaurant), new { id }, null);
		}

		[HttpPatch]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateRestaurant([FromRoute]int id, [FromBody] UpdateRestaurantCommand updateRestaurantCommand)
		{
			updateRestaurantCommand.Id = id;
			var isUpdated = await mediator.Send(updateRestaurantCommand);
			if (!isUpdated)
			{
				return NotFound();
			}
			return NoContent();
		}

		[HttpDelete]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteRestaurant([FromRoute]int id)
		{
			var isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
			if (!isDeleted)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}
