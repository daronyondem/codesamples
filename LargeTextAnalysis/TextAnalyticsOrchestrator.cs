using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LargeTextAnalysis
{
    public static class TextAnalyticsOrchestrator
    {
        [FunctionName("TextAnalyticsOrchestrator")]
        public static async Task<HashSet<string>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var textSegments = context.GetInput<string[]>();

            var outputs = new List<Task<HashSet<string>>>();
            foreach (var textSegment in textSegments)
            {
                outputs.Add(context.CallActivityAsync<HashSet<string>>("AnalyzeText", textSegment));
            }
                        
            await Task.WhenAll(outputs);

            HashSet<string> finalKeyPhrases = new HashSet<string>();
            foreach (var outputHashSet in outputs.Select(x => x.Result))
            {
                finalKeyPhrases.UnionWith(outputHashSet);
            }

            return finalKeyPhrases;
        }
    }
}