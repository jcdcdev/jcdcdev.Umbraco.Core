namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class DashboardManifest : IManifest
{
    public string Type => "dashboard";
    public string Alias { get; set; }
    public string Name { get; set; }
    public string ElementName { get; set; }
    public string Element { get; set; }
    public int Weight { get; set; }
    public MetaManifest Meta { get; set; }
    public ConditionManifest[] Conditions { get; set; }

    public class MetaManifest
    {
        public string Label { get; set; }
        public string Pathname { get; set; }
    }
}
