using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LargeTextAnalysis
{
    public static class Analyze
    {
        [FunctionName("Analyze")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            //Test Sample: http://www.gutenberg.org/files/64229/64229-0.txt
            //724 kB plain text version of "A Century of Parody and Imitation" by Walter Jerrold and R. M. Leonard
            string textFileUrl = req.Query["documentUrl"];

            WebClient webClient = new WebClient();
            string textContent = webClient.DownloadString(textFileUrl);

            string[] lines = textContent.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );

            var textSegments = new List<string>();
            var lineIndex = 0;
            while (lineIndex < lines.Length)
            {
                StringBuilder sb = new StringBuilder();
                while (sb.Length < 5000 && lineIndex < lines.Length)
                {
                    sb.Append(lines[lineIndex]);
                    lineIndex += 1;
                }
                textSegments.Add(sb.ToString());
            }

            string instanceId = await starter.StartNewAsync("TextAnalyticsOrchestrator", input: textSegments.ToArray());

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}
