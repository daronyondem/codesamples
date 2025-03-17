# Azure Functions with OpenAI Integration

This project demonstrates how to integrate Azure Functions with OpenAI services to implement a Retrieval Augmented Generation (RAG) pattern for enhanced AI responses.

## Project Overview

The solution implements a serverless approach to:
1. Ingest and process text content
2. Generate vector embeddings using OpenAI models
3. Perform RAG-based prompting for contextually enriched responses

## Components

### Core Functions

- **IngestText.cs**: HTTP-triggered function that accepts text input and prepares it for embedding
  - Processes and splits text into appropriate chunks
  - Saves processed text segments to storage for later embedding

- **GenerateEmbeddings.cs**: Creates vector embeddings from processed text
  - Uses OpenAI embedding models to vectorize text segments
  - Stores embeddings in a vector database for semantic search

- **RAGPrompting.cs**: Implements the RAG pattern to enhance AI responses
  - Takes user queries and finds relevant context using vector similarity
  - Augments prompts with retrieved context before submitting to OpenAI
  - Returns enhanced responses that incorporate relevant knowledge

### Supporting Files

- **demo.http**: Contains sample HTTP requests for testing the functions
- **settings.json**: Configuration settings for the Azure Function app
- **azure-functions.csproj/sln**: Project and solution files for the .NET implementation

## Prerequisites

- Azure subscription
- Azure Functions Core Tools
- .NET 6.0 or later
- Azure OpenAI Service or OpenAI API access
- Vector database (Azure Cognitive Search with vector support or similar)

## Local Development

1. Clone the repository
2. Create a `local.settings.json` file with the necessary configuration:
   ```json
   {
     "IsEncrypted": false,
     "Values": {
       "AzureWebJobsStorage": "UseDevelopmentStorage=true",
       "FUNCTIONS_WORKER_RUNTIME": "dotnet",
       "OpenAIKey": "your-key-here",
       "OpenAIEndpoint": "your-endpoint-here",
       "VectorDBConnection": "your-connection-string"
     }
   }
   ```
3. Run the project using `func start` or through Visual Studio/VS Code

## Usage

The included `demo.http` file demonstrates how to:

1. Ingest text with a POST request to the IngestText function
2. Generate embeddings by triggering the GenerateEmbeddings function
3. Perform RAG-based queries via the RAGPrompting function

## Deployment

Deploy to Azure using:
- Azure Functions extension for VS Code
- Visual Studio publishing
- Azure CLI
- GitHub Actions CI/CD

## Additional Resources

- [Azure Functions Documentation](https://docs.microsoft.com/en-us/azure/azure-functions/)
- [Azure OpenAI Service Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Implementing RAG patterns](https://learn.microsoft.com/en-us/azure/search/retrieval-augmented-generation-overview)