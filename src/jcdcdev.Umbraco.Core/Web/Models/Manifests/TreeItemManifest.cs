namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class TreeItemManifest : IManifest
{
    public string Type => "treeItem";
    public required string Alias { get; set; }
    public required string Name { get; set; }
    public required string[] ForEntityTypes { get; set; }
    public string Kind { get; set; } = "default";
    public string? ElementName { get; set; } = null;
    public string? Js { get; set; }
}