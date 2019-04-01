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
        UserAccountStats GetUserStats(Id userId);

        IEnumerable<TodoList> GetUserLists(Id userId);
       
    }



    internal class ListExplorationManager : IListExplorationManager
    {

        public IEnumerable<TodoList> GetUserLists(Id userId)
        {
            throw new NotImplementedException();
        }

        public UserAccountStats GetUserStats(Id userId)
        {
            throw new NotImplementedException();
        }
    }
}
