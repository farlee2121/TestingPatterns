﻿using Microsoft.EntityFrameworkCore;
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
        IEnumerable<TodoItem> GetTodoItemsForList(Id listId);

        SaveResult<TodoItem> SaveTodoItem(TodoItem todoItem);

        DeleteResult DeleteTodoItem(Id id);
    }
    class TodoItemAccessor : ITodoItemAccessor
    {
        TodoItem_Mapper mapper = new TodoItem_Mapper();

        public DeleteResult DeleteTodoItem(Id id)
        {
            using (TodoContext db = new TodoContext())
            {
                TodoItemDTO todoItemModel = db.TodoItems.FirstOrDefault(ti => ti.Id == id);
                todoItemModel.IsActive = false;

                db.SaveChanges();

                DeleteResult deleteResult = new DeleteResult();

                return deleteResult;
            }
        }

        public IEnumerable<TodoItem> GetTodoItemsForList(Id listId)
        {
            IEnumerable<TodoItem> todoItemList;
            using (TodoContext db = new TodoContext())
            {
                IEnumerable<TodoItemDTO> todoItemModelList = db.TodoItems.Where(ti => ti.TodoListId == listId && ti.IsActive).ToList();
                todoItemList = mapper.ModelListToContractList(todoItemModelList);
            }
            return todoItemList;
        }

        public SaveResult<TodoItem> SaveTodoItem(TodoItem todoItem)
        {
            using (TodoContext db = new TodoContext())
            {
                TodoItemDTO dbModel = mapper.ContractToModel(todoItem);

                db.AddOrUpdate(dbModel);
                db.SaveChanges();

                TodoItem savedTodoItem = mapper.ModelToContract(dbModel);

                SaveResult<TodoItem> saveResult = new SaveResult<TodoItem>(savedTodoItem);
                return saveResult;
            }
        }
    }
}
