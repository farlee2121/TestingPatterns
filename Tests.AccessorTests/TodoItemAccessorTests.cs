using System;
using System.Collections.Generic;
using System.Linq;
using Accessors.DatabaseAccessors;
using DeepEqual;
using DeepEqual.Syntax;
using NUnit.Framework;
using Shared.DatabaseContext;
using Shared.DatabaseContext.DBOs;
using Shared.DataContracts;
using Test.NUnitExtensions;

namespace Tests.AccessorTests
{
    [TestFixture_Prefixed(typeof(TodoItemAccessor))]
    public class TodoItemAccessorTests : AccessorTestBase
    {
        TodoItemAccessor accessor;
        public override void OnInitialize()
        {
            accessor = new TodoItemAccessor();
        }

        [Test]
        public void GetTodoItems_Ugly()
        {

            // arrange
            using (TodoContext db = new TodoContext())
            {
                UserDTO user = new UserDTO()
                {
                    Name = "Bob",
                };
                db.Users.Add(user);
                db.SaveChanges();

                TodoListDTO expectedList = new TodoListDTO()
                {
                    UserId = user.Id,
                    Title = Guid.NewGuid().ToString(),
                };
                db.TodoLists.Add(expectedList);
                db.SaveChanges();

                List<TodoItemDTO> expectedItemList = new List<TodoItemDTO>();
                int expectedTodoItemCount = 5;
                for (int i = 0; i < expectedTodoItemCount; i++)
                {
                    TodoItemDTO expectedItem = new TodoItemDTO()
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
                IEnumerable<TodoItem> actualItemList = accessor.GetTodoItemsForList(new Id(expectedList.Id));

                //assert
                Assert.AreEqual(expectedItemList.Count, actualItemList.Count());
                foreach (TodoItem actualTodo in actualItemList)
                {
                    TodoItemDTO expectedTodo = expectedItemList.FirstOrDefault(ti => ti.Id == actualTodo.Id);
                    Assert.AreEqual((Id)expectedTodo.TodoListId, actualTodo.TodoListId);
                    Assert.AreEqual(expectedTodo.Description, actualTodo.Description);
                    Assert.AreEqual(expectedTodo.IsComplete, actualTodo.IsComplete);
                }

                db.TodoItems.RemoveRange(expectedItemList);
                db.TodoLists.Remove(expectedList);
                db.Users.Remove(user);
                db.SaveChanges();
            }

        }

        [Test]
        public void GetTodoItems_Final()
        {
            // arrange
            TodoList todoList = dataPrep.TodoLists.Create();
            int expectedItemCount = 5;
            IEnumerable<TodoItem> expectedItemList = dataPrep.TodoItems.CreateManyForList(expectedItemCount, todoList);

            // act
            IEnumerable<TodoItem> actualItemList = accessor.GetTodoItemsForList(todoList.Id);

            //assert
            expectedItemList.WithDeepEqual(actualItemList);
        }

        [Test]
        public void SaveTodoItem_Update()
        {
            // arrange
            TodoItem expectedTodoItem = dataPrep.TodoItems.Create();
            expectedTodoItem.Description = Guid.NewGuid().ToString();

            // act
            SaveResult<TodoItem> saveResult = accessor.SaveTodoItem(expectedTodoItem);
            TodoItem actualTodoItem = saveResult.Result;

            //assert
            Assert.IsTrue(saveResult.Success);
            expectedTodoItem.ShouldDeepEqual(actualTodoItem);
        }

        [Test]
        public void SaveTodoItem_Create()
        {
            // arrange
            TodoList parentList = dataPrep.TodoLists.Create();
            TodoItem expectedTodoItem = new TodoItem()
            {
                TodoListId = parentList.Id,
                Description = Guid.NewGuid().ToString(),
                IsComplete = false,
            };

            // act
            SaveResult<TodoItem> saveResult = accessor.SaveTodoItem(expectedTodoItem);
            TodoItem actualTodoItem = saveResult.Result;

            //assert
            Assert.IsTrue(saveResult.Success);
            Assert.IsNotNull(actualTodoItem.Id);
            expectedTodoItem.WithDeepEqual(actualTodoItem).IgnoreSourceProperty((ti) =>ti.Id);
        }

        [Test]
        public void DeleteTodoItem()
        {
            // arrange
            TodoItem expectedTodoItem = dataPrep.TodoItems.Create();

            // act
            DeleteResult deleteResult = accessor.DeleteTodoItem(expectedTodoItem.Id);

            //assert
            Assert.IsTrue(deleteResult.Success);

            IEnumerable<TodoItem> retrievableItemList = accessor.GetTodoItemsForList(expectedTodoItem.TodoListId);
            Assert.IsNull(retrievableItemList.FirstOrDefault(ti => ti.Id == expectedTodoItem.Id));
        }

    }
}
