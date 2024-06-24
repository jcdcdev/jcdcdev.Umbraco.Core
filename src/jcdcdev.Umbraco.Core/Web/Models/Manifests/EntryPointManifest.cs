namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class EntryPointManifest : IManifest
{
    public string Name { get; set; }
    public string Alias { get; set; }
    public string Js { get; set; }
    public string Type => "entryPoint";
}