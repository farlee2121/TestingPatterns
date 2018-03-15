#Dependency Injection Kernel

The dependency kernel allows us to centralize our dependency injection configuration. This helps prevents errors 
caused by forgetting to update different clients that require configuration for new service types.

This class allows us offer up alternative configurations (through additional methods) for clients that may only require a subset of the 
dependency configuration while keeping the dependency maps in one clear place.