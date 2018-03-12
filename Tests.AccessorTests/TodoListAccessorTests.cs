using Accessors.DatabaseAccessors;
using DeepEqual.Syntax;
using NUnit.Framework;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.NUnitExtensions;

namespace Tests.AccessorTests
{
    [TestFixture_Prefixed(typeof(TodoListAccessor))]
    public class TodoListAccessorTests : AccessorTestBase
    {
        TodoListAccessor accessor;
        public override void OnInitialize()
        {
            accessor = new TodoListAccessor();
        }

        [Test]
        public void GetTodoList()
        {
            TodoList expectedTodoList = dataPrep.TodoLists.Create();

            TodoList actualTodoList = accessor.GetTodoList(expectedTodoList.Id);

            expectedTodoList.ShouldDeepEqual(actualTodoList);
        }

        [Test]
        public void GetTodoListsForUser()
        {
            User user = dataPrep.Users.Create();
            IEnumerable<TodoList> expectedTodoListList = dataPrep.TodoLists.CreateManyForUser(5, user);

            IEnumerable<TodoList> actualTodoListList = accessor.GetTodoListsForUser(user.Id);

            expectedTodoListList.ShouldDeepEqual(actualTodoListList);
        }

        [Test]
        public void SaveTodoList_Update()
        {
            TodoList expectedTodoList = dataPrep.TodoLists.Create();
            expectedTodoList.Title = Guid.NewGuid().ToString();

            SaveResult<TodoList> saveResult = accessor.SaveTodoList(expectedTodoList);
            TodoList actualTodoList = saveResult.Result;

            Assert.IsTrue(saveResult.Success);
            expectedTodoList.ShouldDeepEqual(actualTodoList);
        }

        [Test]
        public void SaveTodoList_Create()
        {
            User user = dataPrep.Users.Create();
            TodoList newTodoList = new TodoList()
            {
                UserId = user.Id,
                Title = Guid.NewGuid().ToString(),
            };

            SaveResult<TodoList> saveResult = accessor.SaveTodoList(newTodoList);
            TodoList actualTodoList = saveResult.Result;

            Assert.IsNotNull(actualTodoList.Id);
            newTodoList.WithDeepEqual(actualTodoList).IgnoreSourceProperty(tl => tl.Id);
        }

        [Test]
        public void DeleteTodoList()
        {
            TodoList expectedTodoList = dataPrep.TodoLists.Create();

            // act
            DeleteResult deleteResult = accessor.DeleteTodoList(expectedTodoList.Id);

            //assert
            Assert.IsTrue(deleteResult.Success);

            TodoList retrievableTodoList = accessor.GetTodoList(expectedTodoList.Id);
            Assert.IsNull(retrievableTodoList);
        }
    }
}
