using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class LogEventExtensions
{
    public static bool TryAddHeaderIfExists(this LogEvent logEvent, ILogEventPropertyFactory propertyFactory, string header, IHeaderDictionary headers)
    {
        if (headers.TryGetValue(header, out var value))
        {
            return TryAddOrUpdateProperty(logEvent, propertyFactory, header, value.ToString());
        }

        return false;
    }

    public static bool TryAddOrUpdateProperty(this LogEvent logEvent, ILogEventPropertyFactory propertyFactory, string name, object? value)
    {
        try
        {
            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty(name, value));
            return true;
        }
        catch (Exception)
        {
            // ignored
        }

        return false;
    }
}
