from promptflow.core import tool
import ast

@tool
def evaluate_code(generated_code: str, requirements: str) -> str:
    """
    Evaluate only the syntax of the generated code. 
    Return 'PASSED' if code is syntactically valid, 
    otherwise return an error message.
    """
    try:
        ast.parse(generated_code)
        return "PASSED"
    except SyntaxError as e:
        return f"FAILED"