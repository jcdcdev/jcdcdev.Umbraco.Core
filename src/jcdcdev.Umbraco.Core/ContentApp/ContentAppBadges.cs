#if UMBRACO_13_OR_LESS
using Umbraco.Cms.Core.Models.ContentEditing;

namespace jcdcdev.Umbraco.Core.ContentApp;

public static class ContentAppBadges
{
    public static ContentAppBadge? None => null;

    public static ContentAppBadge Default(int count) => new() { Count = count, Type = ContentAppBadgeType.Default };

    public static ContentAppBadge Warning(int count) => new() { Count = count, Type = ContentAppBadgeType.Warning };

    public static ContentAppBadge Alert(int count) => new() { Count = count, Type = ContentAppBadgeType.Alert };
}
#endif
