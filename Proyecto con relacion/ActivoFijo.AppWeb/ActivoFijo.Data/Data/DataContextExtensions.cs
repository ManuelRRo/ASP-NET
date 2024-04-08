using System;
using ActivoFijo.Data.DataContext;
using Autofac;

namespace ActivoFijo.Data.Data
{
    public static class DbContextExtensions
    {
        public static void RegisterDbContext(this ContainerBuilder builder)
        {
            builder.RegisterType<ActivoFijoModel>().InstancePerRequest();
        }
    }
}
