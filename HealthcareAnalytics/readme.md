# COVID Dialogue Data Conversion Project for Healthcare Analytics in Synapse Demo

## Overview
This project is designed to parse and convert dialogue data related to COVID-19 from a text file into individual JSON files. The processed data is intended for use in Azure Synapse Analytics for healthcare analytics demonstrations. The original data is sourced from the [UCSD AI4H COVID-Dialogue Dataset](https://github.com/UCSD-AI4H/COVID-Dialogue/blob/master/COVID-Dialogue-Dataset-English.txt).

## Repository Structure
- **[DataConversion](DataConversion/)**: Contains the C# project for data conversion
  - `Program.cs`: The main C# file with the logic for reading, parsing, and writing the dialogue data
  - `DataConversion.csproj`: The project file for the .NET application
  - `DataConversion.sln`: The solution file for Visual Studio
  - `COVID-Dialogue-Dataset-English.txt`: The original dataset file
- **[SampleData](SampleData/)**: Contains sample data files and processed outputs

## Features
- Reads dialogue data from a text file
- Parses each dialogue entry, including ID, Description, and Dialogue sections
- Converts each dialogue entry into a separate JSON file for easy consumption in Synapse Analytics
- Maintains the metadata and relational structure between dialogue components

## Prerequisites
- .NET Core SDK
- Azure Synapse Analytics workspace (for the analytics demo)

## Setup and Execution
1. Clone the repository to your local machine
2. Navigate to the `DataConversion` directory
3. Run the program using:
   ```
   dotnet run
   ```
4. The program will generate JSON files for each dialogue entry that can be used in Synapse Analytics

## Use in Synapse Analytics
The converted JSON files can be:
1. Uploaded to Azure Data Lake Storage
2. Queried using Synapse Serverless SQL pool
3. Analyzed using Synapse Spark notebooks
4. Visualized with Power BI integration

## Contributing
Contributions to this project are welcome. Please feel free to fork the repository, make changes, and submit a pull request.

## Data Citation

```
@article{zeng2020coviddialogmodel,
  title={Develop Medical Dialogue Systems for COVID-19},
  author={Zeng, Guangtao and Wu, Qingyang and Zhang, Yichen and Yu, Zhou and Xing, Eric and Xie, Pengtao},
  journal={https://github.com/UCSD-AI4H/COVID-Dialogue},
  year={2020}
}
```
