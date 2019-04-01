using System;

namespace Shared.DataContracts
{
    public class TodoList
    {
        public Id Id { get; set; }

        public Id UserId { get; set; }

        public string Title { get; set; }
    }
}
