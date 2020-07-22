using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fa.todo.core.Models
{
    public class Category
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
    }
}