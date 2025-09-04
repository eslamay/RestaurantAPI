using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Users.Command;
using Restaurants.Application.Users.Command.AssignUserRole;
using Restaurants.Domain.Constants;

namespace Restaurants.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IdentityController(IMediator mediator) : ControllerBase
	{
		[HttpPatch("user")]
		[Authorize]
		public async Task<IActionResult> UpdateUserDetails([FromBody]UpdateUserDetailsCommand userDetailsCommand)
		{
			await mediator.Send(userDetailsCommand);
			return NoContent();
		}

		[HttpPost("userRole")]
		[Authorize(Roles = UserRoles.Admin)]
		public async Task<IActionResult> AssignUserRole(UnAssignUserRoleCommand command)
		{
			await mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("userRole")]
		[Authorize(Roles = UserRoles.Admin)]
		public async Task<IActionResult> UnAssignUserRole(UnAssignUserRoleCommand command)
		{
			await mediator.Send(command);
			return NoContent();
		}
	}
}
