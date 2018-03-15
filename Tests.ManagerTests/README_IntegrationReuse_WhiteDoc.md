# Integration Reuse WhiteDoc (discovery process)

TL;DR; Discovered that NUnit is much more powerful than MSTest

I started out using MSTest. Integration tests could be reused in several ways

1. Creating a second class, instantiating the unit test class with a full DI configuration and dataprep set to persist.
Then create a test method that calls into each method on the unit test class you want to reuse
- Pros: clear names and differentiation in the test runner. Can pick and choose methods to reuse.
- cons: lots of manual maintenence
2.  Inherit from the original test class, modifying the constructor to specify integration mode
-Pros: No additional changes when test names are added/removed/renamed
-Cons: it causes duplicate names and both integration and unit runs will be directed to the inherited class, making it unclear which test is which

3. Reflecting over a class's methods and raising an exception that highlights the failed method with a reason
 - Cons: still collapses test runs in test explorer. Reflection is slow

4. Generating a code file at build time with a plugin. It would be a pretty simple plugin with simple emitted code
- Cons: have to write and run additional code as well as install an extension

5. Try extending TestMethod or TestClass to run tests twice

Alternative #5 led me to explore extensibility in MSTest. In short, it is kinda limited and does not let you set the test name.
How to extend MSTest here
- https://blogs.msdn.microsoft.com/devops/2017/07/18/extending-mstest-v2/
- https://github.com/Microsoft/testfx-docs/blob/master/RFCs/003-Customize-Running-Tests.md

However, NUnit can handle runs with different parameters out of the box. It has much more powerful functionality and extensibility. 

NOTE: you can run MSTest and NUnit side by side, which makes it very easy to transition progressively

The question is now how to generate differentiated names in the test runner with NUnit.
- https://www.red-gate.com/simple-talk/dotnet/net-tools/testing-times-ahead-extending-nunit/
- https://github.com/nunit/docs/wiki/Custom-Attributes
- https://github.com/nunit/docs/wiki/Writing-Engine-Extensions
- Could probably use TestCase attributes to define integration/not on each method. A bit verbose, non-semantic, and extra init work
- NOTE: Changing the test name with something like IApplyToTest is not changing the name in the test runner
- NOTE: NUnit supports test name string formatting https://stackoverflow.com/questions/26374265/access-nunit-test-name-within-testcasesource

- Conclusion: The rules for name generation are not very clear in NUnit.
  However, I have verified that you can sucessfully overwrite the name in either
  the test builder or the fixture builder. 
  It is not entirely clear how to extend these types while maintaining behavior
  because you cannot override when you inherit from the default attributes. Instead,
  the logic is available through internal builders and type constructors.
  However, you can also inherit from the default attribute and 'hide' the base class's method 
  by creating one of the same signature. This breaks liscov substitution, but it 
  allows you to reuse the property logic of the base attibutes


BONUS: Interesting thread on using NUnit tests to augment documentation https://stackoverflow.com/questions/8727684/how-can-i-generate-documentation-from-nunit-tests