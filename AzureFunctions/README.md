# Azure Functions Samples

This directory contains a collection of Azure Functions samples demonstrating various capabilities and patterns for serverless application development on Azure.

## Project Structure

The samples are organized into two main categories:

### [In-Process](In-Process)

Contains examples using the in-process model (traditional model) for Azure Functions:

- **Durable-Entities**: Demonstrates using Durable Entities for stateful serverless applications
- **Eventing**: Examples for event-driven architectures with Azure Functions
- **FunctionFilters**: Function middleware and filter implementations
- **ImageResizer**: Image processing and resizing functions
- **LoadTesting**: Samples for load testing Azure Functions
- **ManagedIdentity**: Using managed identities for secure access to Azure resources
- **OpenAPI**: OpenAPI/Swagger integration with Azure Functions
- **QueueBinding**: Working with Azure Storage Queues
- **TimerTrigger**: Scheduled execution using timer triggers
- **WebPubSub**: Real-time communication using Azure Web PubSub service

### [Isolated](Isolated)

Examples using the isolated process model for Azure Functions:

- **Image Processing**: Image resizing implementation in the isolated model
- **Queue Operations**: Azure Storage Queue processing examples
- **HTTP Operations**: HTTP-triggered functions with various patterns
- **Consumption Monitoring**: Functions that monitor consumption metrics

## Getting Started

Each sample includes the necessary code and configuration to run. To use these samples:

1. Install the [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)
2. Install the [.NET SDK](https://dotnet.microsoft.com/download)
3. Navigate to the specific sample directory
4. Run the sample locally using `func start` or deploy to Azure

## Prerequisites

- Azure subscription
- .NET SDK (version varies by sample)
- Azure Functions Core Tools
- Visual Studio or Visual Studio Code (recommended)

## Additional Resources

- [Azure Functions Documentation](https://docs.microsoft.com/en-us/azure/azure-functions/)
- [Azure Functions on GitHub](https://github.com/Azure/Azure-Functions)
- [Azure Serverless Community Library](https://www.serverlesslibrary.net/)