using Umbraco.Cms.Core.Models;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class MediaTypeExtensions
{
    private static readonly string[] MediaTypes =
    [
        global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.File,
        global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.Folder,
        global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.Image,
        global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.Video,
        global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.Audio,
        global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.Article,
        global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.VectorGraphics,
        global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.VideoAlias,
        global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.AudioAlias,
        global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.ArticleAlias,
        global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.VectorGraphicsAlias
    ];

    public static bool IsInternal(this IMediaType mediaType) => MediaTypes.InvariantContains(mediaType.Alias);
}
