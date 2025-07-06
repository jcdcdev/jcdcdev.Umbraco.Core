namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class TreeManifest : IManifest
{
    public string Type => "tree";
    public string? Kind { get; set; }
    public required string Alias { get; set; }
    public required string Name { get; set; }
    public required TreeManifestMeta Meta { get; set; }
    
    public class TreeManifestMeta
    {
        public required string RepositoryAlias { get; set; }
        public string? RootEntityType { get; set; }
        public string? EntityType { get; set; }
    }
}