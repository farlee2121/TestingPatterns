﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shared.DatabaseContext;
using System.Transactions;
using Tests.DataPrep;

namespace Tests.AccessorTests
{
    public abstract class AccessorTestBase
    {
        protected TodoDataPrep dataPrep = new TodoDataPrep(true);

        protected TransactionScope _transactionScope;
        [SetUp]
        public virtual void TestInitialize()
        {
            TodoContext database = new TodoContext();
            database.Database.CreateIfNotExists();
            // transactionScope causes db changes to be rolled back at end of test
            _transactionScope = new TransactionScope();

            OnInitialize();
        }

        public abstract void OnInitialize();

        [TearDown]
        public virtual void TestCleanup()
        {
            _transactionScope.Dispose();
        }
    }
}
