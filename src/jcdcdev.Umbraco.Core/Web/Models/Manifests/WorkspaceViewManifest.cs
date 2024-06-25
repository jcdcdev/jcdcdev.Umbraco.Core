namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class WorkspaceViewManifest : IManifest
{
    public required string Alias { get; set; }
    public required string Name { get; set; }
    public string? Js { get; set; }
    public int Weight { get; set; }
    public MetaManifest? Meta { get; set; }
    public ConditionManifest[]? Conditions { get; set; }
    public string? Element { get; set; }
    public string? ElementName { get; set; }
    public string Type => "workspaceView";

    public class MetaManifest
    {
        public string? Icon { get; set; }
        public string? Label { get; set; }
        public string? Pathname { get; set; }
    }
}
