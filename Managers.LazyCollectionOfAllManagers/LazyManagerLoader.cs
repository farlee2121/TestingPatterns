using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.LazyCollectionOfAllManagers
{
    public class LazyManagerLoader : NinjectModule
    {
        public override void Load()
        {
            Bind<IListExplorationManager>().To<ListExplorationManager>();
            Bind<ITodoCRUDManager>().To<TodoCRUDManager>();
        }
    }
}
