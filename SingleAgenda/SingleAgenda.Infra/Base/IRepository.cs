using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SingleAgenda.EFPersistence.Base
{
    public interface IRepository<T> where
        T : class
    {

        /// <summary>
        /// Will list all row, except the removed.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> List();

        /// <summary>
        /// Will list all row, including the removed.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// For some filter conditions, pass the predicate.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        int Add(T entity);
        void Update(T entity);

        void Delete(int id);

    }
}
