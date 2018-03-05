using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataContracts
{
    public class UserAccountStats
    {
        public int TodoListCount { get; set; }

        public int UncompletedItems { get; set; }
    }
}
