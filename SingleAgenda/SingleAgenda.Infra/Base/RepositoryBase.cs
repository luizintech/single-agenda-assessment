using Microsoft.EntityFrameworkCore;
using SingleAgenda.EFPersistence.Configuration;
using SingleAgenda.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SingleAgenda.EFPersistence.Base
{
    public abstract class RepositoryBase<TEntity>
        : IRepository<TEntity>, IDisposable
        where TEntity : EntityBase
    {

        protected readonly SingleAgendaDbContext _context;

        public RepositoryBase(SingleAgendaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// In some cases you need to expose the IQueryable result.
        /// Extends this property to make the custom query and inprove performance,
        /// avoiding the box and unbox issues, usign conversion between lists.
        /// </summary>
        public IQueryable<TEntity> All =>
            this._context.Set<TEntity>().AsQueryable();

        public async Task<int> AddAsync(TEntity entity)
        {
            await this._context.Set<TEntity>().AddRangeAsync(entity);
            return await this._context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            this._context.Set<TEntity>().RemoveRange(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await this._context.FindAsync<TEntity>(id);
        }

        public IEnumerable<TEntity> List()
        {
            return _context.Set<TEntity>()
                .Where(et => et.Removed == false)
                .ToArray();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this._context.Set<TEntity>().UpdateRange(entity);
            await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// Release resources
        /// </summary>
        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
