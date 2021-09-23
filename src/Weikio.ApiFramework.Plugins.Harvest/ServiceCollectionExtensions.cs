using Microsoft.Extensions.DependencyInjection;
using Weikio.ApiFramework.Abstractions.DependencyInjection;
using Weikio.ApiFramework.SDK;

namespace Weikio.ApiFramework.Plugins.Harvest
{
    public static class ServiceExtensions
    {
        public static IApiFrameworkBuilder AddHarvest(this IApiFrameworkBuilder builder, string endpoint = null, HarvestOptions configuration = null)
        {
            builder.Services.AddHarvest(endpoint, configuration);

            return builder;
        }

        public static IServiceCollection AddHarvest(this IServiceCollection services, string endpoint = null, HarvestOptions configuration = null)
        {
            services.RegisterPlugin(endpoint, configuration);

            return services;
        }
    }
}
