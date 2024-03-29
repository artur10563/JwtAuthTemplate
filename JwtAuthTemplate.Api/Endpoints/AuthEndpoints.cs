using JwtAuthTemplate.Application.DTOs.Auth;
using JwtAuthTemplate.Application.Repositories;
using JwtAuthTemplate.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace JwtAuthTemplate.Api.Endpoints
{
	public static class AuthEndpoints
	{
		//Can be simplified with Carter nu-get package
		public static void RegisterAuthEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapPost("api/auth/register", RegisterUserAsync);
			app.MapPatch("api/auth/login", LoginUserAsync);
		}

		private static async Task<IResult> RegisterUserAsync(
			UserRegisterDTO registerDTO,
			IUserRepository _users)
		{
			var validationResults = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(registerDTO, new ValidationContext(registerDTO), validationResults, true);
			if (!isValid)
			{
				return TypedResults.BadRequest(validationResults);
			}

			var response = await _users.RegisterAsync(registerDTO);
			if (response.Status)
			{
				return TypedResults.Ok(response);
			}
			return TypedResults.Conflict(response);
		}

		private static async Task<IResult> LoginUserAsync(
			UserLoginDTO loginDTO,
			IUserRepository _users)
		{
			var validationResults = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(loginDTO, new ValidationContext(loginDTO), validationResults, true);
			if (!isValid)
			{
				return TypedResults.BadRequest(validationResults);
			}

			var response = await _users.LoginAsync(loginDTO);
			if (response.Status)
			{
				return TypedResults.Ok(response);
			}
			return TypedResults.Conflict(response);

		}


	}
}
