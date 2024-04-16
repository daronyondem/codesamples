using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.OpenAI.Embeddings;
using Microsoft.Extensions.Logging;

namespace Contoso.OpenAI
{
    public class GenerateEmbeddings
    {
        private readonly ILogger<GenerateEmbeddings> _logger;

        public GenerateEmbeddings(ILogger<GenerateEmbeddings> logger)
        {
            _logger = logger;
        }

        [Function("GenerateEmbeddings")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
        [EmbeddingsInput("{TextBody}", InputType.RawText, 
            Model = "%EMBEDDING_MODEL_DEPLOYMENT_NAME%")] EmbeddingsContext embeddings)
        {
            this._logger.LogInformation("Received {count} embedding(s).",embeddings.Count);
            return new OkObjectResult(embeddings.Response.Data[0].Embedding);
        }
    }
}
