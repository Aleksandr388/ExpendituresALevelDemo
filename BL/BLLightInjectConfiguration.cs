using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;

namespace BL
{
    public class BLLightInjectConfiguration
    {
        public static ServiceContainer Configuration(ServiceContainer container)
        {
            container.Register<ExpenditureContext>(new PerScopeLifetime());
            container.Register(typeof(ICategoryRepository), typeof(CategoryRepository));
            container.Register(typeof(ITransactionRepository), typeof(TransavtionRepostory));
            return container;
        }
    }
}
