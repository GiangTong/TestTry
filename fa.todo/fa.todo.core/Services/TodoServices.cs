using System.Threading.Tasks;
using fa.todo.core.Models;
using fa.todo.core.Repositories;

namespace fa.todo.core.Services
{
    public class TodoServices : BaseService<Todo>, ITodoServices
    {
        private readonly ITodoRepository _todoRepository;

        public TodoServices(IGenericRepository<Todo> repository, ITodoRepository todoRepository) : base(repository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _todoRepository.ExistAsync(id);
        }
    }
}
