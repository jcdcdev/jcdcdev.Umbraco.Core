using jcdcdev.Umbraco.Core.AccessRule;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.HealthChecks;
using Umbraco.Cms.Core.HealthChecks.Checks;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.Core.HealthChecks;

/// <summary>
///     Ensure a lang file exists with the area "healthcheck" and keys:<br />
///     aliasCheckSuccessMessage<br />
///     aliasCheckErrorMessage<br />
///     aliasCheckErrorMessageWithRecommendedValue<br />
///     alias = The name of <see cref="T" /> e.g MyOptions = myOptionsCheckSuccessMessage<br />
///     %0% = Current value<br />
///     %1% = Item path<br />
///     %2% = Recommended value (CheckErrorMessageWithRecommendedValue only)<br />
/// </summary>
public abstract class ConfigurationNotNullHealthcheck<T> : AbstractSettingsCheck where T : class
{
    private readonly string _prefix = typeof(T).Name.ToFirstLowerInvariant();
    private readonly IOptions<T> _options;

    /// <summary>
    ///     Ensure a lang file exists with the area "healthcheck" and keys:<br />
    ///     aliasCheckSuccessMessage<br />
    ///     aliasCheckErrorMessage<br />
    ///     aliasCheckErrorMessageWithRecommendedValue<br />
    ///     alias = The name of <see cref="T" /> e.g MyOptions = myOptionsCheckSuccessMessage<br />
    ///     %0% = Current value<br />
    ///     %1% = Item path<br />
    ///     %2% = Recommended value (CheckErrorMessageWithRecommendedValue only)<br />
    /// </summary>
    protected ConfigurationNotNullHealthcheck(ILocalizedTextService textService, IOptions<T> options) : base(textService)
    {
        var x = SimpleAccessRule.GrantBySection("mySection");
        _options = options;
    }

    protected T Options => _options.Value;
    public override ValueComparisonType ValueComparisonType => ValueComparisonType.ShouldNotEqual;
    public override string CheckSuccessMessage => LocalizedTextService.Localize("healthcheck", $"{_prefix}CheckSuccessMessage", new[] { CurrentValueDisplay, ItemPaths });

    public override string CheckErrorMessage =>
        Recommended.IsNullOrWhiteSpace()
            ? LocalizedTextService.Localize("healthcheck", $"{_prefix}CheckErrorMessage", new[] { CurrentValueDisplay, ItemPaths })
            : LocalizedTextService.Localize("healthcheck", $"{_prefix}CheckErrorMessageWithRecommendedValue", new[] { CurrentValueDisplay, ItemPaths, Recommended });

    private string CurrentValueDisplay => CurrentValue.IsNullOrWhiteSpace() ? "<em>undefined</em>" : $"<code>{CurrentValue}</code>";
    private string ItemPaths => $"<code>{ItemPath}</code> | <code>{ItemPath.Replace(":", "__")}</code>";

    public override IEnumerable<AcceptableConfiguration> Values => new List<AcceptableConfiguration>
    {
        new()
        {
            Value = null,
            IsRecommended = false
        },
        new()
        {
            Value = "",
            IsRecommended = false
        }
    };

    protected virtual string? Recommended => null;
}
