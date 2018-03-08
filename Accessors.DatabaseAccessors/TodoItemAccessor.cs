using Shared.DatabaseContext;
using Shared.DatabaseContext.DBOs;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors.DatabaseAccessors
{
    public interface ITodoItemAccessor
    {
        IEnumerable<TodoItem> GetTodoItemsForList(Guid listId);

        SaveResult<TodoItem> SaveTodoItem(TodoItem todoItem);

        DeleteResult DeleteTodoItem(Guid id);
    }
    class TodoItemAccessor : ITodoItemAccessor
    {
        TodoItem_Mapper mapper = new TodoItem_Mapper();

        public DeleteResult DeleteTodoItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetTodoItemsForList(Guid listId)
        {
            IEnumerable<TodoItem> todoItemList;
            using (TodoContext db = new TodoContext())
            {
                IEnumerable<TodoItemDBO> todoItemModelList = db.TodoItems.Where(ti => ti.TodoListId == listId && ti.IsActive).ToList();
                todoItemList = mapper.ModelListToContractList(todoItemModelList);
            }
            return todoItemList;
        }

        public SaveResult<TodoItem> SaveTodoItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
