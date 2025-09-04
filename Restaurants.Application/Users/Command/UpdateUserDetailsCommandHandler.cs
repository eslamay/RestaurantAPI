using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Users.Command
{
	public class UpdateUserDetailsCommandHandler(IUserContext userContext,IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailsCommand>
	{
		public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
		{
			var user = userContext.GetCurrentUser();

			var dbUser= await userStore.FindByIdAsync(user!.Id,cancellationToken);

			if (dbUser == null)
			{
				throw new Exception("User not found");
			}

			dbUser.Nationality = request.Nationality;
			dbUser.DateOfBirth = request.DateOfBirth;

			await userStore.UpdateAsync(dbUser,cancellationToken);
		}
	}
}
