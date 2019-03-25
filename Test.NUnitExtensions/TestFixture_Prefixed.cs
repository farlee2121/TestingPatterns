using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            // TODO: the name set here will still get overridden by a test case. Figure out how to
            // build on top of the test case name instead
            // This possibly implies that cases are built after the fixture methods run
            // https://groups.google.com/forum/#!topic/nunit-discuss/PT0NQaL7AMg
            NUnitTestFixtureBuilder b = new NUnitTestFixtureBuilder();
            TestSuite testSuite = b.BuildFrom(typeInfo, new NoFilter());
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

    class NoFilter : IPreFilter
    {
        //ref: https://github.com/nunit/nunit/issues/3050
        public bool IsMatch(Type type)
        {
            return true;
        }

        public bool IsMatch(Type type, MethodInfo method)
        {
            return true;
        }
    }
}
