using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors.DatabaseAccessors
{
    public class DatabaseAccessorLoader : NinjectModule
    {
        public override void Load()
        {
            Bind<ITodoItemAccessor>().To<TodoItemAccessor>();
            Bind<ITodoListAccessor>().To<TodoListAccessor>();
        }
    }
}
