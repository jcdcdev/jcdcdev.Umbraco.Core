namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class MenuItemTreeKindManifest : IManifest
{
    public string Type => "menuItem";
    public string Kind { get; set; } = "tree";
    public required string Alias { get; set; }
    public required string Name { get; set; }
    public int Weight { get; set; } = 400;
    public MenuItemTreeKindManifestMeta Meta { get; set; } = new();

    public class MenuItemTreeKindManifestMeta
    {
        public string? Label { get; set; }
        public string? TreeAlias { get; set; }
        public string[] Menus { get; set; } = [];
        public string? Icon { get; set; }
    }
}
