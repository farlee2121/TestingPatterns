using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataPrep
{
    public class TodoItemPrep
    {
        ITestDataAccessor dataAccessor;
        TodoListPrep todoListPrep;
        public TodoItemPrep(ITestDataAccessor dataAccessor, TodoListPrep todoListPrep)
        {
            this.dataAccessor = dataAccessor;
            this.todoListPrep = todoListPrep;
        }

        public TodoItem Create()
        {
            throw new NotImplementedException();
        }

        public TodoItem Create(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> CreateManyForList(int count, TodoList todoList)
        {
            throw new NotImplementedException();
        }
    }
}
