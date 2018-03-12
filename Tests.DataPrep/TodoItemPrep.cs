using Shared.DatabaseContext.DBOs;
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

        Bogus.Faker random = new Bogus.Faker();

        public TodoItemPrep(ITestDataAccessor dataAccessor, TodoListPrep todoListPrep)
        {
            this.dataAccessor = dataAccessor;
            this.todoListPrep = todoListPrep;
        }

        public TodoItem Create(TodoList todoList = null, bool? isComplete = null)
        {

            TodoList sanitizedTodoList = todoList ?? todoListPrep.Create();
            TodoItem todoItem = new TodoItem()
            {
                TodoListId = sanitizedTodoList.Id,
                Description = random.Lorem.Sentence(),
                IsComplete = isComplete ?? random.PickRandom(true, false),
            };

            TodoItem savedItem = Create(todoItem);

            return savedItem;
        }

        public TodoItem Create(TodoItem todoItem, bool isActive = true)
        {
            TodoItem_Mapper mapper = new TodoItem_Mapper();
            TodoItemDBO model = mapper.ContractToModel(todoItem);
            // handle active state here so I can create inactive items, but leave active flags off of data contracts
            model.IsActive = isActive;

            TodoItemDBO savedModel = dataAccessor.Create(model);
            TodoItem savedContract = mapper.ModelToContract(savedModel);

            return savedContract;
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
