using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Newtonsoft.Json.Linq;

namespace Company.Function
{
    public static class ClassBasedActor
    {
        [FunctionName("ClassBasedActor")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "classbasedactor/{entityId}/{operation}")] HttpRequest req,
            [DurableClient] IDurableEntityClient entityClient,
            ILogger log, string entityId, string operation)
        {
            log.LogInformation($"Actor {entityId} called for {operation}.");
       
            int inputValue = int.TryParse(req.Query["inputValue"], out var tempValue) ? tempValue : 0;

            if (string.IsNullOrEmpty(operation) || string.IsNullOrEmpty(entityId))
            {
                return new BadRequestObjectResult("Please provide operation (add, reset, get, delete) and entityId.");
            }

            var entityIdObj = new EntityId(nameof(ClassBasedCounter), entityId);

            switch (operation.ToLowerInvariant())
            {
                case "add":
                    await entityClient.SignalEntityAsync(entityIdObj, nameof(ClassBasedCounter.Add), inputValue);
                    break;
                case "reset":
                    await entityClient.SignalEntityAsync(entityIdObj,  nameof(ClassBasedCounter.Reset));
                    break;
                case "delete":
                    await entityClient.SignalEntityAsync(entityIdObj, nameof(ClassBasedCounter.Delete));
                    break;
                case "get":
                    //Beware of caching 
                    // https://learn.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-dotnet-entities#example-client-reads-entity-state
                    var stateResponse = await entityClient.ReadEntityStateAsync<object>(entityIdObj);
                    if (stateResponse.EntityExists)
                        return new OkObjectResult(((JObject)stateResponse.EntityState)["Value"].Value<int>());
                    else
                        return new NotFoundObjectResult("Entity not found.");
                default:
                    return new BadRequestObjectResult("Invalid operation. Supported operations: add, reset, get, delete");
            }

            return new AcceptedResult();
        }
    }
}
