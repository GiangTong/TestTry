using System.Linq;
using System.Threading.Tasks;
using fa.todo.core.Models;
using Microsoft.EntityFrameworkCore;

namespace fa.todo.core.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TodoContext context) : base(context)
        {
        }

        public bool Exist(int id)
        {
            return Context.Categories.Any(t => t.Id == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await Context.Categories.AnyAsync(t => t.Id == id);
        }
    }
}