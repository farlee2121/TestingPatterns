using Microsoft.EntityFrameworkCore;
using Shared.DatabaseContext.DBOs;
using System;
using System.Collections.Generic;
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

        public TodoContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["TodoContext"].ConnectionString);
            optionsBuilder.UseInMemoryDatabase();
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        ////https://github.com/aspnet/EntityFrameworkCore/issues/4434
        //    // collapse the entity validation errors into the exception message for convenience of debugging
        //    try
        //    {
        //        return base.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        var entityErrorList = ex.EntityValidationErrors
        //                .SelectMany(x => x.ValidationErrors)
        //                .Select(x => x.ErrorMessage);

        //        var entityErrorMessage = string.Join("; ", entityErrorList);

        //        // combine entity errors with original exception
        //        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", entityErrorMessage);

        //        // re-throw the error with the new exception message
        //        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        //    }
        }
    }
}
