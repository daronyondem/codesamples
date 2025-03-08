from promptflow.core import tool
from openai import OpenAI

# Constants (adjust as needed)
CHAT_MODEL = "openchat-3.5-0106"
BASE_URL = "http://127.0.0.1:1234/v1"
API_KEY = "lm-studio"

# Initialize OpenAI client pointing to LM Studio
client = OpenAI(
    api_key=API_KEY,
    base_url=BASE_URL
)

@tool
def my_python_tool(input1: str) -> str:
    response = client.chat.completions.create(
        model=CHAT_MODEL,
        messages=[{"role": "user", "content": input1}],
        temperature=0.7
    )
    return response.choices[0].message.content.strip()
