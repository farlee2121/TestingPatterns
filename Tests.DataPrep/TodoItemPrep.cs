﻿using Shared.DatabaseContext.DBOs;
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

        public TodoItem Create(TodoList todoList = null)
        {

            TodoList sanitizedTodoList = todoList ?? todoListPrep.Create();
            TodoItem todoItem = new TodoItem()
            {
                TodoListId = sanitizedTodoList.Id,
                Description = random.Lorem.Sentence(),
                IsComplete = random.PickRandom(true, false),
                IsActive = true
            };

            TodoItem savedItem = Create(todoItem);

            return savedItem;
        }

        public TodoItem Create(TodoItem todoItem)
        {
            TodoItem_Mapper mapper = new TodoItem_Mapper();
            TodoItemDBO model = mapper.ContractToModel(todoItem);

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
