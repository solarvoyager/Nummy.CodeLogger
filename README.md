# Nummy Logging package for .NET Core

[![NuGet Version](https://img.shields.io/nuget/v/Nummy.CodeLogger.svg)](https://www.nuget.org/packages/Nummy.CodeLogger/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

## Overview

This is a .NET Core library for logging in your application.
Just set connection string of your database then package will create and manage required tables for itself.

## Installation

https://www.nuget.org/packages/Nummy.CodeLogger
Or install the package via NuGet Package Manager Console:

```bash
Install-Package Nummy.CodeLogger
```

## Getting Started

In your `Program.cs` file add the following line:

```csharp
using Nummy.HttpLogger.Extensions;
using Nummy.HttpLogger.Models;
```

```csharp
// .. other configurations

builder.Services.AddNummyCodeLogger(options =>
{
    // Configure options here
    // Example: 
    options.DatabaseType = NummyCodeLoggerDatabaseType.PostgreSql;
    options.DatabaseConnectionString = "Host=localhost;Port=5432;Database=nummy_db;Username=postgres;Password=postgres;IncludeErrorDetail=true;";
});

// .. other configurations
var app = builder.Build();
```
## Usage
```csharp
private readonly INummyCodeLoggerService _loggerService;

public ConstructorOfYourClass(INummyCodeLoggerService loggerService)
{
    _loggerService = loggerService;
}
```
```csharp
await _loggerService.LogInfoAsync("your-info-title", "your-info-description");
// or
await _loggerService.LogInfoAsync(new ArgumentNullException(nameof(YourClass.Property)));

await _loggerService.LogErrorAsync("your-error-title", "your-error-description");
// or
await _loggerService.LogErrorAsync(new ArgumentNullException(nameof(YourClass.Property)));

// customized versions
await _loggerService.LogAsync(NummyCodeLogLevel.Debug, new ArgumentNullException(nameof(YourClass.Property)));
await _loggerService.LogAsync(NummyCodeLogLevel.Debug, "custom-title", "custom-description");
```

## License

This library is licensed under the MIT License.