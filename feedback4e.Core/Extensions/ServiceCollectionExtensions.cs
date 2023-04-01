using feedback4eTask.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace feedback4eTask.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //bizim core katmanı dahil olmak üzere ekleyeceğimiz tün enjectionları bir arada toplayabileceğim bir yapı oluştu.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}
