using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
        }

        public TodoItem(TodoItem item)
        {
            this.Id = item.Id;
            this.Title = item.Title;
            this.IsDone = item.IsDone;
        }
        
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
