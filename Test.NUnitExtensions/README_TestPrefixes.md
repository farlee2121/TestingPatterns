# Auto-Generated Test Prefixes

Prefixing the name of the tested class to a test name produces more clearly organized test results.
It also allows us to more quickly identify trends in test failures. 

However, manually maintaining these prefixes is a pain. If you change a class name, it is easy to forget
to rename all the tests and is boring to rename all the tests.

Auto-generating the class name based on the test subject types means we can't forget to rename the test
and cleans test name of info we already know when we are in the test class.

Generated prefixes can also help differentiate tests that generate multiple cases, such as with integration/unit
test reuse.