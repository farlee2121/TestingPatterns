using Shared.DatabaseContext.DBOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DatabaseContext
{
    public class TodoContext : DbContext
    {
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<TodoItemDTO> TodoItems { get; set; }
        public DbSet<TodoListDTO> TodoLists { get; set; }

        public TodoContext() : base("TodoDb")
        {
        }
    }
}
