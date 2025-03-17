# Prompt Engineering Hands-on Labs

This directory contains interactive Jupyter notebooks that provide hands-on exercises for practicing prompt engineering concepts. These labs are designed to complement the main educational notebooks in the repository root.

## Lab Contents

### 1. [01_intro.ipynb](./01_intro.ipynb)
**Getting Started with LM Studio and Prompt Calls**

This introductory lab guides you through setting up a local LLM environment with LM Studio and making basic prompt calls. You'll learn to:
- Connect to the local LM Studio server from code
- Send both completion and chat requests to the OpenChat-3.5 model
- Experiment with different generation settings and observe their effects
- Understand how token limits impact prompts and outputs

### 2. [02_core_prompting.ipynb](./02_core_prompting.ipynb)
**Core Prompting Techniques and Best Practices**

This lab covers fundamental prompt engineering concepts and techniques to improve the quality and relevance of LLM responses.

### 3. [03-advanced-prompting.ipynb](./03-advanced-prompting.ipynb)
**Advanced Prompting Strategies and Methods**

This lab explores more sophisticated prompting strategies including:
- Chain-of-thought prompting
- Few-shot learning examples
- Structured output formatting
- Advanced system prompts

### 4. [04-security.ipynb](./04-security.ipynb)
**Security Considerations in Prompt Engineering**

This lab focuses on security aspects of prompt engineering:
- Understanding prompt injection attacks
- Implementing safeguards against common vulnerabilities
- Best practices for secure prompt design
- Testing prompts for security issues

### 5. [05-rag.ipynb](./05-rag.ipynb)
**Implementing Retrieval-Augmented Generation (RAG)**

This comprehensive lab walks through building a RAG system:
- Setting up a local LLM with LM Studio
- Creating and processing a document database
- Setting up a vector database for document retrieval
- Generating embeddings for efficient semantic search
- Comparing model responses with and without RAG
- Evaluating the improvement in accuracy and relevance

## How to Use These Labs

1. Ensure you have the necessary environment set up:
   - Install Anaconda and create the environment using the `environment.yml` file in the repository root
   - For some labs, you'll need LM Studio with the OpenChat-3.5 model

2. Start with lab 01 and progress sequentially for the best learning experience

3. Each lab contains practical exercises and explanations that build upon concepts from the main educational notebooks

4. Experiment by modifying the code and prompts to deepen your understanding

These labs offer practical, hands-on experience to help you develop effective prompt engineering skills for working with large language models.