# Prompt Chaining Example

This directory contains a Prompt Flow workflow that demonstrates the concept of prompt chaining - connecting multiple prompt components together to create a sophisticated pipeline.

## Overview

The workflow takes a simple text input and transforms it into executable code through a series of connected steps. Each step in the chain serves a specific purpose and passes its output to the next component.

## Flow Components

### 1. `generate_code_prompt.jinja2`
- **Type**: Prompt
- **Purpose**: Takes the initial text input and transforms it into a well-formed prompt for code generation
- **Input**: Raw text describing what code to generate
- **Output**: Structured prompt that guides the LLM to generate code

### 2. `generate_code.py`
- **Type**: Python
- **Purpose**: Uses the structured prompt to actually generate the code
- **Input**: The output from the `generate_code_prompt` component
- **Output**: Raw generated code

### 3. `cleanup.jinja2`
- **Type**: Prompt
- **Purpose**: Takes the generated code and refines it for clarity, efficiency, and best practices
- **Input**: The output from the `generate_code` component
- **Output**: Refined and improved code

### 4. `strip_code.py`
- **Type**: Python
- **Purpose**: Extracts just the code portion from the full response, removing any explanations or other text
- **Input**: The output from the `cleanup` component
- **Output**: Clean, final code ready for use

## How to Run

You can run this workflow using the Prompt Flow CLI:

```bash
# Navigate to this directory
cd prompt-chaining

# Run the flow
pf flow run --flow .
```

## Example Input

You can provide inputs like:

- "Create a function to calculate the fibonacci sequence"
- "Write a simple web server in Python"
- "Generate a JavaScript function to validate email addresses"

The workflow will transform these simple requests into executable code through the chain of prompts.

## Configuration

The flow is configured in the `flow.dag.yaml` file, which defines how the components are connected and how data flows between them. You can modify this file to adjust the workflow or add additional components.

## Requirements

Make sure you have the necessary dependencies installed, which are listed in the `requirements.txt` file.