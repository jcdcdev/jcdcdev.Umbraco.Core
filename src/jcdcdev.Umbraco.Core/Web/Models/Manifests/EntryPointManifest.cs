namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class EntryPointManifest : IManifest
{
    public required string Name { get; set; }
    public required string Alias { get; set; }
    public required string Js { get; set; }
    public string Type => "backofficeEntryPoint";
}
