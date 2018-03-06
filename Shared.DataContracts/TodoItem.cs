using System;

namespace Shared.DataContracts
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public Guid TodoListId { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public bool IsActive { get; set; }

    }
}
