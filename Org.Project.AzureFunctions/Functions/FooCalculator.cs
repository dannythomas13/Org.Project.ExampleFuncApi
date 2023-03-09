using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Org.Project.AzureFunctions.Models;
using Org.Project.AzureFunctions.Models.Examples;
using System.Net;

namespace Org.Project.AzureFunctions.Functions
{
    public class FooCalculator
    {
        private readonly ILogger _logger;

        public FooCalculator(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FooCalculator>();
        }

        [OpenApiOperation(operationId: "blah-point", tags: new[] { "Blah Tags" }, Summary = "Blah Summary", Description = "This calculates.....", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(FooParameters), Description = "Parameters", Required = true, Example = typeof(FooRequestExample))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(FooResult), Summary = "The response", Description = "This returns the response", Example = typeof(FooResultExample))]
        [Function("blah-point")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var parameters = JsonConvert.DeserializeObject<FooParameters>(requestBody);

            HttpResponseData response;

            if(parameters is null)
            {
                response = req.CreateResponse(HttpStatusCode.BadRequest);
                await response.WriteStringAsync("Unable to parse valid parameters from body");
            }
            else
            {
                try
                {
                    var result = new FooResult
                    {
                        A = 1,
                        B = 1,
                        C = "High",
                        D = 1
                    };

                    response = req.CreateResponse(HttpStatusCode.OK);
                    await response.WriteAsJsonAsync(result);
                }
                catch(Exception ex)
                {
                    response = req.CreateResponse(HttpStatusCode.BadRequest);
                    await response.WriteStringAsync(ex.Message);
                }
            }

            return response;
        }
    }
}

