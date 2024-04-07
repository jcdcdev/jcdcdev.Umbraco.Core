using Umbraco.Cms.Core.Models.ContentEditing;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class ContentItemDisplayExtensions
{
    public static IEnumerable<ContentPropertyDisplay> GetProperties(this ContentItemDisplay contentItemDisplay, string propertyEditorAlias)
    {
        return contentItemDisplay.Variants.SelectMany(x => x.Tabs.GetProperties(propertyEditorAlias));
    }

    public static IEnumerable<ContentPropertyDisplay> GetProperties(this IEnumerable<Tab<ContentPropertyDisplay>> contentItemDisplay, string propertyEditorAlias)
    {
        return contentItemDisplay.SelectMany(y => y.Properties?.Where(x => x.Editor == propertyEditorAlias) ?? Array.Empty<ContentPropertyDisplay>());
    }
}
