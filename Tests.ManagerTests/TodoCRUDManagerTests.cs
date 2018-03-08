﻿using System;
using System.Collections.Generic;
using System.Linq;
using Accessors.DatabaseAccessors;
using DeepEqual.Syntax;
using Managers.LazyCollectionOfAllManagers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.DatabaseContext;
using Shared.DatabaseContext.DBOs;
using Shared.DataContracts;
using Telerik.JustMock.AutoMock;
using Tests.DataPrep;

namespace Tests.ManagerTests
{
    [TestClass]
    public class TodoCRUDManagerTests : ManagerTestBase
    {
        TodoCRUDManager manager;
        MockingContainer<TodoCRUDManager> mockContainer = new MockingContainer<TodoCRUDManager>();

        public TodoCRUDManagerTests() { }
        internal TodoCRUDManagerTests(TodoCRUDManager manager = null, TodoDataPrep dataPrep = null)
        {
            // this constructor allows for integration test reuse
            this.manager = manager;
            this.dataPrep = dataPrep ?? base.dataPrep;
        }

        public override void OnCleanup()
        {
        }

        public override void OnInitialize()
        {
            if(manager == null)
            {
                manager = mockContainer.Instance;
            }
        }

        [TestMethod]
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
