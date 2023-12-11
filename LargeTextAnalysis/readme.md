# Large Text Analysis

## Overview
This repository contains the Large Text Analysis project, a serverless application designed to process and analyze large text documents. It utilizes Azure Functions, specifically Durable Functions, to handle large texts by breaking them down into smaller segments, extracting key phrases, and aggregating the results. The project consists of three main components: `Analyze`, `TextAnalyticsActivity`, and `TextAnalyticsOrchestrator`.

## Components
- `Analyze`: An HTTP-triggered function that splits the text into manageable segments and starts the analysis process.
- `TextAnalyticsActivity`: An Azure Function that extracts key phrases from each text segment using Azure AI Text Analytics.
- `TextAnalyticsOrchestrator`: Orchestrates the processing of text segments and aggregates the final set of key phrases.

## Prerequisites
- Azure subscription
- Azure Functions environment
- Azure AI Text Analytics resource

## Configuration
Set the following environment variables in your Azure Functions configuration:
- `TextAnalyticsKey`: Your Azure Text Analytics API key.
- `TextAnalyticsEndpoint`: The endpoint URL for the Azure Text Analytics service.

## Usage
1. Deploy the functions to your Azure Functions environment.
2. Send an HTTP request (GET or POST) to the `Analyze` function with the query parameter `documentUrl` pointing to the URL of the text document you want to analyze.
3. The function will return a response that allows you to check the status of the analysis.

## Example
HTTP request to the `Analyze` function: `http://<your-function-app-name>.azurewebsites.net/api/Analyze?documentUrl=<URL-of-text-document>`

## Contributing
Contributions to the Large Text Analysis project are welcome. Please ensure that your code adheres to the project's coding standards.

