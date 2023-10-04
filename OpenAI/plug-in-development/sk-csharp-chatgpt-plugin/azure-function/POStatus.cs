using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;

public class POStatus
{
    private readonly ILogger _logger;

    public POStatus(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<POStatus>();
    }

    [Function("POStatus")]
    [OpenApiOperation(operationId: "GetPOStatus", tags: new[] { "PurchaseOrders" }, Description = "Gets the status of a purchase order.")]
    [OpenApiParameter(name: "number", Description = "The purchase order number.", Required = true, In = ParameterLocation.Query)]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "Returns the status of the purchase order.")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(string), Description = "Returns the error of the input.")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        bool result = int.TryParse(req.Query["number"], out int poNumber);

        if (!result)
        {
            _logger.LogInformation($"Invalid PO Number: {req.Query["number"]}");
            return CreateResponse(req, HttpStatusCode.BadRequest, "Invalid PO number.");
        }

        _logger.LogInformation($"Processing PO: {poNumber}");
        return CreateResponse(req, HttpStatusCode.OK, "PO is good to go!");
    }

    private HttpResponseData CreateResponse(HttpRequestData req, HttpStatusCode statusCode, string message)
    {
        HttpResponseData response = req.CreateResponse(statusCode);
        response.Headers.Add("Content-Type", "text/plain");
        response.WriteString(message);
        return response;
    }
}

