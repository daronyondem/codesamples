# Prompt Engineering Examples

This repository contains a collection of Jupyter notebooks demonstrating various prompt engineering techniques and strategies for working with Large Language Models (LLMs).

## About

These examples are designed to work with the Azure OpenAI service using the `gpt-35-turbo` model (version 0125). This model version is set to expire on Azure OpenAI on May 31, 2025 3:00 AM. For more details on the expiration timeline, please see [Microsoft's Model Retirement documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/model-retirements).

## Contents

The repository includes the following notebooks:

- **00_starter.ipynb**: Basic setup for Azure OpenAI API connections
- **01_intro.ipynb**: Introduction to core prompt engineering concepts
- **02_techniques.ipynb**: Advanced prompt engineering techniques
- **03_summarization.ipynb**: Text summarization techniques
- **04_inference.ipynb**: Inference techniques
- **05_transformation.ipynb**: Text transformation examples
- **06_responsibility.ipynb**: Responsible AI practices

## Prompt Flow Examples

This repository also includes examples using Microsoft's Prompt Flow tool:

- **Flow orchestration**: Examples of managing complex prompt chains and workflows
- **Evaluation techniques**: Methods to assess the quality and performance of prompts

## Setup

1. Install the required packages:

```ps
conda env create -f environment.yml
conda activate prompten
```

2. Create a `.env` file with your Azure OpenAI credentials based on the `.env.example` file.

3. For the responsibility examples (`06_responsibility.ipynb`):
   - Download and install [LM Studio](https://lmstudio.ai/)
   - Download the [openchat-3.5-0106 model from TheBloke](https://model.lmstudio.ai/download/TheBloke/openchat-3.5-0106-GGUF)
   - Start the local server in LM Studio and use the configuration shown in the notebook

## References

The techniques demonstrated in these notebooks are based on academic research and industry best practices in prompt engineering.