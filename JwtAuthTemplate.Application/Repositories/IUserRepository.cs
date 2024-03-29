using JwtAuthTemplate.Application.DTOs.Auth;
using JwtAuthTemplate.Domain.Entities;

namespace JwtAuthTemplate.Application.Repositories
{
	public interface IUserRepository
	{
		Task<RegistrationResponse> RegisterAsync(UserRegisterDTO userRegisterDTO);
		Task<LoginResponse> LoginAsync(UserLoginDTO userLoginDTO);

		Task<User?> GetByEmailAsync(string email);
	}
}
