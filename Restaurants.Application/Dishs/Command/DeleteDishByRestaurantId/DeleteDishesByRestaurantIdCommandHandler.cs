using AutoMapper;
using MediatR;
using Restaurants.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishs.Command.DeleteDishByRestaurantId
{
	public class DeleteDishesByRestaurantIdCommandHandler(IRestaurantsRepository restaurantsRepository,IMapper mapper,
		IDishsRepository dishsRepository) : IRequestHandler<DeleteDishesByRestaurantIdCommand>
	{
		public async Task Handle(DeleteDishesByRestaurantIdCommand request, CancellationToken cancellationToken)
		{
			var restaurant =await restaurantsRepository.GetByIdAsync(request.RestaurantId);

			if (restaurant==null)
			{
				throw new Exception("Restaurant not found");
			}

			await dishsRepository.Delete(restaurant.Dishes);
		}
	}
}
