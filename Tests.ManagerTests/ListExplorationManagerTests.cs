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

        //[TestMethod]
        //public void GetUserStats_UglyAndLong()
        //{
        //    //Create User
        //    UserDBO user = new UserDBO()
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Bob",
        //    };


        //    //Create Todo lists

        //    //TODO: turn this into dataprep.CreateTodoListsWithItems
        //    List<TodoListDBO> expectedLists = new List<TodoListDBO>();
        //    int expectedListCount = 5;
        //    for (int i = 0; i < expectedListCount; i++)
        //    {
        //        TodoListDBO expectedList = new TodoListDBO() {
        //            Id = Guid.NewGuid(),
        //            UserId = user.Id,
        //            Title = Guid.NewGuid().ToString(),
        //        };
        //    }

        //    //Create items, complete and incomplete
        //    foreach (TodoList expectedList in expectedLists)
        //    {

        //    }

        //    UserAccountStats stats = manager.GetUserStats(user.Id);

        //    Assert.AreEqual(expectedListCount, stats.TodoListCount); 
            

        //}

        [TestMethod]
        public void GetUserStats_Final()
        {
            //Create User

            //Create Todo lists

            //Create items, complete and incomplete

            

        }

        [TestMethod]
        public void GetUserStats_Integration()
        {
            //Create User

            //Create Todo lists

            //Create items, complete and incomplete



        }

        
    }
}
