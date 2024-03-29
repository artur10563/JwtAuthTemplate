using JwtAuthTemplate.Domain.Entities.Shared;

namespace JwtAuthTemplate.Application.Repositories.Shared
{
	public interface IBaseRepository<TEntity> where TEntity : EntityBase
	{
		void Add(TEntity entity);
	}
}
