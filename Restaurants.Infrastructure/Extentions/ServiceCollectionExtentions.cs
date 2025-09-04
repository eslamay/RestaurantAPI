using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Authorization.Requirements;
using Restaurants.Infrastructure.Authorization.Services;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;


namespace Restaurants.Infrastructure.Extentions
{
	public static class ServiceCollectionExtentions
	{
		public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("constr");
			services.AddDbContext<RestaurantsDbContext>(options=>
			options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

			


			services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
			services.AddScoped<IRestaurantsRepository,RestaurantsRepository>();
			services.AddScoped<IDishsRepository, DishsRepository>();
			services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
			services.AddScoped<IRestaurantAuthorizationService, RestaurantAuthorizationService>();
		}
	}
}
