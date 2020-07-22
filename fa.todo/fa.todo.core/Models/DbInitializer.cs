using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fa.todo.core.Models
{
    public class DbInitializer
    {
        public static void Seed(TodoContext context)
        {
            context.Database.EnsureCreated();
            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category()
                {
                    Name = "Working"
                },
                new Category()
                {
                    Name = "Learning"
                },
                new Category()
                {
                    Name = "Relaxing"
                }
            };
            context.Categories.AddRange(categories);

            var todo = new Todo[]
            {
                new Todo()
                {
                    Title = "Complete NPL Assignment",
                    IsCompleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Category = categories.Single(c => c.Name == "Working")
                },
                new Todo()
                {
                    Title = "NPL Final Test",
                    IsCompleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Category = categories.Single(c => c.Name == "Working")
                },
                new Todo()
                {
                    Title = "Learning Angular Fundamental",
                    IsCompleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Category = categories.Single(c => c.Name == "Learning")
                },
                new Todo()
                {
                    Title = "Learning ASP.NET Core MVC",
                    IsCompleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Category = categories.Single(c => c.Name == "Learning")
                },
                new Todo()
                {
                    Title = "Play football",
                    IsCompleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Category = categories.Single(c => c.Name == "Relaxing")
                }
            };
            context.Todos.AddRange(todo);
            context.SaveChanges();
        }
    }
}
