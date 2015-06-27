using TodoList.Models;
using System.Collections.Generic;
using System.Linq;
using TodoList.Dal;

namespace TodoList.Services.Impl
{
    public class TodoListProvider : ITodoListProvider
    {
        private ITodoItemAppContext _dbContext;

        public TodoListProvider(TodoItemAppContext db)
        {
            _dbContext = db;
        }

        ICollection<TodoItem> _items = new List<TodoItem>()
        {
            new TodoItem { Id = 1, Title = "Do Laundry" }
        };

        public ICollection<TodoItem> Items
        {
            get
            {
                return this._dbContext.ToDoItems.ToList();
            }
        }

        public TodoItem Get(int id)
        {
            return _dbContext.ToDoItems.FirstOrDefault(todoItem => todoItem.Id == id);
        }

        public TodoItem Create(TodoItem item)
        {
            _dbContext.ToDoItems.Add(item);
            _dbContext.Save();
            return item;
        }

        public bool Update(TodoItem item)
        {
            var itemList = this.Items.ToList();
            var indexOfItemToUpdate = itemList.IndexOf(item);
            if (indexOfItemToUpdate == -1)
            {
                return false;
            }

            itemList[indexOfItemToUpdate] = item;

            return true;
        }

        public bool Delete(int id)
        {
            var item = this.Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return false;
            }

            _dbContext.Remove(item);
            return true;
        }
    }
}
