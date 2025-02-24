import os
from autogen import AssistantAgent, UserProxyAgent

# Configure the LLM with local LLAMA
llm_config = {
    "config_list": [{
        "model": "llama-3.2-3b-instruct",  
        "base_url": "http://127.0.0.1:1234/v1",  # Local server address with /v1 for OpenAI API compatibility
        "api_key": "not-needed",  # Placeholder API key for local server
        "price": [0.0, 0.0],
        "temperature": 0.5,  # Lower temperature for more focused responses
        "max_tokens": 100
    }]
}

# Create the AssistantAgent
assistant = AssistantAgent(
    name="assistant",
    llm_config=llm_config,
    system_message="Respond in plain text only. Make sure you mark the end of your response with [END]"
)

# Create the UserProxyAgent with no human input and no code execution
user_proxy = UserProxyAgent(
    name="user_proxy",
    human_input_mode="NEVER",  # Fully autonomous, no human intervention
    code_execution_config=False,  # No code execution needed for this task
    is_termination_msg=lambda msg: "[END]" in msg["content"]
)

# Initiate the chat with a simple question
user_proxy.initiate_chat(
    assistant,
    message="What is the capital of France?",
    max_turns=3,  # Limit the conversation to 2 turns
    silent=False # Explicitly ensure messages are printed
)