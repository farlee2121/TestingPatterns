using System;
using System.Collections.Generic;
using System.Linq;
using Accessors.DatabaseAccessors;
using DeepEqual.Syntax;
using Managers.LazyCollectionOfAllManagers;
using Ninject;
using NUnit.Framework;
using Shared.DatabaseContext;
using Shared.DatabaseContext.DBOs;
using Shared.DataContracts;
using Shared.DependencyInjectionKernel;
using Telerik.JustMock.AutoMock;
using Test.NUnitExtensions;
using Tests.DataPrep;

namespace Tests.ManagerTests
{
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
    }
    
}
