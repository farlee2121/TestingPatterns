using Accessors.DatabaseAccessors;
using NUnit.Framework;
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

        }
    }
}
