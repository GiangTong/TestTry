using Microsoft.EntityFrameworkCore;

namespace fa.todo.core.Models
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Todo> Todos { get; set; }
    }
}
