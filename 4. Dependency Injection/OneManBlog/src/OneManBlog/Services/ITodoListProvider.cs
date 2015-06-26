using OneManBlog.Models;
using System.Collections.Generic;

namespace OneManBlog.Services.Impl
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
