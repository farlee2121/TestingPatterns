using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NUnitExtensions
{
    public class TestFixture_PrefixedAttribute : TestFixtureAttribute, IFixtureBuilder
    {
        string _prefix;

        public TestFixture_PrefixedAttribute(Type subjectType, params object[] arguments) : base(arguments)
        {
            _prefix = subjectType.Name;
        }

        public TestFixture_PrefixedAttribute(string prefix, params object[] arguments) : base(arguments)
        {
            this._prefix = prefix;
        }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
        {
            NUnitTestFixtureBuilder b = new NUnitTestFixtureBuilder();
            TestSuite testSuite = b.BuildFrom(typeInfo, this);
            foreach (NUnit.Framework.Internal.Test t in testSuite.Tests)
            {
                t.Name = $"{_prefix}_{t.Name}";
            }
            yield return testSuite;
        }
    }

    //public class Test_MethodPrefixAttribute : NUnitAttribute, ISimpleTestBuilder
    //{



    //    // this actually works to change the test name, but it would have to be on every test
    //    TestMethod ISimpleTestBuilder.BuildFrom(IMethodInfo method, NUnit.Framework.Internal.Test suite)
    //    {
    //        TestMethod testMethod = new TestMethod(method, suite);
    //        testMethod.Name = $"{testMethod.ClassName}_{testMethod.MethodName}";

    //        return testMethod;
    //    }
    //}
}
