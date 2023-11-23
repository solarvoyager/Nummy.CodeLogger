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

No need to Use Middleware.

Now, your application is set up to log using the Nummy Code Logger.

## License

This library is licensed under the MIT License.