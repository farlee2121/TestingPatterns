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

        TodoCRUDManagerTests unitTests = new TodoCRUDManagerTests();
        TodoDataPrep dataPrep;
        TodoCRUDManager manager;

        [TestInitialize]
        public void OnClassInit()
        {
            // Implicit self binding allows us to get a concrete class with fulfilled dependencies
            // https://github.com/ninject/ninject/wiki/dependency-injection-with-ninject
            Ninject.IKernel kernel = DependencyInjectionLoader.BuildKernel();
            manager = kernel.Get<TodoCRUDManager>();

            dataPrep = new TodoDataPrep(true);

            unitTests = new TodoCRUDManagerTests(manager, dataPrep);
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
