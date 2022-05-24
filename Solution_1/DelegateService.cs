using FactoryMethod.Implements;
using static FactoryMethod.Solution_1.DelegateService;

namespace FactoryMethod.Solution_1
{
    public class DelegateService
    {
        public delegate T ServiceResolver<T>(string key) where T : IData;
    }

    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceSolutionDelegate(this IServiceCollection services)
        {
            services.AddScoped<ServiceResolver<IData>>(serviceProvider => key =>
            {
                #pragma warning disable CS8603 // Possible null reference return.
                switch (key)
                {
                    case nameof(DataUpdate): return serviceProvider.GetService<DataUpdate>();
                    case nameof(DataNew): return serviceProvider.GetService<DataNew>();
                    case nameof(DataDelete): return serviceProvider.GetService<DataDelete>();
                    default: break;
                }
                throw new KeyNotFoundException();
            });
            return services;
        }
    }
}
