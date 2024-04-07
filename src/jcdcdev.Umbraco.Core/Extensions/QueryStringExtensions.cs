using Microsoft.AspNetCore.Http;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class QueryStringExtensions
{
    public static int GetIntFromQueryString(this IQueryCollection query, string key, int fallback = 0) => TryGetIntValue(query, key, out var value) ? value : fallback;

    public static bool TryGetIntValue(this IQueryCollection query, string key, out int output)
    {
        output = 0;
        if (!query.TryGetValue(key, out var value))
        {
            return false;
        }

        if (int.TryParse(value.ToString(), out output))
        {
            return true;
        }

        return false;
    }

    public static bool TryGetStringValue(this IQueryCollection query, string key, out string output)
    {
        output = string.Empty;
        if (query.TryGetValue(key, out var value))
        {
            output = value.ToString();
        }

        return !output.IsNullOrWhiteSpace();
    }
}
