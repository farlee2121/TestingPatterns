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
        public DbSet<UserDBO> Users { get; set; }
        public DbSet<TodoItemDBO> TodoItems { get; set; }
        public DbSet<TodoListDBO> TodoLists { get; set; }

        public TodoContext() : base("TodoDb")
        {
        }
    }
}
