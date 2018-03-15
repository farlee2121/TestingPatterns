using AutoMapper;
using Shared.DataContracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DatabaseContext.DBOs
{
    [Table("TodoItems")]
    public class TodoItemDTO : DatabaseObjectBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid TodoListId { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("TodoListId")]
        public TodoListDTO TodoList { get; set; }

    }

    public class TodoItem_Mapper : MapperBase<TodoItem, TodoItemDTO>
    {
        public TodoItem_Mapper()
        {
        }
    }
}
