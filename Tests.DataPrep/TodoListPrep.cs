using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataPrep
{
    public class TodoListPrep
    {
        ITestDataAccessor dataAccessor;
        UserPrep userPrep;
        public TodoListPrep(ITestDataAccessor dataAccessor, UserPrep userPrep)
        {
            this.dataAccessor = dataAccessor;
            this.userPrep = userPrep;
        }

        public TodoList Create()
        {
            throw new NotImplementedException();
        }
    }
}
