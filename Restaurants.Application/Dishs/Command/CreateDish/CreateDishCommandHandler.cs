using AutoMapper;
using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Dishs.Command.CreateDish
{
	public class CreateDishCommandHandler(IRestaurantsRepository restaurantsRepository,IMapper mapper,
		IDishsRepository dishsRepository)
		: IRequestHandler<CreateDishCommand>
	{
		public Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
		{
			var restaurant = restaurantsRepository.GetByIdAsync(request.RestaurantId);
			if (restaurant == null)
			{
                 throw new Exception("Restaurant not found");
			}

			var dish = mapper.Map<Dish>(request);
			dishsRepository.Create(dish);
			return Task.CompletedTask;

		}
	}
}
