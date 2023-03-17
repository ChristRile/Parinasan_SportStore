using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Parinasan_SportStore.Models
{
	public class StoreDbContext : DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> options)
			: base(options) { }
		public DbSet<Product> Products => Set<Product>();
	}
}
