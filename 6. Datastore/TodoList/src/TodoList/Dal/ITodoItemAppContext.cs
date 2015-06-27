using Microsoft.Data.Entity;
using TodoList.Models;

namespace TodoList.Dal
{
    public interface ITodoItemAppContext
    {
        DbSet<TodoItem> ToDoItems { get; set; }

        void Save();
    }
}