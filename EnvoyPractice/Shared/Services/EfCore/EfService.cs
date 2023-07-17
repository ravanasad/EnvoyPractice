using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Shared.Entities;
using System.Linq.Expressions;

namespace Shared.Services.EfCore
{
    public class EfService<TEntity, TContext> : IEfService<TEntity, TContext>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EfService(TContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> Context => _context.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity request)
        {
            EntityEntry<TEntity> entityEntry = await Context.AddAsync(request);
            if (entityEntry.State != EntityState.Added)
                //todo exception
                throw new Exception();
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> request)
        {
            await Context.AddRangeAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<TEntity> DeleteAsync(TEntity request)
        {
            EntityEntry<TEntity> entityEntry = Context.Remove(request);
            if (entityEntry.State != EntityState.Deleted)
                //todo exception
                throw new Exception();
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> request)
        {
            Context.RemoveRange(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<TEntity> GetByIdAsync(int id, bool tracking = true)
        {
            TEntity? response = tracking ?
                await Context.FirstOrDefaultAsync(x => x.Id == id) :
                await Context.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (response == null)
                //todo exception
                throw new Exception();
            return response;
        }

        public async Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>>? query = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool tracking = true)
        {
            IQueryable<TEntity> queryable = Context;
            if (!tracking)
                queryable = queryable.AsNoTracking();
            if (include != null)
                queryable = include(queryable);
            if (query != null)
                queryable = queryable.Where(query);

            return await queryable.ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity request)
        {
            EntityEntry<TEntity> entityEntry = Context.Update(request);
            if (entityEntry.State != EntityState.Modified)
                //todo exception
                throw new Exception();
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> request)
        {
            Context.UpdateRange(request);
            await _context.SaveChangesAsync();
            return request;
        }
    }
}
