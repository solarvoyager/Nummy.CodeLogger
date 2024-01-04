using Nummy.CodeLogger.Utils.Exceptions;

namespace Nummy.CodeLogger.Utils;

internal static class NummyValidators
{
    public static void ValidateNummyCodeLoggerOptions(NummyCodeLoggerOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.DsnUrl))
            throw new NummyCodeLoggerOptionsValidationException();
    }
}