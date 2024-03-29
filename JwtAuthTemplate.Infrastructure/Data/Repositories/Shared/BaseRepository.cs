using JwtAuthTemplate.Application.Repositories.Shared;
using JwtAuthTemplate.Domain.Entities.Shared;

namespace JwtAuthTemplate.Infrastructure.Data.Repositories.Shared
{
	abstract public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
	{
		protected readonly AppDbContext _context;
		protected BaseRepository(AppDbContext context)
		{
			_context = context;
		}

		public void Add(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
		}
	}
}