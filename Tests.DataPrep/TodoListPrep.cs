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

        public TodoList Create(TodoList todoList)
        {
            TodoList_Mapper mapper = new TodoList_Mapper();
            TodoListDBO model = mapper.ContractToModel(todoList);

            TodoListDBO savedModel = dataAccessor.Create(model);
            TodoList savedContract = mapper.ModelToContract(savedModel);

            return savedContract;
        }
    }
}
