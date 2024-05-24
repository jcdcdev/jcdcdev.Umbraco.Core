using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.Core.Composing;

internal static class UmbracoBuilderExtensions
{
    #if UMBRACO_13_OR_LESS
    internal static IUmbracoBuilder AddSimplePackageManifests(this IUmbracoBuilder builder)
    {
        var types = builder.TypeLoader.TypeFinder.FindClassesOfType<SimplePackageManifest>();
        foreach (var type in types)
        {
            builder.ManifestFilters().Append(type);
        }

        return builder;
    }
    #endif
}
