﻿using Nummy.HttpLogger.Models;

namespace Nummy.HttpLogger.Utils;

internal static class NummyModelValidator
{
    public static void ValidateNummyCodeLoggerOptions(NummyCodeLoggerOptions options)
    {
        if (string.IsNullOrEmpty(options.DatabaseConnectionString?.Trim()))
            throw new NummyHttpLoggerOptionsValidationException();
    }
}