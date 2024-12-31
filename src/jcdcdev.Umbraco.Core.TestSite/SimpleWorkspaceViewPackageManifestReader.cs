using jcdcdev.Umbraco.Core.Extensions;
using jcdcdev.Umbraco.Core.Web.Models.Manifests;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Infrastructure.Manifest;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace jcdcdev.Umbraco.Core.TestSite;

public class SimpleWorkspaceViewPackageManifestReader : IPackageManifestReader
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
                ConditionManifest.WorkspaceAlias(Constants.Workspaces.Document)
            ]
        };

        var newEntityWorkspaceViewManifest = new WorkspaceViewManifest
        {
            Alias = "trashed-entity-workspace-view",
            Name = "Trashed Entity Workspace View",
            ElementName = "uui-icon",
            Weight = 10,
            Meta = new WorkspaceViewManifest.MetaManifest
            {
                Label = "Trashed Entity Workspace View",
                Pathname = "trashed-entity-workspace-view",
                Icon = "favorite"
            },
            Conditions =
            [
                ConditionManifest.EntityIsTrashed(),
                ConditionManifest.WorkspaceContentTypeAlias([Home.ModelTypeAlias, BasePage.ModelTypeAlias])
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
                ConditionManifest.SectionAlias(Constants.Sections.Content)
            ]
        };

        extensions.Add(dashboardManifest);
        extensions.Add(workspaceViewManifest);
        extensions.Add(newEntityWorkspaceViewManifest);
        packageManifest.Extensions = extensions.OfType<object>().ToArray();
        return [packageManifest];
    }
}
