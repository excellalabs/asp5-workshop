using Microsoft.Data.Entity;
using TodoList.Models;

namespace OneManBlog.Dal
{
    public interface ITodoItemAppContext
    {
        DbSet<TodoItem> ToDoItems { get; set; }
    }
}