using System.ComponentModel.DataAnnotations;

namespace JwtAuthTemplate.Application.DTOs.Auth
{
	public class UserRegisterDTO
	{
		[Required, StringLength(maximumLength: 25, MinimumLength = 2)]
		public string Nickname { get; set; } = string.Empty;
		[Required]
		public string Password { get; set; } = string.Empty;
		[Required, EmailAddress, StringLength(maximumLength: 50)]
		public string Email { get; set; } = string.Empty;

	}
}
