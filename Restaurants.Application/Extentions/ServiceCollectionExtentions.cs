using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Dishs.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Users;
using Microsoft.AspNetCore.Http;
namespace Restaurants.Application.Extentions
{
	public static class ServiceCollectionExtentions
	{
		public static void AddApplication(this IServiceCollection services)
		{
			var applicationAssembly = typeof(ServiceCollectionExtentions).Assembly;
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
			services.AddAutoMapper(a =>
			{
				a.AddProfile<RestaurantProfile>();
				a.AddProfile<DishProfile>();
			});

			services.AddScoped<IUserContext, UserContext>();
			
		}
	}
}
