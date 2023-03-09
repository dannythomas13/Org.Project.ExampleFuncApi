using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Newtonsoft.Json.Serialization;
using Org.Project.AzureFunctions.Models;

namespace Org.Project.AzureFunctions.Models.Examples
{
    public class FooResultExample : OpenApiExample<FooResult>
    {
        public override IOpenApiExample<FooResult> Build(NamingStrategy namingStrategy = null)
        {
            Examples.Add(
                OpenApiExampleResolver.Resolve(
                    "Example",
                    new FooResult
                    {
                        A = 1,
                        B = 0.0140643853250058,
                        C = "blah",
                        D = 0
                    },
                    namingStrategy
                ));

            return this;
        }
    }
}
