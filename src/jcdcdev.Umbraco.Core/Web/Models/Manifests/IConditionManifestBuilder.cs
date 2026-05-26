namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public interface IConditionManifestBuilder : IConditionManifest
{
    IConditionManifest WithMatch(string match);
    IConditionManifest WithMatch(bool match);
    IConditionManifest WithMatch(int match);
    IConditionManifest WithOneOf(params string[] oneOf);
    IConditionManifest WithAllOf(params string[] allOf);
    IConditionManifest WithNoneOf(params string[] noneOf);
}
