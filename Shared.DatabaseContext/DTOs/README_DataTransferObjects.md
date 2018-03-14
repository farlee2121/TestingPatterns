#Data Transfer Objects

At first blush, these may seem the same as data contracts. However, data transfer objects reflect expected results
of data source queries. They allow us to encode knowledge about our data stucture for consumption in our code. 
DataContracts on the other hand, should have no ties to the data structure.

Handing off from DTOs to DataContracts allows only our accessors to contain knowledge of the datasource, while the 
rest of the application is un-impacted by database changes. This makes it much easier to make data schema changes
without causing bugs. As long as the accessors map to the data contracts, no changes outside the accessor are needed.

Adding this additional set of models can make for a lot of boring object mapping work. Fortunately, there are libraries
like AutoMapper that automate that work, making database-isolation the clear winner of the design concerns.