using Autofac;
using Domain.Interfaces.Repository;
using Infrastructure.Repository;
using Infrastructure;
using Domain.Interfaces.UnitOfWork;
using Domain.Interfaces.Services;
using DynamicAuthApi.Middlewaare;


namespace DynamicAuthApi
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IUnitOfWork).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IAuthService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(CustomMiddleWare).Assembly).InstancePerLifetimeScope();

        }
    }
}
