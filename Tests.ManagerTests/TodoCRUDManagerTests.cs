using System;
using System.Collections.Generic;
using System.Linq;
using Accessors.DatabaseAccessors;
using DeepEqual.Syntax;
using Managers.LazyCollectionOfAllManagers;
using Ninject;
using NUnit.Framework;
using Shared.DataContracts;
using Shared.DependencyInjectionKernel;
using Telerik.JustMock;
using Telerik.JustMock.AutoMock;
using Test.NUnitExtensions;
using Tests.DataPrep;

namespace Tests.ManagerTests
{
    //NOTE: test fixture arguments break code lens support, submitted issue #485 https://github.com/nunit/nunit3-vs-adapter/issues/485
    [TestFixture_Prefixed(typeof(TodoCRUDManager), false)]
    [TestFixture_Prefixed(typeof(TodoCRUDManager), true)]
    public class TodoCRUDManagerTests : ManagerTestBase
    {
        TodoCRUDManager manager;
        MockingContainer<TodoCRUDManager> mockContainer = new MockingContainer<TodoCRUDManager>();

        public TodoCRUDManagerTests() : this(false) { }
        public TodoCRUDManagerTests(bool isIntegration = false)
        {
            // this constructor allows for integration test reuse
            if (isIntegration)
            {
                // Implicit self binding allows us to get a concrete class with fulfilled dependencies
                // https://github.com/ninject/ninject/wiki/dependency-injection-with-ninject
                Ninject.IKernel kernel = DependencyInjectionLoader.BuildKernel();
                manager = kernel.Get<TodoCRUDManager>();
                dataPrep = new TodoDataPrep(true);
            }
            else
            {
                manager = mockContainer.Instance;
                // dataPrep non-persistant by default in base class
            }
        }

        public override void OnCleanup()
        {
        }

        public override void OnInitialize()
        {
           
        }
        
        [Test]
        public void GetTodoItems()
        {
            // arrange
            TodoList todoList = dataPrep.TodoLists.Create();
            int expectedItemCount = 5;
            IEnumerable<TodoItem> expectedItemList = dataPrep.TodoItems.CreateManyForList(expectedItemCount, todoList);

            mockContainer.Arrange<ITodoItemAccessor>(accessor => accessor.GetTodoItemsForList(todoList.Id)).Returns(expectedItemList);

            // act
            IEnumerable<TodoItem> actualItemList = manager.GetTodoItems(todoList.Id);

            //assert
            expectedItemList.ShouldDeepEqual(actualItemList);
        }

        [Test]
        public void GetTodoList()
        {
            // arrange
            TodoList expectedTodoList = dataPrep.TodoLists.Create();

            mockContainer.Arrange<ITodoListAccessor>(accessor => accessor.GetTodoList(expectedTodoList.Id)).Returns(expectedTodoList);

            // act
            TodoList actualTodoList = manager.GetTodoList(expectedTodoList.Id);

            //assert
            expectedTodoList.ShouldDeepEqual(actualTodoList);
        }

        [Test]
        public void SaveTodoItem()
        {
            // arrange
            TodoItem expectedTodoItem = dataPrep.TodoItems.Create();

            expectedTodoItem.Description = Guid.NewGuid().ToString();

            mockContainer.Arrange<ITodoItemAccessor>(accessor => accessor.SaveTodoItem(expectedTodoItem)).Returns(new SaveResult<TodoItem>(expectedTodoItem));

            // act
            SaveResult<TodoItem> todoItemResult = manager.SaveTodoItem(expectedTodoItem);
            TodoItem actualTodoItem = todoItemResult.Result;

            //assert
            Assert.IsTrue(todoItemResult.Success);
            // because we mutated the expected object, the changed property is as expected on the original object too
            expectedTodoItem.ShouldDeepEqual(actualTodoItem);
        }

        [Test]
        public void SaveTodoList()
        {
            // arrange
            TodoList expectedTodoList = dataPrep.TodoLists.Create();
            expectedTodoList.Title = Guid.NewGuid().ToString();

            mockContainer.Arrange<ITodoListAccessor>(accessor => accessor.SaveTodoList(Arg.IsAny<TodoList>())).Returns(new SaveResult<TodoList>(expectedTodoList));

            // act
            SaveResult<TodoList> todoListResult = manager.SaveTodoList(expectedTodoList);

            //assert
            Assert.IsTrue(todoListResult.Success);
            expectedTodoList.ShouldDeepEqual(todoListResult.Result);
        }
    }
    
}
