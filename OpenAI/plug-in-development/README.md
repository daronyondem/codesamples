# ChatGPT Plugin Development

This directory contains starter projects and samples for developing plugins that extend the capabilities of ChatGPT and other OpenAI-compatible services.

## Projects

The directory includes two main projects:

### [sk-csharp-chatgpt-plugin](sk-csharp-chatgpt-plugin/)

A customized version of the Semantic Kernel ChatGPT plugin starter, which provides:

- Ready-to-use template for creating ChatGPT plugins using C# and Semantic Kernel
- Azure Function implementation for hosting plugin endpoints
- OpenAPI specification for plugin discovery and integration
- Authentication mechanisms for secure plugin usage
- Sample skills that can be extended or customized

### [sk-csharp-tester](sk-csharp-tester/)

A Semantic Kernel C# Hello World Starter project for testing plugins with OpenAI:

- Console application for local testing of plugins
- Integration with Semantic Kernel for plugin execution
- Example code for connecting to OpenAI services
- Utility methods for validating plugin functionality

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- Azure subscription (for deploying the Azure Function)
- OpenAI API key or Azure OpenAI Service access
- (Optional) Visual Studio 2022 or Visual Studio Code

### Setup for ChatGPT Plugin

1. Navigate to the `sk-csharp-chatgpt-plugin` directory
2. Follow the instructions in the project's README to:
   - Configure API keys and endpoints
   - Build and run the Azure Function locally
   - Deploy to Azure (optional)
   - Register with ChatGPT as a plugin

### Setup for Plugin Tester

1. Navigate to the `sk-csharp-tester` directory
2. Configure your API settings in the project
3. Run the application to test plugin functionality locally

## Plugin Development Process

1. **Define your plugin's functionality**: Determine what capabilities you want to add to ChatGPT
2. **Implement as Semantic Kernel skills**: Create C# classes that implement the desired functionality
3. **Configure the OpenAPI specification**: Update the plugin manifest and API endpoints
4. **Test locally** using the sk-csharp-tester project
5. **Deploy and register**: Deploy to Azure and register with ChatGPT

## Additional Resources

- [ChatGPT Plugins Documentation](https://platform.openai.com/docs/plugins/introduction)
- [Semantic Kernel GitHub Repository](https://github.com/microsoft/semantic-kernel)
- [Microsoft Learn: Build ChatGPT Plugins](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/plugins)