using System;
using System.Collections.Generic;
using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace LargeTextAnalysis
{
    public static class TextAnalyticsActivity
    {
        [FunctionName("AnalyzeText")]
        public static HashSet<string> AnalyzeText([ActivityTrigger] string text, ILogger log)
        {
            string textAnalyticsKey = Environment.GetEnvironmentVariable("TextAnalyticsKey");
            string textAnalyticsEndpoint = Environment.GetEnvironmentVariable("TextAnalyticsEndpoint");

            var keyPhrases = new HashSet<string>();
            var client = new TextAnalyticsClient(new Uri(textAnalyticsEndpoint), new AzureKeyCredential(textAnalyticsKey));
            var response = client.ExtractKeyPhrases(text);

            foreach (string keyphrase in response.Value)
            {
                keyPhrases.Add(keyphrase);
            }
            return keyPhrases;
        }
    }
}
