import os
from autogen import AssistantAgent, GroupChat, GroupChatManager, UserProxyAgent

# Configure the LLM with local LLAMA
llm_config = {
    "config_list": [{
        "model": "llama-3.2-3b-instruct",
        "base_url": "http://127.0.0.1:1234/v1",  # Local server address with /v1 for OpenAI API compatibility
        "api_key": "not-needed",                # Placeholder API key for local server
        "price": [0.0, 0.0],
    }],
    "temperature": 0.5,                          
    "max_tokens": 100                            
}

manager = AssistantAgent(
    name="Manager",
    llm_config=llm_config,
    system_message="You are the Project Manager. Your role is to break down the project into tasks and delegate them to the appropriate agents: Data Gatherer, Analyst, or Writer. Start by assigning the first task to the Data Gatherer. When the project is complete, include '[END]' in your message to end the conversation."
)

data_gatherer = AssistantAgent(
    name="Data_Gatherer",
    llm_config=llm_config,
    system_message="You are the Data Gatherer. When the Project Manager asks you to collect data, provide a summary of the data on the given topic."
)

analyst = AssistantAgent(
    name="Analyst",
    llm_config=llm_config,
    system_message="You are the Analyst. When the Project Manager provides you with data, analyze it and provide key insights."
)

writer = AssistantAgent(
    name="Writer",
    llm_config=llm_config,
    system_message="You are the Writer. When the Project Manager provides you with analysis, write a concise report based on it."
)

def select_speaker(last_speaker, groupchat):
    # If there are no messages yet, start with the manager
    if not groupchat.messages:
        return manager  # Replace 'manager' with your actual Manager agent object

    # Get the most recent message
    last_message = groupchat.messages[-1]
    content = last_message["content"]
    last_speaker_name = last_message["name"]

    # End the conversation if "[END]" is in the message
    if "[END]" in content:
        return None

    # Determine the next speaker based on the last speaker and message content
    if last_speaker_name == "Manager":
        if "Data Gatherer" in content:
            return data_gatherer  
        elif "Analyst" in content:
            return analyst       
        elif "Writer" in content:
            return writer        
        else:
            return manager       
    elif last_speaker_name in ["Data_Gatherer", "Analyst", "Writer"]:
        return manager           # Return to Manager after other agents speak
    else:
        return manager           # Fallback to Manager for unexpected cases
    
groupchat = GroupChat(
    agents=[manager, data_gatherer, analyst, writer],
    messages=[],
    max_round=50,
    speaker_selection_method=select_speaker
)

groupchat_manager = GroupChatManager(
    groupchat=groupchat,
    llm_config=llm_config
)

user_proxy = UserProxyAgent(
    name="user_proxy",
    human_input_mode="NEVER",
    code_execution_config=False,
)

user_proxy.initiate_chat(
    groupchat_manager,
    message="Please start the project to create a report on current trends in artificial intelligence."
)

# Save the final report to a local TXT file
writer_messages = [msg for msg in groupchat.messages if msg["name"] == "Writer"]
if writer_messages:
    report_content = writer_messages[-1]["content"]
    with open("ai_trends_report.txt", "w") as f:
        f.write(report_content)
    print("Report saved to ai_trends_report.txt")
else:
    print("No report was generated by the Writer.")