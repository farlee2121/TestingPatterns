#DataPrep Pattern
The DataPrep pattern is a way of centralizing test data generation and creating readable handles for common
data requests.

The pattern consists of two parts
1. individual data preps: these handle
 - the construction of a particular type based on passed conditions
 - abstraction of complex arrangement scenarios
2. data prep orchestrator: this class is responsible for
 - providing a central handle for creating test data
 - allowing us to configure type data preps uniformly
 - allowing us to present type data preps differently for different scenarios


We utilize a test data generation library called Bogus. Bogus can generate complex data types, so why don't we use that directly?
Well,
 - When data structures change, it is much harder to find specific uses of a library than a central method
 - You still end up with a lot of noisy configuration in your tests
 - Data prep produces clearer specification of test situations, especially with complex situations
 - a custom DataPrep wrapper allows us to absract how we persist data
