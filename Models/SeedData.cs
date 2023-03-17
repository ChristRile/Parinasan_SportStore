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
						Name = "Kayak",
						Description = "A boat for one person",
						Category = "Watersports",
						Price = 275
					},
					new Product
					{
						Name = "Lifejacket",
						Description = "Protective and fashionable",
						Category = "Watersports",
						Price = 49.95m
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
						Name = "Corner Flags",
						Description = "Give your playing field a professional touch",
						Category = "Soccer",
						Price = 34.95m
					},
					new Product
					{
						Name = "Basketball",
						Description = "NBA-approved size and weight",
						Category = "Basketball",
						Price = 25.95m
					},
					new Product
					{
						Name = "Basketball",
						Description = "NBA-approved size and weight",
						Category = "Basketball",
						Price = 25.95m
					},
					new Product
					{
						Name = "Basketball",
						Description = "NBA-approved size and weight",
						Category = "Basketball",
						Price = 25.95m
					},
					new Product
					{
						Name = "Basketball",
						Description = "NBA-approved size and weight",
						Category = "Basketball",
						Price = 25.95m
					},
					new Product
					{
						Name = "Basketball",
						Description = "NBA-approved size and weight",
						Category = "Basketball",
						Price = 25.95m
					},
					new Product
					{
						Name = "Basketball",
						Description = "NBA-approved size and weight",
						Category = "Basketball",
						Price = 25.95m
					}
				);
				context.SaveChanges();
			}
		}
	}
}

