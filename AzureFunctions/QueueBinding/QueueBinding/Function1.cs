using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace QueueBinding
{
    public class Function1
    {
        [FunctionName("Function1")]
        [return: Queue("samplequeue2")]
        public TestMessage Run([QueueTrigger("samplequeue", Connection = "AzureWebJobsStorage")]string myQueueItem,
            DateTimeOffset expirationTime,
            DateTimeOffset insertionTime,
            DateTimeOffset nextVisibleTime,
            string id,
            int dequeueCount, 
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function executed: {myQueueItem}\n" +
               $"expirationTime={expirationTime}\n" +
               $"insertionTime={insertionTime}\n" +
               $"nextVisibleTime={nextVisibleTime}\n" +
               $"id={id}\n" +
               $"dequeueCount={dequeueCount}");

            return new TestMessage() { Text = myQueueItem };
        }

        public class TestMessage
        {
            public string Text { get; set; }
        }
    }
}
