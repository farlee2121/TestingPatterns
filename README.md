# TestingPatterns

This project is to record and share patterns and libraries that make testing 
- easier
- more resilient
- more powerful
- more descriptive

As a result, it also demonstrates many other patterns and libraries that enable good development practices. 

This project is very much overkill for a Todo list. However, the overkill is to demonstrate the patterns in a way that can easily be transfered to a large project

Patterns
- Dependency Injection
- DataPrep (centralized test data generators)
- ConfigWrappers //pending
- Inconclusive tests to mark untested code // pending

Libraries
- JustMock (test dependency generator; https://www.telerik.com/products/mocking.aspx)
  - alternatives: Moq, MSFakes, RhinoMocks
- DeepEqual (https://github.com/jamesfoster/DeepEqual)
- Bogus (https://github.com/bchavez/Bogus)
  - alternatives: AutoFixture
- .NET Transactions TransactionScope
