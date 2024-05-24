using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.Core.Composing;

internal static class UmbracoBuilderExtensions
{
    internal static IUmbracoBuilder AddSimplePackageManifests(this IUmbracoBuilder builder)
    {
        var types = builder.TypeLoader.TypeFinder.FindClassesOfType<SimplePackageManifest>();
        foreach (var type in types)
        {
            builder.ManifestFilters().Append(type);
        }

        return builder;
    }
}
