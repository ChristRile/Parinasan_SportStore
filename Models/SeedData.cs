using Microsoft.EntityFrameworkCore;

namespace Parinasan_SportStore.Models
{
	// if static, class will be as is (cannot change the characteristics)
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			StoreDbContext context = app.ApplicationServices
				.CreateScope().ServiceProvider
				.GetRequiredService<StoreDbContext>();

			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}
			if (!context.Products.Any())
			{

				context.Products.AddRange(
					new Product
					{
						Name = "Full-Body Hocky Gear",
						Description = "Includes Helmet, Neckguard, Shoulder Pads, Gloves, Shin Pads and Elbow Pads",
						Category = "Hockey",
						Price = 700m
					},
					new Product
					{
						Name = "Hockey Equiments",
						Description = "Includes Skates, Hockey Sticks, Hockey Bag",
						Category = "Hockey",
						Price = 499m
					},
					new Product
					{
						Name = "Hockey Defenseman",
						Description = "Includes Skates, Hockey Sticks and defenseman",
						Category = "Hockey",
						Price = 499m
					},
					new Product
					{
						Name = "Soccerball",
						Description = "FIFA-approved size and weight",
						Category = "Soccer",
						Price = 19.50m
					},
					new Product
					{
						Name = "Soccer Shoes",
						Description = "Nike Signature Soccer Shoes",
						Category = "Soccer",
						Price = 200m
					},
					new Product
					{
						Name = "Basketball",
						Description = "NBA-approved size and weight",
						Category = "Basketball",
						Price = 190m
					},
					new Product
					{
						Name = "Racket",
						Description = "Badminton regular size",
						Category = "Badminton",
						Price = 25.95m
					},
					new Product
					{
						Name = "Butt Cap",
						Description = "Badminton comfortable cap",
						Category = "Badminton",
						Price = 25.95m
					},
					new Product
					{
						Name = "Basketball Stadium",
						Description = "NBA sized Gymnasium",
						Category = "Basketball",
						Price = 25000m
					},
					new Product
					{
						Name = "Basketball Hoop",
						Description = "NBA size hoop",
						Category = "Basketball",
						Price = 800m
					},
					new Product
					{
						Name = "Goal Post (2)",
						Description = " 2 FIFA sized Goal Post",
						Category = "Soccer",
						Price = 1500m
					},
					new Product
					{
						Name = "Shuttlecock",
						Description = "Regular Size Badminton Shuttlecock",
						Category = "Badminton",
						Price = 10.95m
					}
				);
				context.SaveChanges();
			}
		}
	}
}

