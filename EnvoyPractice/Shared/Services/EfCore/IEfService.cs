using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Shared.Services.EfCore
{
    public interface IEfService<TEntity, TContext>
    {
        Task<TEntity> GetByIdAsync(int id, bool tracking = true);
        Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>>? query = null,
                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                    bool tracking = true);

        Task<TEntity> AddAsync(TEntity request);
        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> request);

        Task<TEntity> DeleteAsync(TEntity request);
        Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> request);

        Task<TEntity> UpdateAsync(TEntity request);
        Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> request);
    }
}
