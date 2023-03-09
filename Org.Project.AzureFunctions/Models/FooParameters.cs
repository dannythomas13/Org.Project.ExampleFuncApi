using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Org.Project.AzureFunctions.Models.Examples;

namespace Org.Project.AzureFunctions.Models
{
    [OpenApiExample(typeof(FooRequestExample))]
    public class FooParameters
    {
        public double A { get; set; }

        public double B { get; set; }
    }
}
