using Examine;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class IndexItemEventArgsExtensions
{
    private static Dictionary<string, IEnumerable<object>> ToDictionary(this Dictionary<string, List<object?>> source)
    {
        return source.ToDictionary(x => x.Key, x => (IEnumerable<object>)x.Value);
    }

    public static void AddOrUpdateValue(this IndexingItemEventArgs e, string key, object value)
    {
        var updatedValues = e.ValuesAsDictionary();
        var values = new List<object?> { value };
        updatedValues[key] = values;
        e.SetValues(updatedValues.ToDictionary());
    }

    public static Dictionary<string, List<object?>> ValuesAsDictionary(this IndexingItemEventArgs e)
        => e.ValueSet.Values.ToDictionary(x => x.Key, x => x.Value.ToList());

    public static void AddOrUpdateValues(this IndexingItemEventArgs args, Dictionary<string, List<object>> output)
    {
        var og = args.ValuesAsDictionary();
        foreach (var value in output)
        {
            og[value.Key] = value.Value!;
        }

        args.SetValues(og.ToDictionary());
    }
}
