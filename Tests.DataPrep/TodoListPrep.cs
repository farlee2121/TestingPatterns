using Shared.DatabaseContext.DBOs;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataPrep
{
    public class TodoListPrep
    {
        Bogus.Faker random = new Bogus.Faker();

        ITestDataAccessor dataAccessor;
        UserPrep userPrep;
        public TodoListPrep(ITestDataAccessor dataAccessor, UserPrep userPrep)
        {
            this.dataAccessor = dataAccessor;
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

        public TodoList Create(TodoList todoList, bool isActive = true)
        {
            TodoList_Mapper mapper = new TodoList_Mapper();
            TodoListDBO model = mapper.ContractToModel(todoList);
            model.IsActive = isActive;

            TodoListDBO savedModel = dataAccessor.Create(model);
            TodoList savedContract = mapper.ModelToContract(savedModel);

            return savedContract;
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
