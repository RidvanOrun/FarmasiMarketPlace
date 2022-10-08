using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmasiMarketPlace.API.Ioc
{
    public class AutoFactContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
