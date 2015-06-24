using System.ComponentModel.DataAnnotations;

namespace OneManBlog.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public bool IsDone { get; set; }

        public override string ToString()
        {
            return $"{this.Title}";
        }
    }
}
