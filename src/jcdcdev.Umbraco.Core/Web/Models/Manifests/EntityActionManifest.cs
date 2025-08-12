using System.Text.Json.Serialization;

namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class EntityActionManifest : IManifest
{
    public required string Alias { get; set; }
    public required string Name { get; set; }
    public string Kind { get; set; } = "default";
    public virtual string Type => "entityAction";
    public int Weight { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ElementName { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Element { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Api { get; set; }

    public required string[] ForEntityTypes { get; set; }
    public required EntityActionManifestMeta Meta { get; set; }

    public class EntityActionManifestMeta
    {
        public required string Icon { get; set; }
        public required string Label { get; set; }
    }
}
