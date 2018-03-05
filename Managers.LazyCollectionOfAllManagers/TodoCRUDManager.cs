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
        void GetTodoList(Guid id);

        IEnumerable<TodoItem> GetTodoItems(Guid listId);

        void SaveTodoItem();

        void SaveTodoList();
    }
    internal class TodoCRUDManager : ITodoCRUDManager
    {
        public IEnumerable<TodoItem> GetTodoItems(Guid listId)
        {
            throw new NotImplementedException();
        }

        public void GetTodoList(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveTodoItem()
        {
            throw new NotImplementedException();
        }

        public void SaveTodoList()
        {
            throw new NotImplementedException();
        }
    }
}
