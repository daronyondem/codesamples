# Code Evaluation Workflow

This directory contains a Prompt Flow workflow designed to evaluate the quality of LLM-generated code against specific requirements.

## Overview

The workflow takes two inputs:
1. Requirements: A description of what the code should accomplish
2. Generated code: The code to be evaluated

It then analyzes how well the generated code meets the specified requirements and produces a detailed evaluation.

## Flow Components

### 1. `code_evaluator.py`
- **Type**: Python
- **Purpose**: Evaluates the generated code against specified requirements
- **Inputs**: 
  - `requirements`: A string describing what the code should do
  - `generated_code`: The code to evaluate
- **Output**: A detailed assessment with scores and feedback

### 2. `aggregator.py`
- **Type**: Python 
- **Purpose**: Combines and summarizes evaluation results, especially useful when evaluating multiple samples
- **Input**: Grades from the code evaluator
- **Output**: Aggregated evaluation metrics

The `aggregator` node is marked with `aggregation: true` which means it's designed to run after all other evaluations to produce summary statistics and insights across multiple runs.

## How to Run

You can run this workflow using the Prompt Flow CLI:

```bash
# Navigate to this directory
cd chain-evaluation

# Run the flow with a single evaluation
pf flow run --flow . --inputs ask="Create a function to sort an array" code="def sort_array(arr): return sorted(arr)"

# Run batch evaluations
pf flow test --flow . --test-file default.flow_test.yaml
```

## Evaluation Criteria

The evaluation typically looks at several aspects of code quality:

- **Correctness**: Does the code produce the expected output?
- **Completeness**: Does the code address all requirements?
- **Efficiency**: Is the solution optimal in terms of time and space complexity?
- **Style**: Does the code follow best practices and conventions?
- **Documentation**: Is the code well-commented and easy to understand?

## Use Cases

This evaluation workflow is particularly useful for:

- Comparing different prompt engineering approaches for code generation
- Fine-tuning LLMs for improved coding capabilities
- Benchmarking different models' coding abilities
- Creating consistent evaluation criteria for generated code

## Requirements

Make sure you have the necessary dependencies installed, which are listed in the `requirements.txt` file.