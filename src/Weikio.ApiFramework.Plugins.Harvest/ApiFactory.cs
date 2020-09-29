using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adafy.Harvest.Netstandard;
using Adafy.Harvest.Netstandard.Models;
using Weikio.TypeGenerator.Types;
using Task = System.Threading.Tasks.Task;

namespace Weikio.ApiFramework.Plugins.Harvest
{
    public static class ApiFactory
    {
        public static Task<IEnumerable<Type>> Create(HarvestOptions configuration)
        {
            var generator = new TypeToTypeWrapper();

            var customersApi = generator.CreateType(typeof(HarvestRestClient),
                new TypeToTypeWrapperOptions()
                {
                    Inherits = typeof(HarvestApiBase),
                    IncludedMethods = new List<string>() { "*ClientAsync", "*ClientsAsync" },
                    TypeName = "CustomersApi",
                    NamespaceName = "Weikio.ApiFramework.Plugins.Harvest",
                    MethodNameGenerator = (options, type, mi) =>
                    {
                        var methodName = mi.Name.Replace("List", "Get").Replace("Client", "Customer");

                        if (methodName.StartsWith("Customer"))
                        {
                            return "Get" + methodName;
                        }

                        return methodName;
                    },
                    Factory = (options, type) =>
                        new HarvestRestClient(configuration.HarvestCompany, configuration.HarvestUser, configuration.HarvestUserPassword),
                    ExcludeMethod = (options, type, mi) =>
                    {
                        if (mi.Name.StartsWith("Toggle"))
                        {
                            return true;
                        }

                        var hasOveloads = type.GetMethods().Count(x => string.Equals(x.Name, mi.Name)) > 1;

                        if (hasOveloads == false)
                        {
                            return false;
                        }

                        var parameters = mi.GetParameters();

                        var clientOptionsParam = parameters.FirstOrDefault(x => x.ParameterType == typeof(ClientOptions));

                        if (clientOptionsParam == null)
                        {
                            return true;
                        }

                        return false;
                    }
                });

            var result = new List<Type>() { customersApi };

            return Task.FromResult<IEnumerable<Type>>(result);
        }
    }
}
