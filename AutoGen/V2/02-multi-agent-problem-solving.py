import os
from dotenv import load_dotenv
from autogen import AssistantAgent, UserProxyAgent
from autogen import ConversableAgent, register_function
from typing import Any, Dict, List
from spider import Spider
from typing_extensions import Annotated

# Load environment variables from .env file
load_dotenv()

def scrape_page(
    url: Annotated[str, "The URL of the web page to scrape"],
    params: Annotated[dict, "Dictionary of additional params."] = None,
) -> Annotated[Dict[str, Any], "Scraped content"]:
    # Initialize the Spider client with your API key, if no api key is specified it looks for SPIDER_API_KEY in your environment variables
    client = Spider(spider_api_key)

    if params is None:
        params = {"return_format": "markdown"}

    scraped_data = client.scrape_url(url, params)
    return scraped_data[0]


def crawl_page(
    url: Annotated[str, "The url of the domain to be crawled"],
    params: Annotated[dict, "Dictionary of additional params."] = None,
) -> Annotated[List[Dict[str, Any]], "Scraped content"]:
    # Initialize the Spider client with your API key, if no api key is specified it looks for SPIDER_API_KEY in your environment variables
    client = Spider(spider_api_key)

    if params is None:
        params = {"return_format": "markdown"}

    crawled_data = client.crawl_url(url, params)
    return crawled_data

# Configure the LLM with local LLAMA
llm_config = {
    "config_list": [{
        "model": "llama-3.2-3b-instruct",  
        "base_url": "http://127.0.0.1:1234/v1",  # Local server address with /v1 for OpenAI API compatibility
        "api_key": "not-needed",  # Placeholder API key for local server
        "price": [0.0, 0.0],
        "temperature": 0.5,  # Lower temperature for more focused responses
        "max_tokens": 5000
    }]
}

spider_api_key = os.getenv("SPIDER_API_KEY") 

# Create web scraper agent.
scraper_agent = ConversableAgent(
    "WebScraper",
    llm_config=llm_config,
    human_input_mode="NEVER",
    system_message="You are a web scraper and you can scrape any web page to retrieve its contents."
    " Make sure you mark the end of your response with [END].",
)

# Create user proxy agent.
user_proxy_agent = ConversableAgent(
    "UserProxy",
    llm_config=False,  # No LLM for this agent.
    human_input_mode="NEVER",
    code_execution_config=False,  # No code execution for this agent.
    is_termination_msg=lambda x: x.get("content", "") is not None and "END" in x["content"],
    default_auto_reply="Please continue if not finished, otherwise return 'END'.",
)

# Register the functions with the agents.
register_function(
    scrape_page,
    caller=scraper_agent,
    executor=user_proxy_agent,
    name="scrape_page",
    description="Scrape a web page and return the content.",
)
# Scrape page
scraped_chat_result = user_proxy_agent.initiate_chat(
    scraper_agent,
    message="Based on https://daron.coach/ and https://daron.me/. Who is Daron Yondem? Give me your findings and write [END] when you are done.",
    max_turns=3,
    summary_method="reflection_with_llm",
    summary_args={"summary_prompt": """Summarize the content"""},
)