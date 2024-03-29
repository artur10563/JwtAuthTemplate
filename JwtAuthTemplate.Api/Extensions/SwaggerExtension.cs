using Microsoft.OpenApi.Models;

namespace JwtAuthTemplate.Api.Extensions
{
	public static class SwaggerExtension
	{
		public static IServiceCollection AddSwaggerWithJwtAuth(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "JwtAuth Template ASP.NET 8",
					Description = "Template for further use"
				});

				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header
				});

				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						}, Array.Empty<string>()
					}
				});
			});
			return serviceCollection;
		}
	}
}
