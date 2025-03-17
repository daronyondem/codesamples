# Prompt Flow Examples

This directory contains examples of using Microsoft's Prompt Flow framework to build and evaluate LLM-powered workflows. Prompt Flow enables you to create multi-step pipelines where the output of one step serves as input to the next, allowing for complex prompt engineering patterns.

## Contents

### 1. [prompt-chaining](./prompt-chaining)

A demonstration of chaining multiple prompts together to create a sophisticated workflow:

- **Purpose**: Generates code based on a text description through a series of processing steps
- **Flow**:
  1. `generate_code_prompt.jinja2`: Creates a prompt based on the input text
  2. `generate_code.py`: Uses the prompt to generate code
  3. `cleanup.jinja2`: Refines and improves the generated code
  4. `strip_code.py`: Extracts and formats the final code

This example shows how to break down complex tasks into smaller, more manageable steps that feed into each other.

### 2. [chain-evaluation](./chain-evaluation)

Demonstrates methods to evaluate code generation quality:

- **Purpose**: Evaluates generated code against specified requirements
- **Components**:
  1. `code_evaluator.py`: Grades generated code against requirements
  2. `aggregator.py`: Combines and summarizes evaluation results

This example showcases how to implement evaluation mechanisms for LLM outputs, which is crucial for quality assessment and improvement.

## Getting Started

Each subdirectory contains a complete Prompt Flow workflow that can be run using the Prompt Flow CLI:

```bash
# Navigate to the specific example directory
cd prompt-chaining
# or
cd chain-evaluation

# Run the flow
pf flow run --flow .
```

A `test_run.jsonl` file is included in the main promptflow directory, which can be used to test the workflows with sample inputs.

## Requirements

Each workflow has its own `requirements.txt` file specifying the necessary dependencies. To get started with Prompt Flow, install the SDK:

```bash
pip install promptflow
```

For more information on Prompt Flow, visit [Microsoft's Prompt Flow documentation](https://learn.microsoft.com/en-us/azure/machine-learning/prompt-flow/overview-what-is-prompt-flow).