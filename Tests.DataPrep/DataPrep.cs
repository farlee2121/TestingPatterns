
namespace Tests.DataPrep
{
    public class TodoDataPrep
    {
        ITestDataAccessor dataPersistance;
        

        public UserPrep Users { get; set; }
        public TodoListPrep TodoLists { get; set; }
        public TodoItemPrep TodoItems { get; set; }

        public TodoDataPrep(bool shouldPersistData)
        {
            if (shouldPersistData)
            {
                dataPersistance = new ApplicationDbTestDataAccessor();
            }
            else
            {
                dataPersistance = new NoPersistanceTestDataAccessor();
            }

            Users = new UserPrep(dataPersistance);
            TodoLists = new TodoListPrep(dataPersistance, Users);
            TodoItems = new TodoItemPrep(dataPersistance, TodoLists);
        }

        public void EnsureDatastore()
        {
            dataPersistance.EnsureDatastore();
        }
    }
}
