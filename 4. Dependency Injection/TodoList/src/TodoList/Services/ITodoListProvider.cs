using TodoList.Models;
using System.Collections.Generic;

namespace TodoList.Services.Impl
{
    public interface ITodoListProvider
    {
        ICollection<TodoItem> Items { get; }

        TodoItem Get(int id);

        TodoItem Create(TodoItem item);

        bool Update(TodoItem item);

        bool Delete(int id);
    }
}
