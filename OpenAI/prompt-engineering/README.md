# Prompt Engineering Examples and Labs

This repository contains a comprehensive collection of educational materials and hands-on labs for learning prompt engineering techniques and strategies for working with Large Language Models (LLMs).

## About

The main educational notebooks are designed to work with the Azure OpenAI service using the `gpt-35-turbo` model (version 0125). This model version is set to expire on Azure OpenAI on May 31, 2025 3:00 AM. For more details on the expiration timeline, please see [Microsoft's Model Retirement documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/model-retirements).

The hands-on labs use a local approach with LM Studio and OpenChat-3.5, providing a practical way to experiment with prompt engineering without Azure OpenAI access.

## Contents

The repository includes the following notebooks:

- **00_starter.ipynb**: Basic setup for Azure OpenAI API connections
- **01_intro.ipynb**: Introduction to core prompt engineering concepts
- **02_techniques.ipynb**: Advanced prompt engineering techniques
- **03_summarization.ipynb**: Text summarization techniques
- **04_inference.ipynb**: Inference techniques
- **05_transformation.ipynb**: Text transformation examples
- **06_responsibility.ipynb**: Responsible AI practices

## Hands-on Labs

The `labs` directory contains interactive hands-on exercises for practicing prompt engineering concepts:

- **01_intro.ipynb**: Getting started with LM Studio and making basic prompt calls
- **02_core_prompting.ipynb**: Core prompting techniques and best practices
- **03-advanced-prompting.ipynb**: Advanced prompting strategies and methods
- **04-security.ipynb**: Security considerations in prompt engineering
- **05-rag.ipynb**: Implementing Retrieval-Augmented Generation (RAG)

## Prompt Flow Examples

This repository also includes examples using Microsoft's Prompt Flow tool, a framework for building, evaluating, and deploying LLM-powered workflows:

- **[prompt-chaining](./promptflow/prompt-chaining)**: Demonstrates how to create multi-step prompt chains where the output from one node serves as input to the next
  - Includes a workflow that generates code based on text input and processes the result through multiple steps
  
- **[chain-evaluation](./promptflow/chain-evaluation)**: Shows methods to evaluate code generation quality
  - Features a code evaluator that grades generated code against requirements
  - Includes an aggregation component that combines evaluation results

## Setup

### For Jupyter Notebooks

1. Install [Anaconda](https://www.anaconda.com/download).

2. Install the required packages:

```ps
conda env create --file=environment.yml
conda activate prompten
```

3. Create a `.env` file with your Azure OpenAI credentials based on the `.env.example` file.

4. For the responsibility examples (`06_responsibility.ipynb`):
   - Download and install [LM Studio](https://lmstudio.ai/)
   - Download the [openchat-3.5-0106 model from TheBloke](https://model.lmstudio.ai/download/TheBloke/openchat-3.5-0106-GGUF)
   - Start the local server in LM Studio and use the configuration shown in the notebook

### For Prompt Flow Examples

1. Install the Azure Prompt Flow SDK:

```ps
pip install promptflow
```

2. Navigate to the specific example directory and run:

```ps
pf flow run --flow .
```

## Repository Structure

```
prompt-engineering/
├── *.ipynb                 # Main educational notebooks
├── environment.yml         # Conda environment specification
├── .env.example            # Template for Azure OpenAI credentials
├── labs/                   # Hands-on practical exercises
│   └── *.ipynb             # Interactive lab notebooks
├── promptflow/             # Microsoft Prompt Flow examples
│   ├── prompt-chaining/    # Multi-step prompt chain workflow
│   └── chain-evaluation/   # Code evaluation workflow
└── images/                 # Supporting images for notebooks
```

## References

The techniques demonstrated in these notebooks are based on academic research and industry best practices in prompt engineering, including:

- Chain-of-Thought Prompting
- Few-Shot Learning
- Retrieval-Augmented Generation (RAG)
- Tree of Thoughts (ToT)
- Self-Consistency

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is intended for educational purposes. Please use responsibly and ensure any derivative work complies with the licenses of the underlying models and tools used.