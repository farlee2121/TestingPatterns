using Shared.DatabaseContext.DBOs;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataPrep
{

    public class UserPrep : TypePrepBase<User, UserDTO>
    {
        public UserPrep(ITestDataAccessor dataAccessor) : base(dataAccessor)
        {
        }
    }
}
