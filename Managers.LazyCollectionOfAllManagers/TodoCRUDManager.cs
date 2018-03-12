using Accessors.DatabaseAccessors;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.LazyCollectionOfAllManagers
{
    public interface ITodoCRUDManager
    {
        TodoList GetTodoList(Guid id);

        IEnumerable<TodoItem> GetTodoItems(Guid listId);

        SaveResult<TodoItem> SaveTodoItem(TodoItem todoItem);

        SaveResult<TodoList> SaveTodoList(TodoList todoList);
    }
    internal class TodoCRUDManager : ITodoCRUDManager
    {
        ITodoListAccessor todoListAccessor;
        ITodoItemAccessor todoItemAccessor;
        public TodoCRUDManager(ITodoListAccessor todoListAccessor, ITodoItemAccessor todoItemAccessor)
        {
            this.todoListAccessor = todoListAccessor;
            this.todoItemAccessor = todoItemAccessor;
        }

        //
        // NOTE: These methods are currently all pass throughs because of the simple structure
        // However, it is still worth having the manager to organize the functionality needed
        // for this 'flow' in the application
        //

        public IEnumerable<TodoItem> GetTodoItems(Guid listId)
        {
            return todoItemAccessor.GetTodoItemsForList(listId);
        }

        public TodoList GetTodoList(Guid id)
        {
            return todoListAccessor.GetTodoList(id);
        }

        public SaveResult<TodoItem> SaveTodoItem(TodoItem todoItem)
        {
            return todoItemAccessor.SaveTodoItem(todoItem);
        }

        public SaveResult<TodoList> SaveTodoList(TodoList todoList)
        {
            return todoListAccessor.SaveTodoList(todoList);
        }
    }
}
