using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Azure.Identity;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using Company.Function.Models;
using Azure.Core;

namespace Company.Function
{
    public class ShowConsumption
    {
        private readonly ILogger _logger;

        public ShowConsumption(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ShowConsumption>();
        }

        [Function("ShowConsumption")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string subscriptionId = Convert.ToString(Environment.GetEnvironmentVariable("SUBSCRIPTION_ID"));
            string resourceGroupName = Convert.ToString(Environment.GetEnvironmentVariable("RESOURCE_GROUP"));

            DefaultAzureCredential credential = new DefaultAzureCredential();

            string uri = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CostManagement/query?api-version=2022-10-01";

            QueryPayload queryPayload = new QueryPayload()
            {
                Type = "Usage",
                Timeframe = "MonthToDate",
                Dataset = new QueryDataset()
                {
                    Granularity = "None",
                    Grouping = new List<QueryGrouping>()
                    {
                        new QueryGrouping()
                        {
                            Type = "Dimension",
                            Name = "ResourceGroupName"
                        }
                    },
                    Aggregation = new Dictionary<string, QueryAggregation>()
                    {
                        {
                            "totalCost", new QueryAggregation()
                            {
                                Name = "PreTaxCost",
                                Function = "Sum"
                            }
                        }
                    }
                }
            };

            string payloadJson = JsonConvert.SerializeObject(queryPayload);

            HttpClient httpClient = new HttpClient();

            TokenRequestContext tokenRequestContext = new TokenRequestContext(new string[] { "https://management.azure.com/.default" });
            AccessToken token = credential.GetToken(tokenRequestContext);

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.Token}");

            HttpResponseMessage response = await httpClient.PostAsync(uri, new StringContent(payloadJson, Encoding.UTF8, "application/json"));
            string responseString = await response.Content.ReadAsStringAsync();

            decimal preTaxCost = 0;
            if (response.IsSuccessStatusCode)
            {
                JObject json = JObject.Parse(responseString);
                preTaxCost = json["properties"]["rows"][0][0].Value<decimal>();
            };

            var responseOut = req.CreateResponse(HttpStatusCode.OK);
            responseOut.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            responseOut.WriteString($"PreTaxCost: {preTaxCost}");

            return responseOut;
        }
    }
}