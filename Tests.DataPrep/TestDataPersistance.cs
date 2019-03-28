using Shared.DatabaseContext;

namespace Tests.DataPrep
{
    public interface ITestDataAccessor
    {

        // should probably make this more constrained to just expected data model types,
        // but that would require refactoring all data models to implement an interface, which i'm not confident the agilx code can handle
        T Create<T>(T entity) where T : class;

        void EnsureDatastore();
    }


    class ApplicationDbTestDataAccessor : ITestDataAccessor
    {

        public T Create<T>(T entity) where T : class
        {

            using (TodoContext db = new TodoContext())
            {

                db.Set<T>().Add(entity);
                db.SaveChanges();

                return entity;
            }


        }

        public void EnsureDatastore()
        {
            TodoContext database = new TodoContext();
            database.Database.EnsureCreated();
        }
    }

    class NoPersistanceTestDataAccessor : ITestDataAccessor
    {
        public T Create<T>(T entity) where T : class
        {
            // do I need to set an Id? If so, i'll need a base class or interface for db objects

            return entity;
        }

        public void EnsureDatastore()
        {
            // no action needed
        }
    }

}
