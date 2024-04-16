using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.OpenAI.Embeddings;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Extensions.OpenAI.Search;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using System.Text.Json;

namespace Contoso.OpenAI
{
    public class IngestText
    {
        private readonly ILogger<IngestText> _logger;

        public IngestText(ILogger<IngestText> logger)
        {
            _logger = logger;
        }

        [Function("IngestText")]
        public static async Task<SemanticSearchOutputResponse> IngestFile(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
            [EmbeddingsInput("{TextBody}", InputType.RawText, Model = "%EMBEDDING_MODEL_DEPLOYMENT_NAME%")] EmbeddingsContext embeddings)
        {
            using StreamReader reader = new(req.Body);
            string requestBody = await reader.ReadToEndAsync();
            var data = JsonSerializer.Deserialize<dynamic>(requestBody);
            string title = data.GetProperty("Title").GetString();

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(new { status = "success", chunks = embeddings.Count });

            return new SemanticSearchOutputResponse
            {
                HttpResponse = response,
                SearchableDocument = new SearchableDocument(title, embeddings)
            };
        }

        public class SemanticSearchOutputResponse
        {
            [SemanticSearchOutput("AISearchEndpoint", "vector-index", CredentialSettingName = "SearchAPIKey", EmbeddingsModel = "%EMBEDDING_MODEL_DEPLOYMENT_NAME%")]
            public SearchableDocument SearchableDocument { get; set; }

            public HttpResponseData? HttpResponse { get; set; }
        }
    }
}
