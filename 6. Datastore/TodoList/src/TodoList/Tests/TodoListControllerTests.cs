//using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Services.Impl;
using Xunit;

namespace TodoList.Tests
{
    public class TodoListControllerTests
    {
        [Fact]
        public void UpdateController_ExpectUpdateServiceCalledOnce()
        {
            //var mockTodoListProvider = Mock.Of<ITodoListProvider>();

            //var classUnderTest = new TodoController(mockTodoListProvider.Object);
            //var TodoItem = new TodoItem { IsDone = true, Title = "take out trash" };
            //mockTodoListProvider.Setup(t => t.Update(It.IsAny<TodoItem>())).Returns(true);

            //classUnderTest.Update(TodoItem);

            //mockTodoListProvider.Verify(t => t.Update(TodoItem), Times.Once);
        }
    }
}
