using fa.todo.core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace fa.todo.core.Repositories
{
    public class TodoRepository : GenericRepository<Todo>, ITodoRepository
    {
        public TodoRepository(TodoContext context) : base(context)
        {
        }

        public IEnumerable<Todo> GetLatestTodo(int size)
        {
            return Context.Todos.OrderByDescending(t => t.CreatedDate).Take(size).ToList();
        }

        public IEnumerable<Todo> GetTodoByStatus(bool isCompleted)
        {
            return Context.Todos.OrderBy(t => t.IsCompleted).ToList();
        }

        public async Task<IEnumerable<Todo>> GetLatestTodoAsync(int size)
        {
            return await Context.Todos.OrderByDescending(t => t.CreatedDate).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Todo>> GetTodoByStatusAsync(bool isCompleted)
        {
            return await Context.Todos.OrderBy(t => t.IsCompleted).ToListAsync();
        }

        public bool Exist(int id)
        {
            return Context.Todos.Any(t => t.Id == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await Context.Todos.AnyAsync(t => t.Id == id);
        }
    }
}
