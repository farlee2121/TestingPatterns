//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shared.DatabaseContext;
using System.Transactions;
using Tests.DataPrep;

namespace Tests.ManagerTests
{
    public abstract class ManagerTestBase
    {
        protected TodoDataPrep dataPrep = new TodoDataPrep(false);
        TransactionScope _transactionScope;

        public abstract void OnInitialize();
        [SetUp]
        public virtual void TestInitialize()
        {
            TodoContext database = new TodoContext();
            database.Database.CreateIfNotExists();
            // transactionScope causes db changes to be rolled back at end of test
            _transactionScope = new TransactionScope();

            OnInitialize();
        }


        public abstract void OnCleanup();
        [TearDown]
        public virtual void TestCleanup()
        {
            OnCleanup();
            _transactionScope.Dispose();
        }

    }
}
