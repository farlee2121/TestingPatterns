using System;
using System.Collections.Generic;
using Managers.LazyCollectionOfAllManagers;
using NUnit.Framework;
using Shared.DataContracts;
using Telerik.JustMock.AutoMock;
using Test.NUnitExtensions;

namespace Tests.ManagerTests
{
    [TestFixture_Prefixed(typeof(ListExplorationManager))]
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

        

        [Test]
        public void GetUserStats()
        {
            Assert.Inconclusive("Untested: untested as an example of code marking. These markers are usually reserved for legacy code or unverifiable external dependencies");
            User user = dataPrep.Users.Create();
            manager.GetUserStats(user.Id);
        }

        [Test]
        public void GetUserLists()
        {
            Assert.Inconclusive("Untested: untested as an example of code marking. These markers are usually reserved for legacy code or unverifiable external dependencies");
            User user = dataPrep.Users.Create();
            manager.GetUserLists(user.Id);
        }
    }
}
