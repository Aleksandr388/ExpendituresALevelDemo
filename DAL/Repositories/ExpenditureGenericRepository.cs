using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class ExpenditureGenericRepository<TEntity, TId> : IExpenditureGenericRepository<TEntity, TId> where TEntity : class, ITEntity<TId>
    {
        private readonly DbContext _ctx;
        private readonly DbSet<TEntity> _dbSet;
        public ExpenditureGenericRepository(DbContext context)
        {
            _ctx = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity Create(TEntity model)
        {
            _dbSet.Add(model);

            _ctx.SaveChanges();

            return model;
        }

        public void Delete(TEntity model)
        {
            _dbSet.Attach(model);
            _dbSet.Remove(model);
            _ctx.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity GetById(TId id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Update(TEntity Model)
        {
            _ctx.Entry(Model).State = EntityState.Modified;
            _ctx.SaveChanges();

            return Model;
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
