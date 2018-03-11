using Accessors.DatabaseAccessors;
using DeepEqual.Syntax;
using Managers.LazyCollectionOfAllManagers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Shared.DataContracts;
using Shared.DependencyInjectionKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock.AutoMock;
using Telerik.JustMock.AutoMock.Ninject;
using Tests.DataPrep;

namespace Tests.ManagerTests
{
    [TestClass]
    public class MSTest_UnitTest 
    {
        TodoCRUDManager manager;
        TodoDataPrep dataPrep;
        MockingContainer<TodoCRUDManager> mockContainer = new MockingContainer<TodoCRUDManager>();

        public MSTest_UnitTest() : this(false) { }
        public MSTest_UnitTest(bool isIntegration = false)
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
                dataPrep = new TodoDataPrep(false);
            }
        }

        [TestMethod]
        public void MSTest_GetTodoItems()
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

    [TestClass]
    public class MSTest_IntegrationReuse
    {
        // NOTE: Reuse of integration tests can also be done with inheritance
        // However, it causes duplicate names and both integration and 
        // unit runs will be directed to the inherited class, making it unclear which test is which

        // The downside of this method is that it requires manual maintenance 
        // Alt 1: Could explore the possibility of reflecting over a class's methods and raising an exception
        // that highlights the failed method with a reason

        // Alt 2: Another alternative would be looking at generating a code file at build time with a plugin
        // It would be a pretty simple plugin with simple emitted code

        // Alt 3: try extending TestMethod or TestClass to run tests twice

        // Conclusion: use NUnit for simpler and more powerful test extension

        TodoCRUDManagerTests unitTests = new TodoCRUDManagerTests();

        [TestInitialize]
        public void OnInit()
        {
            unitTests = new TodoCRUDManagerTests(true);
        }

        [TestMethod]
        public void MSTest_GetTodoItems_Integration()
        {
            // Want to test this is going to the DB? Try debugging and stepping through
            // or setting dataprep persistance to false
            unitTests.GetTodoItems();
        }

    }

    [TestClass]
    public class MSTest_IntegrationReuse_Inherited : MSTest_UnitTest
    {
        //NOTE: This does not allow you to create distinct names for clarity and both integration and 
        // unit runs will be directed to the inherited class, making it unclear which test is which

        // Use NUnit for simpler and more powerful test extension

        public MSTest_IntegrationReuse_Inherited() : base(true)
        {
        }

    }

}
