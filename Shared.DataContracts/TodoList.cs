using System;

namespace Shared.DataContracts
{
    public class TodoList
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }
    }
}
