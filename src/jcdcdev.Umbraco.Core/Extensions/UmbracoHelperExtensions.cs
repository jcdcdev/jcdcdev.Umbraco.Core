using Umbraco.Cms.Web.Common;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class UmbracoHelperExtensions
{
    public static UmbracoHelper GetRequiredUmbracoHelper(this IUmbracoHelperAccessor umbracoHelperAccessor)
    {
        umbracoHelperAccessor.TryGetUmbracoHelper(out var helper);
        return helper ?? throw new Exception("Failed to get Umbraco Helper");
    }
}
