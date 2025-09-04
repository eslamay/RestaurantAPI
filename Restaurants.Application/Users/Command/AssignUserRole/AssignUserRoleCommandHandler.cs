using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Users.Command.AssignUserRole
{
	public class AssignUserRoleCommandHandler(UserManager<User> userManager,
	RoleManager<IdentityRole> roleManager) : IRequestHandler<UnAssignUserRoleCommand>
	{
		public async Task Handle(UnAssignUserRoleCommand request, CancellationToken cancellationToken)
		{
			
			var user = await userManager.FindByEmailAsync(request.UserEmail)
				?? throw new Exception("User not found");

			var role = await roleManager.FindByNameAsync(request.RoleName)
				?? throw new Exception("Role not found");

			await userManager.AddToRoleAsync(user, role.Name!);

		}
	}
}
