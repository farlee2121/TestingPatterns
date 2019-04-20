using Shared.DatabaseContext.DBOs;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataPrep
{
    public class TodoItemPrep : TypePrepBase<TodoItem, TodoItemDTO>
    {
        TodoListPrep todoListPrep;

        public TodoItemPrep(ITestDataAccessor dataAccessor, TodoListPrep todoListPrep) : base (dataAccessor)
        {
            this.todoListPrep = todoListPrep;
        }

        public TodoItem Create(TodoList todoList = null, bool? isComplete = null, bool isPersisted = true)
        {

            TodoList sanitizedTodoList = todoList ?? todoListPrep.Create();
            TodoItem todoItem = new TodoItem()
            {
                TodoListId = sanitizedTodoList.Id,
                Description = random.Lorem.Sentence(),
                IsComplete = isComplete ?? random.PickRandom(true, false),
            };

            if (isPersisted)
            {
                TodoItem savedItem = Create(todoItem);
                return savedItem;
            }
            else
            {
                return todoItem;
            }
        }


        public IEnumerable<TodoItem> CreateManyForList(int count, TodoList todoList)
        {
            List<TodoItem> itemList = new List<TodoItem>();
            for (int i = 0; i < count; i++)
            {
                TodoItem item = Create(todoList);
                itemList.Add(item);
                
            }

            return itemList;
        }
    }
}
