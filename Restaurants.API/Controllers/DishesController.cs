using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishs.Command.CreateDish;
using Restaurants.Application.Dishs.Command.DeleteDishByRestaurantId;
using Restaurants.Application.Dishs.Query.GetDishByIdForRestaurantId;
using Restaurants.Application.Dishs.Query.GetDishesByRestaurantId;

namespace Restaurants.API.Controllers
{
	[Route("api/restaurants/{restaurantId}/[controller]")]
	[ApiController]
	public class DishesController(IMediator mediator) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllDishesForRestaurant([FromRoute]int restaurantId)
		{
			var dishes = await mediator.Send(new GetDishesByRestaurantIdQuery(restaurantId));
			return Ok(dishes);
		}

		[HttpGet]
		[Route("{DishId}")]
		public async Task<IActionResult> GetDishesByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int DishId)
		{
			var dish = await mediator.Send(new GetDishByIdForRestaurantIdQuery(restaurantId, DishId));
			return Ok(dish);
		}


		[HttpPost]
		public async Task<IActionResult> CreateDish([FromRoute]int restaurantId, [FromBody] CreateDishCommand createDishCommand)
		{
			createDishCommand.RestaurantId = restaurantId;
			await mediator.Send(createDishCommand);
			return Created();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteDish([FromRoute]int restaurantId)
		{
			await mediator.Send(new DeleteDishesByRestaurantIdCommand(restaurantId));
			return NoContent();
		}
	}
}
