using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IExpenditureGenericRepository<TEntity, TId> where TEntity : class, ITEntity<TId>
    {
        TEntity Create(TEntity model);
        TEntity Update(TEntity model);
        void Delete(TEntity id);
        TEntity GetById(TId id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
    }
}
