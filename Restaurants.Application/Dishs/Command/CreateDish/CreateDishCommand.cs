using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishs.Command.CreateDish
{
	public class CreateDishCommand:IRequest
	{
		public string Name { get; set; } = default!;
		public string Description { get; set; } = default!;
		public decimal Price { get; set; }
		public int? kiloCalories { get; set; }

		public int RestaurantId { get; set; }
	}
}
