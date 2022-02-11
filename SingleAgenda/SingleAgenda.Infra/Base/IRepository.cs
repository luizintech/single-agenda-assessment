using SingleAgenda.Entities.Base;
using System.Linq;
using System.Threading.Tasks;

namespace SingleAgenda.EFPersistence.Base
{
    public interface IRepository<TEntity> where
        TEntity : EntityBase
    {

        IQueryable<TEntity> All { get; }
        Task<TEntity> GetByIdAsync(int id);
        Task<int> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

    }
}
