using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Users.Command.UnAssignUserRole
{
	public class UnassignUserRoleCommandHandler(UserManager<User> userManager,
	RoleManager<IdentityRole> roleManager) : IRequestHandler<UnassignUserRoleCommand>
	{
		public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
		{
			var user = await userManager.FindByEmailAsync(request.UserEmail)
				?? throw new Exception("User not found");

			var role = await roleManager.FindByNameAsync(request.RoleName)
				?? throw new Exception("Role not found");

			await userManager.RemoveFromRoleAsync(user, role.Name!);
		}
	}
}
