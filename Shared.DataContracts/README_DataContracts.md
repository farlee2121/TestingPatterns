#Data Contracts

Data contracts are the data forms agreed on between services.
In other words, they:
 - Represent the data required to complete a flow in the application
 - are the only non-value types that should be available in multiple projects 
 - are the only non-value types returned from an interface
 - 
 
 Data contracts should
  - be as flat as possible (very rarely contain non-value types)
  - Contain only the data needed for the situation, split contracts if you have un-needed data
  - Be named semantically / so that it is clear what purpose they fulfill
  - Do not contain state or logic. This is both a matter of concurrency (thread safety) and conceptual clarity.
    

 This
- improves iteroperability (because services use the same types)
- limits the scope of computation-specific and project-specific types by disallowing them as a return type
- Limits ability to couple services through data, because the contracts are designed for an application flow,
  not to particular pieces of code. Being flat and minimal also reduces the possibility for unintended use or
  broken expectations
- Disallowing state and logic, besides enabling thread-safe operations, decouples data from actions. This helps allows us to
  operate on the data in many valid ways without mixing unrelated logic. It also keeps you from distributing manager-style code, which leads to unexpected actions
  For example, you are passed an object configured to save to the db, but you want to save it to a nosql) because the orchestrating context is always responsible for,
  well... orchestrating
- Allows internal service changes without impact to external code (As long as the internal data maps to the contract, no related services care)