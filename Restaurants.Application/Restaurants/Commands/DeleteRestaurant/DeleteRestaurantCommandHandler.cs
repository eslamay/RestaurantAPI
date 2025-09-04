using AutoMapper;
using MediatR;
using Restaurants.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
	public class DeleteRestaurantCommandHandler(IMapper mapper, IRestaurantsRepository restaurantsRepository)
		: IRequestHandler<DeleteRestaurantCommand, bool>
	{
		public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
		{
			var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
			if (restaurant == null) 
				return false;

			await restaurantsRepository.Delete(restaurant);
			return true;
		}
	}
}
