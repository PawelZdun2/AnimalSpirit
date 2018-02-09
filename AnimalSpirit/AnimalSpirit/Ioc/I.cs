using System;
using Autofac;
using Autofac.Core;

namespace AnimalSpirit.Ioc
{
    public class I
    {
        private static readonly object _lock = new object();
        private static volatile I _instance;

        private IContainer _container;

        private I()
        {
        }

        public bool Initialized { get; private set; }

        public static I Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new I();
                            return _instance;
                        }
                    }
                }

                return _instance;
            }
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type t)
        {
            return _container.Resolve(t);
        }

        public void SetPlatformSpecificModules(IModule[] platformSpecifcModule)
        {
            var container = new ContainerBuilder();
            if (platformSpecifcModule == null)
            {
                return;
            }
            foreach (var item in platformSpecifcModule)
            {
                container.RegisterModule(item);
            }

            _container = container.Build();
        }
    }
}
