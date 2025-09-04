using AutoMapper;
using MediatR;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
	public class CreateRestaurantCommandHandler(IMapper mapper,IUserContext userContext, IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
	{
		public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
		{
			var currentUser=userContext.GetCurrentUser();

			var restaurant = mapper.Map<Restaurant>(request);

			restaurant.OwnerId = currentUser!.Id;

			int id = await restaurantsRepository.Create(restaurant);

			return id;
		}
	}
}
