using Microsoft.EntityFrameworkCore;
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
    public interface ITodoListAccessor
    {
        TodoList GetTodoList(Id id);

        IEnumerable<TodoList> GetTodoListsForUser(Id userId);

        SaveResult<TodoList> SaveTodoList(TodoList todoList);

        DeleteResult DeleteTodoList(Id id);
    }

    class TodoListAccessor : ITodoListAccessor
    {
        TodoList_Mapper mapper = new TodoList_Mapper();

        public DeleteResult DeleteTodoList(Id id)
        {
            using (TodoContext db = new TodoContext())
            {
                TodoListDTO todoListModel = db.TodoLists.FirstOrDefault(ti => ti.Id == id);
                todoListModel.IsActive = false;

                db.SaveChanges();

                DeleteResult deleteResult = new DeleteResult();

                return deleteResult;
            }
        }

        public TodoList GetTodoList(Id id)
        {
            using (TodoContext db = new TodoContext())
            {
                TodoListDTO listModel = db.TodoLists.FirstOrDefault(tl => tl.Id == id && tl.IsActive);

                TodoList listContract = mapper.ModelToContract(listModel);

                return listContract;
            }
        }

        public IEnumerable<TodoList> GetTodoListsForUser(Id userId)
        {
            IEnumerable<TodoList> todoListContracts;
            using (TodoContext db = new TodoContext())
            {
                IEnumerable<TodoListDTO> listModelList = db.TodoLists.Where(tl => tl.UserId == userId && tl.IsActive).ToList();

                todoListContracts = mapper.ModelListToContractList(listModelList);
            }

            return todoListContracts;
        }

        public SaveResult<TodoList> SaveTodoList(TodoList todoList)
        {
            using (TodoContext db = new TodoContext())
            {
                TodoListDTO dbModel = mapper.ContractToModel(todoList);

                db.AddOrUpdate(dbModel);
                db.SaveChanges();

                TodoList savedTodoItem = mapper.ModelToContract(dbModel);

                SaveResult<TodoList> saveResult = new SaveResult<TodoList>(savedTodoItem);
                return saveResult;
            }
        }
    }
}
