using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.DataPrep;

namespace Tests.ManagerTests
{
    public abstract class ManagerTestBase
    {
        protected TodoDataPrep dataPrep = new TodoDataPrep(false);

        public abstract void OnInitialize();
        [TestInitialize]
        public virtual void TestInitialize()
        {
            OnInitialize();
        }


        public abstract void OnCleanup();
        [TestCleanup]
        public virtual void TestCleanup()
        {
            OnCleanup();
        }

    }
}
