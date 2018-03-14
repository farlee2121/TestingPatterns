using Shared.DatabaseContext;
using Shared.DatabaseContext.DBOs;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        TodoList_Mapper mapper = new TodoList_Mapper();

        public DeleteResult DeleteTodoList(Guid id)
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

        public TodoList GetTodoList(Guid id)
        {
            using (TodoContext db = new TodoContext())
            {
                TodoListDTO listModel = db.TodoLists.FirstOrDefault(tl => tl.Id == id && tl.IsActive);

                TodoList listContract = mapper.ModelToContract(listModel);

                return listContract;
            }
        }

        public IEnumerable<TodoList> GetTodoListsForUser(Guid userId)
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

                if (todoList.Id == DataConstants.DefaultId)
                {
                    db.TodoLists.Add(dbModel);
                }
                else
                {
                    db.TodoLists.Attach(dbModel);
                    db.Entry(dbModel).State = EntityState.Modified;
                }
                db.SaveChanges();

                TodoList savedTodoItem = mapper.ModelToContract(dbModel);

                SaveResult<TodoList> saveResult = new SaveResult<TodoList>(savedTodoItem);
                return saveResult;
            }
        }
    }
}
