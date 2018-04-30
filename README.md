# TestingPatterns

This project is to record and share patterns and libraries that make testing 
- easier
- more resilient
- more powerful
- more descriptive

As a result, it also demonstrates many other patterns and libraries that enable good development practices. 

Here is the presentation the triggered the project: https://1drv.ms/p/s!AjVvNQ4uturOdRxhCnyW16c_yk4

Here is a presentation that describes the design philosphies: https://1drv.ms/b/s!AjVvNQ4uturOby6OwKMFpMUlMqA

This project is very much overkill for a Todo list. However, the overkill is to demonstrate the patterns in a way that can easily be transfered to a large project

Testing Patterns
- Dependency Injection
- DataPrep (centralized test data generators)
- ConfigWrappers //pending
- Inconclusive tests to mark untested code
- Test name modification for test runner (display extra info without manually adding it to each test name)
- Unit/Integration test reuse

Testing Libraries
- JustMock (test dependency generator; https://www.telerik.com/products/mocking.aspx)
  - alternatives: Moq, MSFakes, RhinoMocks
- DeepEqual (https://github.com/jamesfoster/DeepEqual)
  - alternatives: NUnit.DeepObjectCompare (https://github.com/PolarbearDK/NUnit.DeepObjectCompare)
- Bogus (https://github.com/bchavez/Bogus)
  - alternatives: AutoFixture
- .NET Transactions TransactionScope
- NUnit
  - alternatives: MSTest
