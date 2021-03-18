using SpecFlowPractice.Interface;
using SpecFlowPractice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SpecFlowPracticeTests.Config
{
    public class UnityConfig
    {
        private static UnityContainer _container;
        internal static UnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    Initial();
                }
                return _container;
            }
        }

        public static void Initial()
        {
            _container = new UnityContainer();
        }

        public static UnityContainer RegisterComponents()
        {
            Initial();

            Container.RegisterType<IAccount, Account>();
            Container.RegisterType<IHash, Hash>();
            Container.RegisterType<IValidation, Validation>();

            return Container;
        }
    }
}
