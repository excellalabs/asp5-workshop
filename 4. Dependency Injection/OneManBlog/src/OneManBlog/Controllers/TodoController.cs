using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using OneManBlog.Models;
using OneManBlog.Services.Impl;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OneManBlog.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoListProvider todoListProvider;

        public TodoController(ITodoListProvider todoListProvider)
        {
            this.todoListProvider = todoListProvider;
        }

        //[FromServices]
        //public ITodoListProvider todoListProvider { get; set; }

        [HttpGet(Name = "getAll")]
        public IEnumerable<TodoItem> GetAll()
        {
            return this.todoListProvider.Items;
        }

        [HttpGet("{id}", Name = "getById")]
        public IActionResult Get(int id)
        {
            var item = this.todoListProvider.Get(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost(Name = "create")]
        public void Create([FromBody] TodoItem item)
        {
            var newItem = this.todoListProvider.Create(item);

            string url = Url.RouteUrl("getById", new { id = newItem.Id }, Request.Scheme, Request.Host.ToUriComponent());

            Context.Response.StatusCode = 201;
            Context.Response.Headers["Location"] = url;
        }

        [HttpPost(Name = "update")]
        public void Update([FromBody] TodoItem item)
        {
            var success = this.todoListProvider.Update(item);
            Context.Response.StatusCode = success == true ? 200 : 400;
        }

        [HttpDelete("{id}", Name = "delete")]
        public IActionResult Delete(int id)
        {
            var success = this.todoListProvider.Delete(id);
            if (success == false)
            {
                return HttpNotFound();
            }

            return new HttpStatusCodeResult(204);
        }
    }
}
