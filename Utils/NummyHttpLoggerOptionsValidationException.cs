using Nummy.CodeLogger.Models;

namespace Nummy.CodeLogger.Utils;

internal class NummyCodeLoggerOptionsValidationException : Exception
{
    public NummyCodeLoggerOptionsValidationException()
        : base($"{nameof(NummyCodeLoggerOptions.DatabaseConnectionString)} must have a valid connection string")
    {
    }
}