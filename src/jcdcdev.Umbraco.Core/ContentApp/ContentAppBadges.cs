using Umbraco.Cms.Core.Models.ContentEditing;

namespace jcdcdev.Umbraco.Core.ContentApp;

public static class ContentAppBadges
{
    public static ContentAppBadge Default(int count)
    {
        return new ContentAppBadge { Count = count, Type = ContentAppBadgeType.Default };
    }

    public static ContentAppBadge Warning(int count)
    {
        return new ContentAppBadge { Count = count, Type = ContentAppBadgeType.Warning };
    }

    public static ContentAppBadge Alert(int count)
    {
        return new ContentAppBadge { Count = count, Type = ContentAppBadgeType.Alert };
    }

    public static ContentAppBadge? None => null;
}
