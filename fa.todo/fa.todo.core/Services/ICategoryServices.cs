using System.Threading.Tasks;
using fa.todo.core.Models;

namespace fa.todo.core.Services
{
    public interface ICategoryServices : IBaseService<Category>
    {
        Task<bool> ExistAsync(int id);
    }
}