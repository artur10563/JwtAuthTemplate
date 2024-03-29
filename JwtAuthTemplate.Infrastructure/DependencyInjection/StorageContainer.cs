using JwtAuthTemplate.Application.Repositories;
using JwtAuthTemplate.Infrastructure.Data;
using JwtAuthTemplate.Infrastructure.Data.Repositories;
using JwtAuthTemplate.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JwtAuthTemplate.Infrastructure.DependencyInjection
{
	public static class StorageContainer
	{
		public static IServiceCollection AddStorage(this IServiceCollection serviceCollection, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection")
				?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			serviceCollection.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(connectionString));

			serviceCollection.AddScoped<IUserRepository, UserRepository>();
			serviceCollection.AddSingleton<JwtTokenProvider>();

			return serviceCollection;
		}
	}
}
