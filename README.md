# Nummy Logging package for .NET Core

[![NuGet Version](https://img.shields.io/nuget/v/Nummy.CodeLogger.svg)](https://www.nuget.org/packages/Nummy.CodeLogger/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Nummy.CodeLogger.svg)](https://www.nuget.org/packages/Nummy.CodeLogger/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

## Overview

This is a .NET Core library for logging in your application.
Just set connection string of your database then package will create and manage required tables for itself.

## Installation

[Nuget - Nummy.CodeLogger](https://www.nuget.org/packages/Nummy.CodeLogger)

or install the package via NuGet Package Manager Console:

```bash
Install-Package Nummy.CodeLogger
```

## Getting Started

#### 1. Run Nummy on your Docker

// under construction

#### 2. Get DSN url from your Docker Nummy instance

// under construction

#### 3. Configure your application

In your `Program.cs` file add the following line:

In your `Program.cs` file add the following line:

```csharp
using Nummy.HttpLogger.Extensions;
using Nummy.HttpLogger.Models;
```

```csharp
// .. other configurations

builder.Services.AddNummyCodeLogger(options => 
    options.DsnUrl = "your-nummy-dsn-url");

// .. other configurations
var app = builder.Build();
```

#### 4. Now, your application is set up to log using the Nummy Code Logger.

## Usage

Inject `INummyCodeLoggerService` as a normal service:

```csharp
private readonly INummyCodeLoggerService _loggerService;

public ConstructorOfYourClass(INummyCodeLoggerService loggerService)
{
    _loggerService = loggerService;
}
```

And use it like:

```csharp
// log infos
await _loggerService.LogInfoAsync("your-info-title", "your-info-description");
// or
await _loggerService.LogInfoAsync(new ArgumentNullException(nameof(YourClass.Property)));

// log errors
await _loggerService.LogErrorAsync("your-error-title", "your-error-description");
// or
await _loggerService.LogErrorAsync(new ArgumentNullException(nameof(YourClass.Property)));

// log customized
await _loggerService.LogAsync(NummyCodeLogLevel.Debug, new ArgumentNullException(nameof(YourClass.Property)));
await _loggerService.LogAsync(NummyCodeLogLevel.Debug, "custom-title", "custom-description");

// and log much more ..
```

## License

This library is licensed under the MIT License.