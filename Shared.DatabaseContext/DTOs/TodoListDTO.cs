using Shared.DataContracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DatabaseContext.DBOs
{
    [Table("TodoLists")]
    public class TodoListDTO : DatabaseObjectBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        [ForeignKey("UserId")]
        public UserDTO User { get; set; }
        public bool IsActive { get; set; }
    }

    public class TodoList_Mapper : MapperBase<TodoList, TodoListDTO>
    {

    }
}
