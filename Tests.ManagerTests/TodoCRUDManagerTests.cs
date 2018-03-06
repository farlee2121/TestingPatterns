using System;
using System.Collections.Generic;
using System.Linq;
using DeepEqual.Syntax;
using Managers.LazyCollectionOfAllManagers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.DatabaseContext;
using Shared.DatabaseContext.DBOs;
using Shared.DataContracts;
using Telerik.JustMock.AutoMock;

namespace Tests.ManagerTests
{
    [TestClass]
    public class TodoCRUDManagerTests : ManagerTestBase
    {
        TodoCRUDManager manager;
        MockingContainer<TodoCRUDManager> mockContainer = new MockingContainer<TodoCRUDManager>();

        public override void OnCleanup()
        {
        }

        public override void OnInitialize()
        {
            manager = mockContainer.Instance;
        }

        
    }
}
