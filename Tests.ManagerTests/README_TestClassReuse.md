# Test Class Reuse

There are to common automated test types written by developers.
 - Unit tests: verify a specific piece of code in isolation
 - Integration tests: verify that the components in a flow work together as expected

Between our dependency injection and abstracted data prep, our unit tests can configure both the 
dependencies and persistance of data independed of individual tests. This means that our tests
specify a situation, with out regard to execution context.

Thus, our unit tests and integration tests now only differ by configuration. Using NUnit,
we can easily run a test class with two different configurations and cut our testing effort in half!

Some examples are shown of test reuse with MSTest, but it is neither as easy nor as clear as with NUnit.

We have plans to create more clear NUnit attributes that will prefix integration tests and allow us to exclude
individual methods from either unit or integration runs
