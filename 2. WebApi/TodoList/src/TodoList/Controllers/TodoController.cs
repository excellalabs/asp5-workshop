using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TodoList.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        static ICollection<TodoItem> _items = new List<TodoItem>()
        {
            new TodoItem { Id = 1, Title = "Do Laundry" }
        };
        
        [HttpGet(Name = "getAll")]
        public IEnumerable<TodoItem> GetAll()
        {
            return _items;
        }

        [HttpGet("{id}", Name = "getById")]
        public IActionResult Get(int id)
        {
            var item = _items.FirstOrDefault(todoItem => todoItem.Id == id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost(Name = "create")]
        public void Create([FromBody] TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                item.Id = 1 + _items.Max(x => (int?)x.Id) ?? 0;
                _items.Add(item);

                string url = Url.RouteUrl("getById", new { id = item.Id }, Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpPost(Name = "update")]
        public void Update([FromBody] TodoItem item)
        {
            var itemList = _items.ToList();
            var indexOfTodoItemToUpdate = itemList.FindIndex(todoItem => todoItem.Id == item.Id);

            if(indexOfTodoItemToUpdate != -1)
            {
                itemList[indexOfTodoItemToUpdate] = item;
                _items = itemList;
                Context.Response.StatusCode = 200;
            }

            Context.Response.StatusCode = 400;
        }

        [HttpDelete("{id}", Name = "delete")]
        public IActionResult Delete(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            _items.Remove(item);
            return new HttpStatusCodeResult(204);
        }
    }
}
