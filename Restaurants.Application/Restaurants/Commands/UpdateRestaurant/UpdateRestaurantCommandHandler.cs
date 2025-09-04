using AutoMapper;
using MediatR;
using Restaurants.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
	public class UpdateRestaurantCommandHandler(IMapper mapper, IRestaurantsRepository restaurantsRepository)
		: IRequestHandler<UpdateRestaurantCommand, bool>
	{
		public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
		{
			var restaurant= await restaurantsRepository.GetByIdAsync(request.Id);
			if (restaurant == null)
			{
				return false;
			}

			restaurant = mapper.Map(request, restaurant);
			//restaurant.Name = request.Name;
			//restaurant.Description = request.Description;
			//restaurant.HasDelivery = request.HasDelivery;

			await restaurantsRepository.Update(restaurant);

			return true;
		}
	}
}
