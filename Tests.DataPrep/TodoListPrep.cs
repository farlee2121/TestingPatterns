using Shared.DatabaseContext.DBOs;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataPrep
{
    public class TodoListPrep : TypePrepBase<TodoList, TodoListDTO>
    {
        UserPrep userPrep;
        public TodoListPrep(ITestDataAccessor dataAccessor, UserPrep userPrep) : base(dataAccessor)
        {
            this.userPrep = userPrep;
        }

        public TodoList Create(User user = null)
        {
            User sanitizedUser = user ?? userPrep.Create();
            TodoList todoList = new TodoList()
            {
                UserId = sanitizedUser.Id,
                Title = random.Lorem.Sentence(),
            };

            TodoList savedList = Create(todoList);

            return savedList;
        }

        public IEnumerable<TodoList> CreateManyForUser(int count, User user)
        {
            List<TodoList> todoLists = new List<TodoList>();
            for (int i = 0; i < count; i++)
            {
                TodoList todoList = Create(user);
                todoLists.Add(todoList);
            }

            return todoLists;
        }
    }
}
