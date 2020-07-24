using fa.todo.core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fa.todo.core.Repositories
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity: class 
    {
        public readonly TodoContext Context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TodoContext context)
        {
            this.Context = context;
            _dbSet = this.Context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public int Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return Context.SaveChanges();
        }

        public async Task<int> CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            return await Context.SaveChangesAsync();
        }

        public bool Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync() > 0;
        }

        public bool Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Context.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
