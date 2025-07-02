namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class MenuManifest : IManifest
{
    public string Type => "menu";
    public required string Alias { get; set; }
    public required string Name { get; set; }
}