namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class WorkspaceManifest : IManifest
{
    public required string Kind { get; set; }
    public string Type => "workspace";
    public required string Alias { get; set; }
    public required string Name { get; set; }
    public required string Js { get; set; }
    public required WorkspaceManifestMeta Meta { get; set; }

    public class WorkspaceManifestMeta
    {
        public required string EntityType { get; set; }
    }
}
