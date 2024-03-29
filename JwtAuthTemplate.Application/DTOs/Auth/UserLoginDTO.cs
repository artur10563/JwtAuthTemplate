using System.ComponentModel.DataAnnotations;

namespace JwtAuthTemplate.Application.DTOs.Auth
{
	public class UserLoginDTO
	{
		[Required]
		public string Password { get; set; } = string.Empty;
		[Required, EmailAddress, StringLength(maximumLength: 50)]
		public string Email { get; set; } = string.Empty;
	}
}
