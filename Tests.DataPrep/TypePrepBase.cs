using Bogus;
using Shared.DatabaseContext.DBOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.DataPrep
{
    public class TypePrepBase<T, PersistedType> where T : class where PersistedType : class, DatabaseObjectBase
    {
        protected ITestDataAccessor dataAccessor;
        protected Faker random = new Faker();

        protected MapperBase<T, PersistedType> mapper = new MapperBase<T, PersistedType>();

        public TypePrepBase(ITestDataAccessor dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public virtual T Create()
        {
            Faker<T> faker = new Faker<T>();
            T saved = Create(faker.Generate());
            return saved;
        }

        public virtual T Create(T existing, bool isActive = true)
        {
            PersistedType model = mapper.ContractToModel(existing);
            // handle active state here so I can create inactive items, but leave active flags off of data contracts
            model.IsActive = isActive;

            PersistedType savedModel = dataAccessor.Create(model);
            T savedContract = mapper.ModelToContract(savedModel);

            return savedContract;
        }

    }
}
