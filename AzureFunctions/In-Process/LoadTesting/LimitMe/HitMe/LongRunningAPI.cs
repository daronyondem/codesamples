using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HitMe
{
    public static class LongRunningAPI
    {
        private static readonly Random _random = new();

        [FunctionName("LongRunningAPI")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //Simulating long running process.
            int delay = _random.Next(2000, 5000);
            System.Threading.Thread.Sleep(delay);

            string name = req.Query["name"];

            string responseMessage = string.IsNullOrEmpty(name)
                ? $"This HTTP triggered function executed successfully for {delay} milliseconds. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully running for {delay} milliseconds.";

            return new OkObjectResult(responseMessage);
        }
    }
}
