using jcdcdev.Umbraco.Core.Extensions;
using Umbraco.Cms.Core.Manifest;

namespace jcdcdev.Umbraco.Core.Composing;

public abstract class SimplePackageManifest : IManifestFilter
{
    protected abstract string PackageName { get; }
    protected abstract bool AllowPackageTelemetry { get; }

    public void Filter(List<PackageManifest> manifests)
    {
        manifests.Add(new PackageManifest
        {
            PackageName = PackageName,
            Version = EnvironmentExtensions.CurrentAssemblyVersion()
                          .ToSemVer()
                          ?.ToString() ??
                      "0.0.0",
            AllowPackageTelemetry = AllowPackageTelemetry
        });
    }
}
