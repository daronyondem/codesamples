using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.OpenAI.Embeddings;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Extensions.OpenAI.Search;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.OpenAI
{
    public class RAGPrompting
    {
        private readonly ILogger<RAGPrompting> _logger;

        public RAGPrompting(ILogger<RAGPrompting> logger)
        {
            _logger = logger;
        }

        [Function("RAGPrompting")]
        public static IActionResult Prompt(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [SemanticSearchInput("AISearchEndpoint", "vector-index", CredentialSettingName = "SearchAPIKey", Query = "{Prompt}", ChatModel = "%CHAT_MODEL_DEPLOYMENT_NAME%", EmbeddingsModel = "%EMBEDDING_MODEL_DEPLOYMENT_NAME%", MaxKnowledgeCount = 1, SystemPrompt = "Only use information you are given.")] SemanticSearchContext result)
        {
            return new ContentResult { Content = result.Response, ContentType = "text/plain" };
        }
    }
}
