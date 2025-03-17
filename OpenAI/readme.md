# OpenAI Samples

This directory contains examples, tools, and integrations for working with OpenAI models. The collection demonstrates various capabilities including prompt engineering, RAG implementations, plugin development, and serverless integrations.

## Directory Structure

### [intro](intro/)
Getting started resources for OpenAI and Azure OpenAI Service:

- `quickstart.ipynb`: Basic environment setup and API testing for OpenAI and Langchain
- `dall-e.ipynb`: Examples of GPT-4 Vision and DALL-E 3 image generation
- `langchain.ipynb`: Complete RAG (Retrieval Augmented Generation) pipeline implementation
- `dotnet-rag.ipynb`: RAG implementation using .NET libraries
- `azure-functions-June-2023-Updates.txt`: Sample data used in RAG demos
- `requirement.txt`: Dependencies for the sample notebooks

### [azure-functions](azure-functions/)
Integration of Azure Functions with OpenAI services:

- `IngestText.cs`: Function for ingesting and processing text for embedding
- `GenerateEmbeddings.cs`: Creates vector embeddings from text using OpenAI
- `RAGPrompting.cs`: Implements RAG pattern within Azure Functions
- Configuration files and HTTP test files

### [plug-in-development](plug-in-development/)
Tools for developing custom plugins for ChatGPT and other AI services:

- `sk-csharp-chatgpt-plugin`: Customized version of the Semantic Kernel ChatGPT plugin starter
- `sk-csharp-tester`: Semantic Kernel C# tester for validating plugins with OpenAI

### [prompt-engineering](prompt-engineering/)
Comprehensive materials for learning prompt engineering techniques:

- Educational notebooks covering core concepts, techniques, and best practices
- Labs for hands-on practice with real-world examples
- Prompt Flow examples demonstrating prompt chaining and evaluation
- Detailed setup instructions for both Azure OpenAI and local models

### [text-summarizer](text-summarizer/)
Text processing and summarization examples:

- `text-process.ipynb`: Notebook demonstrating text summarization techniques with OpenAI models

## Prerequisites

Each subdirectory may have specific requirements, but generally you'll need:

- Python 3.8+ or .NET 6+ (depending on the example)
- OpenAI API key or Azure OpenAI Service access
- Local environment for Jupyter notebooks or development IDE

## Getting Started

1. Clone the repository to your local machine
2. Navigate to the subdirectory that interests you
3. Follow the specific setup instructions in each section's README or notebook
4. For Python examples, install the required dependencies with `pip install -r requirements.txt`

## Related Resources

- [Azure OpenAI Service Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [OpenAI API Documentation](https://platform.openai.com/docs/)
- [Semantic Kernel GitHub Repository](https://github.com/microsoft/semantic-kernel)
- [Microsoft Prompt Flow](https://github.com/microsoft/promptflow)

## Contributing

Contributions and suggestions are welcome! If you'd like to contribute to this repository, please submit a pull request with your proposed changes or enhancements.