////using Moq;
//using TodoList.Controllers;
//using TodoList.Models;
//using TodoList.Services.Impl;
//using Xunit;

//namespace OneManBlog.Tests
//{
//    public class TodoListProviderTests
//    {
//        [Theory]
//        [InlineData(5)]
//        public void TodoCreate_ExpectItemsEqualNumOfItems(int numberOfItems)
//        {
//            var classUnderTest = new TodoListProvider();
//            var feedDogTodo = new TodoItem { Title = "Feed Dog", IsDone = false };

//            for (int i = 1; i < numberOfItems; i++)
//            {
//                classUnderTest.Create(feedDogTodo);
//            }

//            Assert.True(classUnderTest.Items.Count.Equals(numberOfItems));
//        }
//    }
//}
