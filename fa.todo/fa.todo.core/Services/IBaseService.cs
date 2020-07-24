using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace fa.todo.core.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        int Add(TEntity entity);

        Task<int> AddAsync(TEntity entity);

        bool Update(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        bool Delete(int id);

        Task<bool> DeleteAsync(int id);

        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);

        Task<Paginated<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10);

        Task<IEnumerable<TEntity>> GetAllAsync();

    }
}
