using System;

namespace Shared.DataContracts
{
    public class TodoItem
    {
        public Id Id { get; set; }

        public Id TodoListId { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }

    }
}
