using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Web;
using System.Web.Security;
using System.Web.SessionState;
using ActivoFijo.Data.AutoMapper;
using ActivoFijo.Data.Data;
using ActivoFijo.Data.Repository.CAT;
using ActivoFijo.Core.Interfaces;
using ActivoFijo.Core.Dto.CAT;

namespace ActivoFijo.AppWeb
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
           
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterMaps();
            builder.RegisterDbContext();


            builder.RegisterType<ClasificacionActivoFijoRepository>().As<IOperacion<ClasificacionActivoFijoDto>>();
            builder.RegisterType<EspecificoGastoRepository>().As<IOperacion<EspecificoGastoDto>>().InstancePerRequest();


            _containerProvider = new ContainerProvider(builder.Build());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Console.WriteLine(ex.Message);
        }
    }
}