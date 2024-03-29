using JwtAuthTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthTemplate.Infrastructure.Data
{
	public class AppDbContext : DbContext
	{

		public DbSet<User> Users { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); 
			base.OnModelCreating(builder);
		}
	}
}
