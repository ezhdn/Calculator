using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using UnityContainerExtensions = Microsoft.Practices.Unity.UnityContainerExtensions;

namespace Calculator
{
    public class UnityContext
    {
        private static volatile IUnityContainer _container;
        private static object _sync = new object();

        private UnityContext()
        {
        }

        public static IUnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    lock (_sync)
                        if (_container == null)
                        {
                            _container = new UnityContainer();
                            var section = (UnityConfigurationSection) ConfigurationManager.GetSection("unity");
                            if (section != null)
                                section.Configure(_container);
                        }
                }
                return _container;
            }
        }
    }

}
