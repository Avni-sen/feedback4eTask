using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using feedback4eTask.Business.Handlers.Airports.Abstract;
using feedback4eTask.Core.Utilities.Interceptors;
using feedback4eTask.DataAccess.Concrete.EntityFramework;

namespace feedback4eTask.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AirportService>().As<IAirportService>().SingleInstance();
            builder.RegisterType<AirportRepository>().As<IAirportRepository>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}



