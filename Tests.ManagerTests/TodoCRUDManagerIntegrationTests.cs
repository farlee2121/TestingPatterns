using Accessors.DatabaseAccessors;
using Managers.LazyCollectionOfAllManagers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Shared.DependencyInjectionKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock.AutoMock.Ninject;
using Tests.DataPrep;

namespace Tests.ManagerTests
{
    [TestClass]
    public class TodoCRUDManagerIntegrationTests
    {
        // NOTE: Reuse of integration tests can also be done with inheritance
        // However, it causes duplicate names and both integration and 
        // unit runs will be directed to the inherited class, making it unclear which test is which

        // The downside of this method is that it requires manual maintenance 
        // Could explore the possibility of reflecting over a class's methods and raising an exception
        // that highlights the failed method with a reason

        // Another alternative would be looking at generating a code file at build time with a plugin
        // It would be a pretty simple plugin with simple emitted code

        TodoCRUDManagerTests unitTests = new TodoCRUDManagerTests();

        [TestInitialize]
        public void OnInit()
        {   
            unitTests = new TodoCRUDManagerTests(true);
        }

        [TestMethod]
        public void GetTodoItems_Integration()
        {
            // Want to test this is going to the DB? Try debugging and stepping through
            // or setting dataprep persistance to false
            unitTests.GetTodoItems();
        }

    }

    [TestClass]
    public class TodoCRUDManagerIntegrationWithInheritanceTests : TodoCRUDManagerTests
    {
        //NOTE: This does not allow you to create distinct names for clarity and both integration and 
        // unit runs will be directed to the inherited class, making it unclear which test is which

        public TodoCRUDManagerIntegrationWithInheritanceTests(): base(true)
        {
        }

    }

}
