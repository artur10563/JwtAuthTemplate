using JwtAuthTemplate.Domain.Entities.Shared;

namespace JwtAuthTemplate.Domain.Entities
{
	public class User : EntityBase
	{
		public string Name { get; set; }
		public string PasswordHash { get; set; }
		public string Email { get; set; }

		public User() { }
	}
}
