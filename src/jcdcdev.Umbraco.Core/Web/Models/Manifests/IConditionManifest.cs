namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public interface IConditionManifest
{
    string Alias { get; }
    object? Match { get; }
    object[]? OneOf { get; }
    object[]? AllOf { get; }
    object[]? NoneOf { get; }
}
