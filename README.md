# Sample .NET Web API with Pre-commit Hooks

A sample .NET 8.0 Web API project with comprehensive pre-commit hooks
for code quality, formatting, and security checks.

## Project Structure

```text
├── Controllers/
│   ├── WeatherForecastController.cs
│   └── ProductsController.cs
├── Models/
│   ├── WeatherForecast.cs
│   └── Product.cs
├── Properties/
│   └── launchSettings.json
├── SampleWebApi.csproj
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── .editorconfig
├── .pre-commit-config.yaml
└── .gitignore
```

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Python 3.7+](https://www.python.org/downloads/) (for pre-commit)
- [Git](https://git-scm.com/downloads)

## Getting Started

### 1. Restore Dependencies

```bash
dotnet restore
```

### 2. Build the Project

```bash
dotnet build
```

### 3. Run the Application

```bash
dotnet run
```

The API will be available at:

- HTTP: <http://localhost:5000>
- HTTPS: <https://localhost:5001>
- Swagger UI: <https://localhost:5001/swagger>

## API Endpoints

### Weather Forecast

- `GET /api/weatherforecast` - Get all weather forecasts
- `GET /api/weatherforecast/{id}` - Get weather forecast by ID
- `POST /api/weatherforecast` - Create a new weather forecast

### Products

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create a new product
- `PUT /api/products/{id}` - Update a product
- `DELETE /api/products/{id}` - Delete a product

## Pre-commit Hooks Setup

### Install Pre-commit

```bash
pip install pre-commit
```

### Install Git Hooks

```bash
pre-commit install
```

> In case of windows being retarded with the python environment
> you can always use this command onward:

```bash
python -m pre_commit install
```

### Run Manually

Run all hooks on all files:

```bash
pre-commit run --all-files
```

Run specific hook:

```bash
pre-commit run dotnet-format --all-files
```

## Pre-commit Checks Included

### General File Checks

- ✅ Trailing whitespace removal
- ✅ End of file fixing
- ✅ YAML syntax validation
- ✅ JSON syntax validation
- ✅ Large file detection (max 1MB)
- ✅ Case conflict detection
- ✅ Merge conflict detection
- ✅ Private key detection
- ✅ Line ending normalization

### .NET Specific Checks

- ✅ **dotnet format** - Code formatting verification
- ✅ **dotnet build** - Compilation check
- ✅ **dotnet test** - Run all tests
- ✅ **Code analysis** - .NET analyzers with warnings as errors
- ✅ **Outdated packages check** - Detect outdated NuGet packages
- ✅ **TODO/FIXME detection** - Warn about pending tasks
- ✅ **Debug statements check** - Prevent debug code commits

### Security Checks

- ✅ **Detect secrets** - Find credentials and secrets in code

### Documentation Checks

- ✅ **Markdown linting** - Ensure consistent markdown formatting

## Code Quality Configuration

### EditorConfig

The project includes a comprehensive `.editorconfig` file that enforces:

- Consistent code style
- Naming conventions
- Formatting rules
- C# best practices

### Project Settings

The `.csproj` file is configured with:

- `TreatWarningsAsErrors` - All warnings treated as errors
- `EnableNETAnalyzers` - Enable .NET code analyzers
- `AnalysisLevel` - Latest analysis level
- `EnforceCodeStyleInBuild` - Enforce code style during build

## Optional Tools

### dotnet-outdated

To enable outdated package checking, install the tool:

```bash
dotnet tool install --global dotnet-outdated-tool
```

### detect-secrets baseline

If you want to use detect-secrets, initialize a baseline:

```bash
detect-secrets scan > .secrets.baseline
```

## Development Workflow

1. Make your code changes
2. Stage your changes: `git add .`
3. Commit: `git commit -m "Your message"`
4. Pre-commit hooks will run automatically
5. If any check fails, fix the issues and commit again

## Manual Code Formatting

```bash
# Check formatting
dotnet format --verify-no-changes

# Apply formatting
dotnet format
```

## Testing

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Building for Production

```bash
# Release build
dotnet build --configuration Release

# Publish
dotnet publish --configuration Release --output ./publish
```
