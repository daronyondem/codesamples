using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ManagedIdentity
{
    public static class DumpRequest
    {
        [FunctionName(nameof(DumpRequest))]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [Blob("netconf/{query.id}", FileAccess.Write, Connection="StorageConnection")] Stream blob,
            ILogger log)
        {
            await req.Body.CopyToAsync(blob);

            log.LogInformation($"Dumped {req.Query["id"]}");
        }

    }
}
