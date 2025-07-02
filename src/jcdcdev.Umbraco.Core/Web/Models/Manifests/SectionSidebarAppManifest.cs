namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class SectionSidebarAppManifest : IManifest
{
    public string Type => "sectionSidebarApp";
    public required string Kind { get; set; }
    public required string Alias { get; set; }
    public required string Name { get; set; }
    public required SectionSidebarAppManifestMeta Meta { get; set; }
    public required IConditionManifest[] Conditions { get; set; }

    public class SectionSidebarAppManifestMeta
    {
        public required string Label { get; set; }
        public required string Menu { get; set; }
        public required string[] Sections { get; set; } 
    }
}