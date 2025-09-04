using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Restaurants.Application.Extentions;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Authorization;
using Restaurants.Infrastructure.Authorization.Requirements;
using Restaurants.Infrastructure.Extentions;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;
namespace Restaurants.API
{
	public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddIdentityApiEndpoints<User>()
				.AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<RestaurantsUserClaimsPrincipalFactory>()
			.AddEntityFrameworkStores<RestaurantsDbContext>();

            builder.Services.AddAuthorizationBuilder()
                .AddPolicy(PolicyName.HasNationality, builder => builder.RequireClaim(AppClaimsType.Nationality))
                .AddPolicy(PolicyName.AtLeast20,builder=>builder.AddRequirements(new MinimumAgeRequirement(20)));

			builder.Services.AddApplication();

            builder.Services.AddHttpContextAccessor();

            builder.Host.UseSerilog((context, configuration)
                => configuration
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
                .WriteTo.File("Logs/Restaurants-API-.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit:true)
                .WriteTo.Console());

            builder.Services.AddAuthentication();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(
                c =>
                {
                    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
						Scheme = "bearer",
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                       {
                         new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
                            },
                            []
                       }
                    });
                }
                );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
            await seeder.Seed();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

			
			

			app.MapGroup("api/identitiy").WithTags("Identity").MapIdentityApi<User>();

			app.UseAuthorization();

			app.MapControllers();

            app.Run();
        }
    }
}
