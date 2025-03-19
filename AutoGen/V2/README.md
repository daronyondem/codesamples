## Environment Setup

### Conda Environment

1. Create a conda environment using the provided environment.yml file:
   ```bash
   conda env create -f environment.yml
   ```

2. Activate the conda environment:
   ```bash
   conda activate autogenv2
   ```

### API Configuration

1. Copy `.env.example` to `.env`:
   ```bash
   cp .env.example .env
   ```

2. Get your Spider API key from [Spider website](https://spider.cloud/)

3. Update the `.env` file with your actual API key