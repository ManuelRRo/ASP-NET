using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ActivoFijo.Data.AutoMapper
{
    public static class AutomapperContextExtension
    {
        public static void RegisterMaps(this ContainerBuilder builder)
        {
            var profile = (Profile)Activator.CreateInstance(typeof(MapperProfile));
            
            builder.Register( ctx => new MapperConfiguration(cfg => {
                cfg.AddProfile(profile);}
            ));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
