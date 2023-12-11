# COVID Dialogue Data Conversion Project for a Healthcare Analytics in Synapse Demo 

## Overview
This project is designed to parse and convert dialogue data related to COVID-19 from a text file into individual JSON files. The original data is sourced from the [UCSD AI4H COVID-Dialogue Dataset](https://github.com/UCSD-AI4H/COVID-Dialogue/blob/master/COVID-Dialogue-Dataset-English.txt).

## Features
- Reads dialogue data from a text file.
- Parses each dialogue entry, including ID, Description, and Dialogue sections.
- Converts each dialogue entry into a separate JSON file.

## Prerequisites
- .NET Core SDK

## Setup and Execution
1. Clone the repository to your local machine.
2. Ensure that the `.txt` file containing the COVID-19 dialogue data is placed in the root directory of the project, or update the file path in `Program.cs` accordingly.
3. Run the program using the command line or an IDE that supports .NET Core applications.
4. The program will generate JSON files for each dialogue entry in the same directory.

## File Descriptions
- `Program.cs`: The main C# file that contains the logic for reading, parsing, and writing the dialogue data.
- `COVID-Dialogue-Dataset-English.txt`: The original dataset file.

## Contributing
Contributions to this project are welcome. Please feel free to fork the repository, make changes, and submit a pull request.

The output of the conversion from source data to JSON files.

## Data Reference

```
@article{zeng2020coviddialogmodel,
  title={Develop Medical Dialogue Systems for COVID-19},
  author={Zeng, Guangtao and Wu, Qingyang and Zhang, Yichen and Yu, Zhou and Xing, Eric and Xie, Pengtao},
  journal={https://github.com/UCSD-AI4H/COVID-Dialogue}, 
  year={2020}
}
```
