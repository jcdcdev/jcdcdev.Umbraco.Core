using jcdcdev.Umbraco.Core.Composing;

namespace TestSite.Ten;

public class PackageManifest : SimplePackageManifest
{
    protected override string PackageName => "Website";
    protected override bool AllowPackageTelemetry => true;
}
