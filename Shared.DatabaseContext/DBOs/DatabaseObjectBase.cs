using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DatabaseContext.DBOs
{
    public interface DatabaseObjectBase
    {
        Guid Id { get; set; }

        bool IsActive { get; set; }
    }
}
