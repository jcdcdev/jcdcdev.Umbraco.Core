using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Manifest;

namespace jcdcdev.Umbraco.Core.Composing;

public static class UmbracoBuilderExtensions
{
    public static IUmbracoBuilder AddSimpleManifestFilter(this IUmbracoBuilder builder, string packageName, bool allowPackageTelemetry = true)
    {
        builder.Services.AddSingleton<SimpleManifestFilter>(x => new SimpleManifestFilter(packageName, allowPackageTelemetry));
        builder.ManifestFilters().Append<SimpleManifestFilter>();
        return builder;
    }
}
