using JwtAuthTemplate.Domain.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtAuthTemplate.Infrastructure.Data.EntityTypeConfiguration.Shared
{
	internal abstract class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(e => e.Id);
			//builder.Property(e => e.CreatedAt).IsRequired();
			//builder.Property(e => e.ModifiedAt).IsRequired();
		}
	}
}
