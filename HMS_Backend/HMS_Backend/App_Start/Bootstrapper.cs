using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using HMS_DataAccess.infra;
using HMS_DataAccess.repo;
using HMS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HMS_Backend.App_Start
{
    public class Bootstrapper
    {
        /// <summary>
        /// 
        /// </summary>
        protected static IContainer container;

        /// <summary>
        /// 
        /// </summary>
        public static void Run()
        {
            SetAutofacContainer();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            
            builder.RegisterType<DBFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(BookingRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(BookingService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}