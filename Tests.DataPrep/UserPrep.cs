using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataPrep
{
    public class UserPrep
    {
        ITestDataAccessor dataAccessor;
        public UserPrep(ITestDataAccessor dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public User Create()
        {
            //User user = new User()
            //{
            //    Id = ,
            //    Name =,
            //};
            throw new NotImplementedException();
        }

    }
}
