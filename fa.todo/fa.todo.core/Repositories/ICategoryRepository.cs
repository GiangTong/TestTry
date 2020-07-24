using System.Threading.Tasks;
using fa.todo.core.Models;

namespace fa.todo.core.Repositories
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        bool Exist(int id);

        Task<bool> ExistAsync(int id);
    }
}
