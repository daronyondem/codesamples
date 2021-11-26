using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.WebPubSub;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Logging;

namespace WebPubSup
{
    public class notification
    {
        [FunctionName("notification")]
        public static async Task Run([TimerTrigger("*/10 * * * * *")] TimerInfo myTimer, ILogger log,
            [WebPubSub(Hub = "notifications")] IAsyncCollector<WebPubSubAction> actions)
        {
            await actions.AddAsync(new SendToAllAction
            {
                Data = BinaryData.FromString($"[DateTime: {DateTime.Now}] Temperature: {GetValue(23, 1)}{'\xB0'}C, Humidity: {GetValue(40, 2)}%"),
                DataType = WebPubSubDataType.Text
            });
        }

        private static string GetValue(double baseNum, double floatNum)
        {
            var rng = new Random();
            var value = baseNum + floatNum * 2 * (rng.NextDouble() - 0.5);
            return value.ToString("0.000");
        }
    }
}
