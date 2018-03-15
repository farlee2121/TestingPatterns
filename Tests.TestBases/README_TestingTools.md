# Testing Tools

This is sort of a catch-all doc for testing concerns and awesome libraries that make testing easier.

# Test Dependency Generation
When testing a code, you want the subject of test to be isolated so that there are no errors from code you 
don't intend to test.
Dependency injection allows us to configure test dependencies that only do what we expect for the test, but
it can be a lot of work to specify stub dependencies.

That is where JustMock comes in. It auto-generates test dependencies and allows you to modify their behavior
in the unit test as needed.

# Complex Object Comparison
DeepEqual allows you to compare complex objects by their values and modify comparison behavior as needed.

# Data Cleanup
.NET transactions allow you to specify each test as a unit of work. That unit can then be committed or rolled back
as a whole. This means that you don't have to worry about leaving test data behind, it happens auto-magically.

# DataPrep
Has its own doc, check it out