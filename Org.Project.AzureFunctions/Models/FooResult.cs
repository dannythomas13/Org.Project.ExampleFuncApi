using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Org.Project.AzureFunctions.Models.Examples;

namespace Org.Project.AzureFunctions.Models
{
    [OpenApiExample(typeof(FooResultExample))]
    public class FooResult
    {
        public double A { get; set; }

        public double B { get; set; }

        public string C { get; set; }

        public double D { get; set; }
    }
}
