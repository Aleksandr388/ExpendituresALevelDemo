using AutoMapper;
using BL.Interfaces;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using LightInject;
using BL;
using System.Web.Mvc;
using LightInject.Mvc;
using System.Web.Http;

namespace ExpendituresALevelDemo.App_Start
{
    public static class LightInjectConfig
    {
        public static void Congigurate()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());
            //container.RegisterApiControllers();
            //container.EnablePerWebRequestScope();
            //container.EnableWebApi(GlobalConfiguration.Configuration);

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                  new List<Profile>() { new WebAutomapperProfile(), new BLAutomapperProfile() }));

            container.Register(c => config.CreateMapper());

            container = BLLightInjectConfiguration.Configuration(container);

            container.Register<ITransactionService, TransactionService>();
            container.Register<ICategoryService, CategoryService>();


            //var resolver = new LightInjectWebApiDependencyResolver(container);             
            DependencyResolver.SetResolver(new LightInjectMvcDependencyResolver(container));
            container.EnableMvc();
        }
    }
}