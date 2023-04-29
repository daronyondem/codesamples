using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class QueueToQueue
    {
        private readonly ILogger _logger;

        public QueueToQueue(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<QueueToQueue>();
        }

        [Function("QueueToQueue")]
        [QueueOutput("myqueue-items-out", Connection = "20230429ec1eb2_STORAGE")]
        public Todo Run([QueueTrigger("myqueue-items", Connection = "20230429ec1eb2_STORAGE")] Todo myQueueItem)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            return new Todo { Taskname = myQueueItem.Taskname };
        }
        public class Todo
        {
            public string Taskname { get; set; }     
        }
    }
}
