using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Newtonsoft.Json.Serialization;

namespace Org.Project.AzureFunctions.Models.Examples
{
    public class FooRequestExample : OpenApiExample<FooParameters>
    {
        public override IOpenApiExample<FooParameters> Build(NamingStrategy namingStrategy = null)
        {
            Examples.Add(
                OpenApiExampleResolver.Resolve(
                    "ParametersExample",
                    new FooParameters
                    {
                        A = 0,
                        B = 12.6
                    },
                    namingStrategy
                ));

            return this;
        }
    }
}
