using System.Threading.Tasks;
using fa.todo.core.Models;
using fa.todo.core.Repositories;

namespace fa.todo.core.Services
{
    public class CategoryServices : BaseService<Category>, ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(IGenericRepository<Category> repository, ICategoryRepository categoryRepository) : base(repository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _categoryRepository.ExistAsync(id);
        }
    }
}
