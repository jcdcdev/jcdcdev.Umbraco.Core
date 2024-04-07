using System.Reflection;
using Umbraco.Cms.Core.Semver;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class EnvironmentExtensions
{
    public static Version? CurrentAssemblyVersion() => Assembly.GetEntryAssembly()?.GetName().Version;

    public static SemVersion? ToSemVer(this Version? version) =>
        version == null ? null :
        SemVersion.TryParse($"{version.Major}.{version.Minor}.{version.Build}", out var semver) ? semver : null;
}
