from typing import List
from promptflow.core import log_metric, tool

@tool
def calculate_accuracy(grades: List[str]):
    result = []
    for index in range(len(grades)):
        grade = grades[index]
        result.append(grade)

    # calculate accuracy for each variant
    accuracy = round((result.count("PASSED") / len(result)), 2)
    log_metric("accuracy", accuracy)

    return result