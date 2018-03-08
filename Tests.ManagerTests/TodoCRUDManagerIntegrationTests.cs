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
        //NOTE: Reuse of integration tests can also be done with inheritance
        //However, it causes duplicate names and, if you want to keep your
        //implementations private, it requires c# 7.2 for the private protected access modifier
        // Though, I do suppose that you could pass in integration boolean

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
}
