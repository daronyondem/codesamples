# OpenAI Introduction Examples

This directory contains introductory examples and notebooks for working with OpenAI and Azure OpenAI services. These examples serve as a starting point for understanding how to use OpenAI's capabilities in various scenarios.

## Contents

### Notebooks

- **[quickstart.ipynb](quickstart.ipynb)**: A simple notebook to test your local environment
  - Verifies your API connections to OpenAI or Azure OpenAI
  - Tests compatibility with both OpenAI and LangChain libraries
  - Includes basic examples of generating completions

- **[dall-e.ipynb](dall-e.ipynb)**: Examples of image generation and analysis
  - Demonstrates GPT-4 Vision capabilities for image understanding
  - Shows how to use DALL-E 3 for generating images from text descriptions
  - Includes examples of image variations and modifications

- **[langchain.ipynb](langchain.ipynb)**: Complete RAG (Retrieval Augmented Generation) implementation
  - Demonstrates creating embeddings from text
  - Shows how to store embeddings in a vector database
  - Implements hybrid search (keyword + semantic)
  - Compares standard LLM responses with RAG-enhanced responses

- **[dotnet-rag.ipynb](dotnet-rag.ipynb)**: RAG implementation using .NET libraries
  - Shows how to build RAG systems in a .NET environment
  - Demonstrates integration with Semantic Kernel
  - Includes vector search and context augmentation techniques
  
- **[4o-transcribe.ipynb](4o-transcribe.ipynb)**: Audio transcription with GPT-4o-transcribe
  - Splits long audio files into manageable chunks for improved accuracy
  - Processes audio transcription using OpenAI's GPT-4o-transcribe model
  - Combines chunks into a single transcription output
  - Supports language specification for better transcription results

### Supporting Files

- **[azure-functions-June-2023-Updates.txt](azure-functions-June-2023-Updates.txt)**: Sample text data used in the RAG demonstrations
- **[requirement.txt](requirement.txt)**: Lists all dependencies needed to run the notebooks
- **chunks/**: Directory created by the 4o-transcribe.ipynb notebook to store audio chunks for processing

## Prerequisites

To run these examples, you'll need:

1. An OpenAI API key or Azure OpenAI Service access
2. Python 3.8 or higher
3. Jupyter Notebook environment
4. Required Python packages (listed in `requirement.txt`)
5. FFmpeg installed on your system (required for audio processing in `4o-transcribe.ipynb`)

## Setup Instructions

1. Create a virtual environment (recommended):
   ```
   python -m venv openai-env
   source openai-env/bin/activate  # On Windows: openai-env\Scripts\activate
   ```

2. Install the required packages:
   ```
   pip install -r requirement.txt
   ```

3. Create a `.env` file with your API credentials:
   ```
   OPENAI_API_KEY=your_openai_api_key
   # Or for Azure OpenAI:
   AZURE_OPENAI_KEY=your_azure_openai_key
   AZURE_OPENAI_ENDPOINT=your_azure_openai_endpoint
   ```

4. Launch Jupyter Notebook and open the desired example:
   ```
   jupyter notebook
   ```

## Getting Started

Start with the `quickstart.ipynb` notebook to verify your environment setup, then proceed to the other examples based on your interests:

- For image generation and analysis: `dall-e.ipynb`
- For RAG implementations: `langchain.ipynb` or `dotnet-rag.ipynb`
- For audio transcription: `4o-transcribe.ipynb`

Each notebook includes detailed comments and explanations to guide you through the examples.