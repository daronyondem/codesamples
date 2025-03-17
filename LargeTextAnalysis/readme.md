# Large Text Analysis

## Overview
This repository contains the Large Text Analysis project, a serverless application designed to process and analyze large text documents. It utilizes Azure Functions, specifically Durable Functions, to handle large texts by breaking them down into smaller segments, extracting key phrases, and aggregating the results.

## Architecture
The project implements a distributed text processing architecture with these components:

- **[Analyze.cs](Analyze.cs)**: An HTTP-triggered function that initializes the analysis process
  - Accepts a document URL through a query parameter
  - Retrieves the text document
  - Splits the content into manageable segments
  - Starts the orchestration process

- **[TextAnalyticsOrchestrator.cs](TextAnalyticsOrchestrator.cs)**: Coordinates the entire processing pipeline
  - Manages parallel processing of text segments
  - Handles retry logic for failed operations
  - Aggregates results from all segments
  - Returns a consolidated set of key phrases

- **[TextAnalyticsActivity.cs](TextAnalyticsActivity.cs)**: Performs the actual text analysis
  - Processes individual text segments
  - Connects to Azure AI Text Analytics service
  - Extracts key phrases, entities, and sentiment
  - Returns structured analysis results

## Solution Structure
- **[LargeTextAnalysis.csproj](LargeTextAnalysis.csproj)**: Project file with dependencies
- **[LargeTextAnalysis.sln](LargeTextAnalysis.sln)**: Solution file for Visual Studio
- **[host.json](host.json)**: Azure Functions host configuration
- **[Properties/](Properties/)**: Contains project properties and launchSettings

## Prerequisites
- Azure subscription
- Azure Functions Core Tools (v4+)
- .NET 6.0 SDK or later
- Azure AI Text Analytics resource

## Configuration
Set the following environment variables in your Azure Functions configuration:
- `TextAnalyticsKey`: Your Azure Text Analytics API key
- `TextAnalyticsEndpoint`: The endpoint URL for the Azure Text Analytics service

## Local Development
1. Clone the repository
2. Create a `local.settings.json` file with your configuration values
3. Run `func start` to test locally

## Deployment
1. Deploy to Azure Functions using Visual Studio, VS Code, or Azure CLI
2. Configure application settings in the Azure portal
3. Test the deployed function with a sample document URL

## Usage Example
```http
GET|POST https://<your-function-app>.azurewebsites.net/api/Analyze?documentUrl=https://example.com/sample-document.txt
```

Response will include a JSON payload with key phrases extracted from the document and optionally sentiment analysis results.

## Performance Considerations
- For very large documents (10MB+), consider increasing function timeout settings
- The system automatically handles parallelization based on document size
- Default segment size is optimized for Azure Text Analytics API limits

## Contributing
Contributions to the Large Text Analysis project are welcome. Please ensure that your code adheres to the project's coding standards.
