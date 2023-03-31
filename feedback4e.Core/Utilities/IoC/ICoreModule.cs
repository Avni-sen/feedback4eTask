using Microsoft.Extensions.DependencyInjection;

namespace feedback4eTask.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
