using System.Threading.Tasks;
using fa.todo.core.Models;

namespace fa.todo.core.Services
{
    public interface ITodoServices : IBaseService<Todo>
    {
        Task<bool> ExistAsync(int id);

    }
}