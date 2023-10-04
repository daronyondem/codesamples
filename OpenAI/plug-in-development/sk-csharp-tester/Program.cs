using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Planning;
using Microsoft.SemanticKernel.Skills.OpenAPI.Extensions;
using Microsoft.Extensions.Configuration;
using System.IO;

// Define configuration keys
const string ConfigKeyAzureOpenAIDeploymentName = "AzureOpenAI:DeploymentName";
const string ConfigKeyAzureOpenAIEndpoint = "AzureOpenAI:Endpoint";
const string ConfigKeyAzureOpenAIKey = "AzureOpenAI:Key";
const string ConfigKeyPluginManifestUrl = "PluginManifestUrl";

// Check if configuration file exists
string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
if (!File.Exists(configFilePath))
{
    throw new FileNotFoundException($"Configuration file not found: {configFilePath}");
}

// Load configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var kernel = new KernelBuilder().WithAzureChatCompletionService(
    configuration["AzureOpenAI:DeploymentName"],
    configuration["AzureOpenAI:Endpoint"],
    configuration["AzureOpenAI:Key"]
).Build();

// Initialize Azure chat completion service with configuration values
var kernel = new KernelBuilder().WithAzureChatCompletionService(
    configuration[ConfigKeyAzureOpenAIDeploymentName],
    configuration[ConfigKeyAzureOpenAIEndpoint],
    configuration[ConfigKeyAzureOpenAIKey]
).Build();

using HttpClient httpClient = new();

// Import AI plugin
string pluginManifestUrl = configuration[ConfigKeyPluginManifestUrl];
var plugin = await kernel.ImportAIPluginAsync("PurchaseOrders", new Uri(pluginManifestUrl), new OpenApiSkillExecutionParameters(httpClient) { EnableDynamicPayload = true });

// Create a stepwise planner and invoke it
var planner = new StepwisePlanner(kernel);
var question = "Whats the status of PO number 230?";
var plan = planner.CreatePlan(question);
var result = await plan.InvokeAsync(kernel.CreateNewContext());

// Print the results
Console.WriteLine("Result: " + result);

// Print details about the plan
if (result.Variables.TryGetValue("stepCount", out string? stepCount))
{
    Console.WriteLine("Step Count: " + stepCount);
}
if (result.Variables.TryGetValue("skillCount", out string? skillCount))
{
    Console.WriteLine("Skills Used: " + skillCount);
}