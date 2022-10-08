using Autofac;
using AutoMapper;
using FarmasiMarketPlace.Business.Interfcae;
using FarmasiMarketPlace.Business.Services;
using FarmasiMarketPlace.DAL.Interface;
using FarmasiMarketPlace.DAL.MongoDbSettings;
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
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<MongoDbSettings>().As<IMongoDbSettings>().InstancePerLifetimeScope();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
