using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace OneManBlog.Dal
{
    public class TodoItemAppContext : DbContext, ITodoItemAppContext
    {
        public DbSet<TodoItem> ToDoItems { get; set; }

        private static bool _created = false;

        public TodoItemAppContext()
        {
            if (_created)
            {
                Database.AsRelational().ApplyMigrations();
                _created = true;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=toDoItems;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}