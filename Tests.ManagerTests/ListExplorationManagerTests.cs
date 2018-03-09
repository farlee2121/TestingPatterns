using System;
using System.Collections.Generic;
using Managers.LazyCollectionOfAllManagers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.DataContracts;
using Telerik.JustMock.AutoMock;

namespace Tests.ManagerTests
{
    [TestClass]
    public class ListExplorationManagerTests : ManagerTestBase
    {
        MockingContainer<ListExplorationManager> mockContainer;
        ListExplorationManager manager;

        public override void OnInitialize()
        {
            MockingContainer<ListExplorationManager> mockContainer = new MockingContainer<ListExplorationManager>();
            ListExplorationManager manager = mockContainer.Instance;
        }

        public override void OnCleanup()
        {
        }

        

        [TestMethod]
        public void GetUserStats()
        {
            Assert.Inconclusive("Untested: untested as an example of code marking");
        }

        
    }
}
