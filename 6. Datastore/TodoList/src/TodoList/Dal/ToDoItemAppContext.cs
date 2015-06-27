using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace OneManBlog.Dal
{
    public class TodoItemAppContext : DbContext
    {
        public DbSet<TodoItem> ToDoItems { get; set; }
        
    }
}