using Shared.DatabaseContext.DBOs;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataPrep
{

    public class UserPrep
    {
        Bogus.Faker random = new Bogus.Faker();

        ITestDataAccessor dataAccessor;
        public UserPrep(ITestDataAccessor dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public User Create()
        {
            User user = new User()
            {
                Name = random.Name.FullName(),
            };
            User savedUser = Create(user);

            return savedUser;
        }

        public User Create(User user)
        {
            // NOTE/TODO: feels like there should be a good way to encapsulate this so most data prep classes don't have to write it
            User_Mapper mapper = new User_Mapper();
            UserDBO model = mapper.ContractToModel(user);

            UserDBO savedModel = dataAccessor.Create(model);
            User savedContract = mapper.ModelToContract(savedModel);

            return savedContract;
        }

    }
}
