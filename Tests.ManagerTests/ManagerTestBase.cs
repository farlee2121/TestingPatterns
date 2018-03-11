//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Tests.DataPrep;

namespace Tests.ManagerTests
{
    public abstract class ManagerTestBase
    {
        protected TodoDataPrep dataPrep = new TodoDataPrep(false);

        public abstract void OnInitialize();
        [SetUp]
        public virtual void TestInitialize()
        {
            OnInitialize();
        }


        public abstract void OnCleanup();
        [TearDown]
        public virtual void TestCleanup()
        {
            OnCleanup();
        }

    }
}
