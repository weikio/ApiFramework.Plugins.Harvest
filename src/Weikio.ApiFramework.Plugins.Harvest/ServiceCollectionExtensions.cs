using Microsoft.Extensions.DependencyInjection;
using Weikio.ApiFramework.Abstractions.DependencyInjection;
using Weikio.ApiFramework.SDK;

namespace Weikio.ApiFramework.Plugins.Harvest
{
    public static class ServiceExtensions
    {
        public static IApiFrameworkBuilder AddHarvest(this IApiFrameworkBuilder builder)
        {
            var assembly = typeof(HarvestOptions).Assembly;
            var apiPlugin = new ApiPlugin { Assembly = assembly };

            builder.Services.AddSingleton(typeof(ApiPlugin), apiPlugin);

            builder.Services.Configure<ApiPluginOptions>(options =>
            {
                if (options.ApiPluginAssemblies.Contains(assembly))
                {
                    return;
                }

                options.ApiPluginAssemblies.Add(assembly);
            });

            return builder;
        }

        public static IApiFrameworkBuilder AddHarvest(this IApiFrameworkBuilder builder, string endpoint, HarvestOptions configuration)
        {
            builder.AddHarvest();

            builder.Services.RegisterEndpoint(endpoint, "Weikio.ApiFramework.Plugins.Harvest", configuration);

            return builder;
        }
    }
}
