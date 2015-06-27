using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Dal
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
            options.UseSqlServer(@"Server=(local);Database=ToDoItems;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}