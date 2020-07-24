using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using fa.todo.core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fa.todo.core.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public readonly IGenericRepository<TEntity> Repository;

        public BaseService(IGenericRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public int Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return Repository.Create(entity);
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return await Repository.CreateAsync(entity);
        }

        public bool Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return Repository.Update(entity);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return await Repository.UpdateAsync(entity);
        }

        public bool Delete(int id)
        {
            var entity = Repository.GetById(id);
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return Repository.Delete(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await Repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return await Repository.DeleteAsync(entity);
        }

        public TEntity GetById(int id)
        {
            return Repository.GetById(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public async Task<Paginated<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10)
        {
            var query = Repository.Get(filter: filter, orderBy: orderBy, includeProperties: includeProperties);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await Paginated<TEntity>.CreateAsync(query.AsNoTracking(), pageIndex, pageSize);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        
    }
}
