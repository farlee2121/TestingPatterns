using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DatabaseContext.DBOs
{
    [Table("TodoLists")]
    public class TodoListDBO
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        [ForeignKey("UserId")]
        public UserDBO User { get; set; }
    }
}
