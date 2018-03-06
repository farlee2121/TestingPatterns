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

        [TestMethod]
        public void GetTodoItems_Ugly()
        {
            // arrange
            using (TodoContext db = new TodoContext())
            {
                UserDBO user = new UserDBO()
                {
                    Name = "Bob",
                };
                db.Users.Add(user);
                db.SaveChanges();

                TodoListDBO expectedList = new TodoListDBO()
                {
                    UserId = user.Id,
                    Title = Guid.NewGuid().ToString(),
                };
                db.TodoLists.Add(expectedList);
                db.SaveChanges();

                List<TodoItemDBO> expectedItemList = new List<TodoItemDBO>();
                int expectedTodoItemCount = 5;
                for (int i = 0; i < expectedTodoItemCount; i++)
                {
                    TodoItemDBO expectedItem = new TodoItemDBO()
                    {
                        TodoListId = expectedList.Id,
                        Description = Guid.NewGuid().ToString(),
                        IsActive = true,
                        IsComplete = false,
                    };
                    expectedItemList.Add(expectedItem);
                }
                db.TodoItems.AddRange(expectedItemList);
                db.SaveChanges();



                // act
                IEnumerable<TodoItem> actualItemList = manager.GetTodoItems(expectedList.Id);

                //assert

                Assert.AreEqual(expectedItemList.Count, actualItemList.Count());
                foreach (TodoItem actualTodo in actualItemList)
                {
                    TodoItemDBO expectedTodo = expectedItemList.FirstOrDefault(ti => ti.Id == actualTodo.Id);
                    Assert.AreEqual(expectedTodo.Description, actualTodo.Description);
                    Assert.AreEqual(expectedTodo.IsActive, actualTodo.IsActive);
                    Assert.AreEqual(expectedTodo.IsComplete, actualTodo.IsComplete);
                }

                db.TodoItems.RemoveRange(expectedItemList);
                db.TodoLists.Remove(expectedList);
                db.Users.Remove(user);
                db.SaveChanges();
            }

        }

        [TestMethod]
        public void GetTodoItems_Final()
        {
            // arrange
            TodoList todoList = dataPrep.TodoLists.Create();
            int expectedItemCount = 5;
            IEnumerable<TodoItem> expectedItemList = dataPrep.TodoItems.CreateManyForList(expectedItemCount, todoList);

            // act
            IEnumerable<TodoItem> actualItemList = manager.GetTodoItems(todoList.Id);

            //assert
            expectedItemList.ShouldDeepEqual(actualItemList);
        }
    }
}
