using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.LazyCollectionOfAllManagers
{
    public interface IListExplorationManager
    {
        UserAccountStats GetUserStats(Guid userId);

        IEnumerable<TodoList> GetUserLists(Guid userId);
       
    }



    internal class ListExplorationManager : IListExplorationManager
    {

        public IEnumerable<TodoList> GetUserLists(Guid userId)
        {
            throw new NotImplementedException();
        }

        public UserAccountStats GetUserStats(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
