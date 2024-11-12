using jcdcdev.Umbraco.Core.Extensions;
using jcdcdev.Umbraco.Core.Web.Models.Manifests;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

namespace TestSite;

public class SimpleWorkspaceViewPackageManifestReader() : IPackageManifestReader
{
    public async Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync()
    {
        var extensions = new List<IManifest>();
        var packageManifest = new PackageManifest
        {
            Name = "jcdcdev.Umbraco.Core",
            Version = EnvironmentExtensions.CurrentAssemblyVersion().ToSemVer()?.ToString() ?? "0.1.0",
            AllowPublicAccess = false,
            AllowTelemetry = false,
            Extensions = []
        };

        var workspaceViewManifest = new WorkspaceViewManifest
        {
            Alias = "demo-wprkspace-view",
            Name = "Demo Workspace View",
            ElementName = "uui-icon",
            Weight = 10,
            Meta = new WorkspaceViewManifest.MetaManifest
            {
                Label = "Demo Workspace View",
                Pathname = "demo-workspace-view",
                Icon = "favorite"
            },
            Conditions =
            [
                new ConditionManifest
                {
                    Alias = "Umb.Condition.WorkspaceAlias",
                    Match = "Umb.Workspace.Document"
                }
            ]
        };

        var dashboardManifest = new DashboardManifest
        {
            Alias = "demo-dashboard",
            Name = "Demo Dashboard",
            ElementName = "uui-icon",
            Weight = 10,
            Meta = new DashboardManifest.MetaManifest
            {
                Label = "Demo Dashboard",
                Pathname = "demo-dashboard"
            },
            Conditions =
            [
                new ConditionManifest
                {
                    Alias = "Umb.Condition.SectionAlias",
                    Match = "Umb.Section.Content"
                }
            ]
        };

        extensions.Add(dashboardManifest);
        extensions.Add(workspaceViewManifest);
        packageManifest.Extensions = extensions.OfType<object>().ToArray();
        return [packageManifest];
    }
}
