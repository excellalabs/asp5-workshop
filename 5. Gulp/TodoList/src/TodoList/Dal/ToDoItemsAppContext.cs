using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Dal;
using TodoList.Models;

namespace TodoList.Dal
{
    public class TodoItemAppContext : DbContext, ITodoItemAppContext
    {
        public DbSet<TodoItem> ToDoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ToDoItems;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public void Remove(TodoItem toDoItem)
        {
            this.Remove(toDoItem);
        }
    }
}
