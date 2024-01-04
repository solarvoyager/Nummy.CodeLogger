namespace Nummy.CodeLogger.Utils.Exceptions;

internal class NummyCodeLoggerOptionsValidationException()
    : Exception($"{nameof(NummyCodeLoggerOptions.DsnUrl)} must have a valid DSN url");