using fa.todo.core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fa.todo.core.Repositories
{
    public interface ITodoRepository : IGenericRepository<Todo>
    {
        IEnumerable<Todo> GetLatestTodo(int size);

        IEnumerable<Todo> GetTodoByStatus(bool isCompleted);

        Task<IEnumerable<Todo>> GetLatestTodoAsync(int size);

        Task<IEnumerable<Todo>> GetTodoByStatusAsync(bool isCompleted);

        bool Exist(int id);

        Task<bool> ExistAsync(int id);
    }
}
