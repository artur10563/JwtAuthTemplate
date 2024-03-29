using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JwtAuthTemplate.Domain.Entities;
using JwtAuthTemplate.Infrastructure.Data.EntityTypeConfiguration.Shared;

namespace JwtAuthTemplate.Infrastructure.Data.EntityTypeConfiguration
{
	internal class UserEntityTypeConfiguration : EntityBaseConfiguration<User>
	{
		public override void Configure(EntityTypeBuilder<User> builder)
		{
			base.Configure(builder);

			builder.Property(u => u.Name)
				.HasMaxLength(25)
				.IsRequired(true);
			builder.Property(u => u.Email)
				.HasMaxLength(50)
				.IsRequired(true);

			builder.HasIndex(u => u.Email)
				.IsUnique();

			builder.Property(u => u.PasswordHash)
				.IsRequired();
		}//TOOD: ADD DATABASE AND TEST IF BASE ENTITY IS CREATED
	}
}
