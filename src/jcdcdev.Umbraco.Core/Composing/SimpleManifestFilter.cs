using jcdcdev.Umbraco.Core.Extensions;
using Umbraco.Cms.Core.Manifest;

namespace jcdcdev.Umbraco.Core.Composing;

public class SimpleManifestFilter : IManifestFilter
{
    private readonly string _packageName;
    private readonly bool _allowPackageTelemetry;

    public SimpleManifestFilter(string packageName, bool allowPackageTelemetry = true)
    {
        _packageName = packageName;
        _allowPackageTelemetry = allowPackageTelemetry;
    }

    public void Filter(List<PackageManifest> manifests)
    {
        manifests.Add(new PackageManifest
        {
            PackageName = _packageName,
            Version = EnvironmentExtensions.CurrentAssemblyVersion().ToSemVer()?.ToString() ?? "0.0.0",
            AllowPackageTelemetry = _allowPackageTelemetry
        });
    }
}
