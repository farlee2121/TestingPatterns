using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors.DatabaseAccessors
{
    public interface ITodoListAccessor
    {
        TodoList GetTodoList(Guid id);

        IEnumerable<TodoList> GetTodoListsForUser(Guid userId);

        SaveResult<TodoList> SaveTodoList(TodoList todoList);

        DeleteResult DeleteTodoList(Guid id);
    }

    class TodoListAccessor : ITodoListAccessor
    {
        public DeleteResult DeleteTodoList(Guid id)
        {
            throw new NotImplementedException();
        }

        public TodoList GetTodoList(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoList> GetTodoListsForUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public SaveResult<TodoList> SaveTodoList(TodoList todoList)
        {
            throw new NotImplementedException();
        }
    }
}
