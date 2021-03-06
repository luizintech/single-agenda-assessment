using Microsoft.EntityFrameworkCore;
using SingleAgenda.Entities.Base;
using SingleAgenda.Infra.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SingleAgenda.Infra.Base
{
    public abstract class RepositoryBase<T>
        : IRepository<T>, IDisposable
        where T : EntityBase
    {
        private readonly SingleAgendaDbContext _context;

        #region Constructors

        public RepositoryBase(IServiceProvider serviceProvider)
            : this(new SingleAgendaDbContext(serviceProvider))
        {
        }
        
        public RepositoryBase(SingleAgendaDbContext context)
        {
            _context = context;
        }

        #endregion

        public int Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);
            entity.UpdatedAt = DateTime.Now;
            entity.Removed = true;
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>()
                .Where(et => et.Removed == true)
                .ToArray();
        }

        public T GetById(int id)
        {
            return _context.Set<T>()
                .Where(et => et.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<T> List()
        {
            return _context.Set<T>()
                .Where(et => et.Removed == false)
                .ToArray();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // Todo the disposable method according.
        }
    }
}
