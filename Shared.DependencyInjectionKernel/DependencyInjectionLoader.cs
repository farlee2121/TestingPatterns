using Accessors.DatabaseAccessors;
using Managers.LazyCollectionOfAllManagers;
using Ninject;
using Ninject.Modules;
using System.Collections.Generic;

namespace Shared.DependencyInjectionKernel
{
    public static class DependencyInjectionLoader
    {
        // NOTE: This class centrallizes dependency injection configuration and removes the need to directly
        // reference dependency projects. You can still instantiate a subset of dependencies if needed, but this
        // centrallizes the usual concern of wanting all the full stack.
        // This is only useful if you have multiple clients. In this case, our integration test are all effectively clients.

        public static INinjectModule[] Modules = new INinjectModule[]
        {
            new LazyManagerLoader(),
            new DatabaseAccessorLoader(),
        };
        public static IKernel BuildKernel()
        {
            IKernel kernel = new StandardKernel(Modules);
            return kernel;
        }
    }
}
