using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DatabaseContext.DBOs
{
    [Table("TodoItems")]
    public class TodoItemDBO
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid TodoListId { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("TodoListId")]
        public TodoListDBO TodoList { get; set; }

    }
}
