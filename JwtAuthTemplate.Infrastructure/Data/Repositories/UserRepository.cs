using BCrypt.Net;
using JwtAuthTemplate.Application.DTOs.Auth;
using JwtAuthTemplate.Application.Repositories;
using JwtAuthTemplate.Domain.Entities;
using JwtAuthTemplate.Infrastructure.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthTemplate.Infrastructure.Data.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(AppDbContext context) : base(context) { }

		public async Task<LoginResponse> LoginAsync(UserLoginDTO userLoginDTO)
		{
			var user = await GetByEmailAsync(userLoginDTO.Email);

			if (user is null)
			{
				return new LoginResponse(false, "User with this email is not found");
			}

			var checkPassword = BCrypt.Net.BCrypt.Verify(userLoginDTO.Password, user.PasswordHash);
			if (checkPassword)
			{
				//var token = GenerateJWTToken(); //TODO: add token generation
				return new LoginResponse(true, "Successfully logged in", "token");
			}
			else
				return new LoginResponse(false, "Invalid credentials");
		}

		public async Task<RegistrationResponse> RegisterAsync(UserRegisterDTO userRegisterDTO)
		{
			var user = await GetByEmailAsync(userRegisterDTO.Email);
			if (user is not null)
			{
				return new RegistrationResponse(false, "User allready exists");
			}

			Add(new User()
			{
				Email = userRegisterDTO.Email,
				Name = userRegisterDTO.Nickname,
				PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterDTO.Password)
			});

			await _context.SaveChangesAsync();
			return new RegistrationResponse(true, "Successfully registered");

		}

		public async Task<User?> GetByEmailAsync(string email)
		{
			return await _context.Users
				.FirstOrDefaultAsync(u =>
				u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
		}
	}
}
