// using Microsoft.Extensions.DependencyInjection;
// using Weikio.ApiFramework.Abstractions;
//
// namespace Weikio.ApiFramework.Plugins.SharePoint
// {
//     public static class ServiceCollectionExtensions
//     {
//         
//     }
//
//     public static class ApiFrameworkBuilderExtensions
//     {
//         public static IApiFrameworkBuilder AddSharepoint(this IApiFrameworkBuilder builder, string route, SharePointOptions options)
//         {
//             builder.Services.AddTransient<IPluginCatalog>(services =>
//             {
//                 var typeCatalog = new TypePluginCatalog(apiType);
//
//                 return typeCatalog;
//             });
//             
//             builder.Services.AddTransient(services =>
//             {
//                 var endpointConfiguration = new EndpointDefinition(route, api, configuration, healthCheck, groupName);
//
//                 return endpointConfiguration;
//             });
//
//             return builder;
//         }
//     }
// }
