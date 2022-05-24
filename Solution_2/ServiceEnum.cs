using FactoryMethod.Implements;

namespace FactoryMethod.Solution_2
{
    public enum ServiceEnum
    {
        DataUpdate,
        DataNew,
        DataDelete
    }

    public static class DependencyServiceEnum
    {
        public static IServiceCollection AddServiceSolutionEnum(this IServiceCollection services)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            services.AddScoped<Func<ServiceEnum, IData>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case ServiceEnum.DataUpdate: return serviceProvider.GetService<DataUpdate>();
                    case ServiceEnum.DataNew: return serviceProvider.GetService<DataNew>();
                    case ServiceEnum.DataDelete: return serviceProvider.GetService<DataDelete>();
                    default: return null;
                }
            });
            return services;
        }
    }
}
