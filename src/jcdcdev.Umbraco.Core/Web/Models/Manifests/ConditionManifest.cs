namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

/// <summary>
/// Represents a condition manifest that can be used to define requirements for Umbraco backoffice extensions.
/// Supports a fluent builder style via <see cref="For"/> or named shorthand factory methods.
/// </summary>
/// <example>
/// Named shorthand:
/// <code>ConditionManifest.SectionAlias("Umb.Section.Content")</code>
///
/// Fluent builder:
/// <code>
/// ConditionManifest.For(Constants.Conditions.CurrentUserGroupId)
///     .WithOneOf(allowedGroups)
///     .WithNoneOf(excludedGroups)
/// </code>
///
/// Custom condition:
/// <code>ConditionManifest.For("My.Condition.CustomName").WithMatch("Yes")</code>
/// </example>
public record ConditionManifest : IConditionManifestBuilder
{
    private ConditionManifest(string alias) { Alias = alias; }

    public string Alias { get; init; }
    public object? Match { get; init; }
    public object[]? OneOf { get; init; }
    public object[]? AllOf { get; init; }
    public object[]? NoneOf { get; init; }

    // ── Builder entry point ───────────────────────────────────────────────────

    /// <summary>
    /// Creates a condition builder for the given alias.
    /// Call a <c>With*</c> method to set the value, or use directly as <see cref="IConditionManifest"/>
    /// for flag-style conditions.
    /// </summary>
    public static ConditionManifest For(string alias) => new(alias);

    // ── IConditionManifestBuilder — explicit so With* only appear on the interface ──

    IConditionManifest IConditionManifestBuilder.WithMatch(string match) => this with { Match = match };
    IConditionManifest IConditionManifestBuilder.WithMatch(bool match) => this with { Match = match };
    IConditionManifest IConditionManifestBuilder.WithMatch(int match) => this with { Match = match };
    IConditionManifest IConditionManifestBuilder.WithOneOf(params string[] oneOf) => this with { OneOf = oneOf.Cast<object>().ToArray() };
    IConditionManifest IConditionManifestBuilder.WithAllOf(params string[] allOf) => this with { AllOf = allOf.Cast<object>().ToArray() };
    IConditionManifest IConditionManifestBuilder.WithNoneOf(params string[] noneOf) => this with { NoneOf = noneOf.Cast<object>().ToArray() };

    // ── General / Environment ─────────────────────────────────────────────────

    /// <summary>Toggles on and off based on the frequency set in seconds.</summary>
    public static ConditionManifest Switch(int frequencySeconds) =>
        new ConditionManifest(Constants.Conditions.Switch) with { Match = frequencySeconds };

    /// <summary>Requires the app to have more than one language.</summary>
    public static ConditionManifest MultipleAppLanguages() => For(Constants.Conditions.MultipleAppLanguages);

    /// <summary>Requires the extension to be rendered inside a modal.</summary>
    public static ConditionManifest InModal() => For(Constants.Conditions.InModal);

    /// <summary>Requires the server to be running in production mode.</summary>
    public static ConditionManifest ServerIsProductionMode() => For(Constants.Conditions.ServerIsProductionMode);

    /// <summary>Delays availability of the extension by the given number of milliseconds.</summary>
    public static ConditionManifest Delay(int offsetMilliseconds) =>
        new ConditionManifest(Constants.Conditions.Delay) with { Match = offsetMilliseconds };

    /// <summary>Requires (or excludes) the extension being rendered within a routable context.</summary>
    public static ConditionManifest IsRoutableContext(bool match = true) =>
        new ConditionManifest(Constants.Conditions.IsRoutableContext) with { Match = match };

    // ── Section ───────────────────────────────────────────────────────────────

    /// <summary>Requires the current Section Alias to match the one specified.</summary>
    public static ConditionManifest SectionAlias(string sectionAlias) =>
        new ConditionManifest(Constants.Conditions.SectionAlias) with { Match = sectionAlias };

    /// <summary>Requires the current Section Alias to match one of the specified aliases.</summary>
    public static ConditionManifest SectionAlias(params string[] sectionAliases) =>
        new ConditionManifest(Constants.Conditions.SectionAlias) with { OneOf = sectionAliases.Cast<object>().ToArray() };

    /// <summary>Requires the current user to have permissions to the given Section Alias.</summary>
    public static ConditionManifest SectionUserPermission(string sectionAlias) =>
        new ConditionManifest(Constants.Conditions.SectionUserPermission) with { Match = sectionAlias };

    // ── Menu ──────────────────────────────────────────────────────────────────

    /// <summary>Requires the current Menu Alias to match the one specified.</summary>
    public static ConditionManifest MenuAlias(string menuAlias) =>
        new ConditionManifest(Constants.Conditions.MenuAlias) with { Match = menuAlias };

    // ── Workspace ─────────────────────────────────────────────────────────────

    /// <summary>Requires the current Workspace Alias to match the one specified.</summary>
    public static ConditionManifest WorkspaceAlias(string workspaceAlias) =>
        new ConditionManifest(Constants.Conditions.WorkspaceAlias) with { Match = workspaceAlias };

    /// <summary>Requires the current workspace to work on the given Entity Type.</summary>
    public static ConditionManifest WorkspaceEntityType(string entityType) =>
        new ConditionManifest(Constants.Conditions.WorkspaceEntityType) with { Match = entityType };

    /// <summary>Requires the current Workspace data to be new, not yet persisted on the server.</summary>
    public static ConditionManifest WorkspaceEntityIsNew() =>
        new ConditionManifest(Constants.Conditions.WorkspaceEntityIsNew) with { Match = true };

    /// <summary>Requires the current workspace to be based on a Content Type whose Alias matches the one specified.</summary>
    public static ConditionManifest WorkspaceContentTypeAlias(string contentTypeAlias) =>
        new ConditionManifest(Constants.Conditions.WorkspaceContentTypeAlias) with { Match = contentTypeAlias };

    /// <summary>Requires the current workspace to be based on a Content Type whose Alias matches one of the specified aliases.</summary>
    public static ConditionManifest WorkspaceContentTypeAlias(params string[] contentTypeAliases) =>
        new ConditionManifest(Constants.Conditions.WorkspaceContentTypeAlias) with { OneOf = contentTypeAliases.Cast<object>().ToArray() };

    /// <summary>Requires the current workspace to be based on a Content Type that uniquely matches the one specified.</summary>
    public static ConditionManifest WorkspaceContentTypeUnique(string unique) =>
        new ConditionManifest(Constants.Conditions.WorkspaceContentTypeUnique) with { Match = unique };

    /// <summary>Requires the Content Type of the current Workspace to have properties.</summary>
    public static ConditionManifest WorkspaceContentHasProperties() =>
        new ConditionManifest(Constants.Conditions.WorkspaceContentHasProperties) with { Match = true };

    /// <summary>Requires the current Workspace to have a Content Collection.</summary>
    public static ConditionManifest WorkspaceHasCollection() =>
        new ConditionManifest(Constants.Conditions.WorkspaceHasCollection) with { Match = true };

    /// <summary>Requires the document in the current Workspace to be in the recycle bin.</summary>
    public static ConditionManifest WorkspaceDocumentIsTrashed() => For(Constants.Conditions.WorkspaceDocumentIsTrashed);

    /// <summary>Requires the document in the current Workspace not to be in the recycle bin.</summary>
    public static ConditionManifest WorkspaceDocumentIsNotTrashed() => For(Constants.Conditions.WorkspaceDocumentIsNotTrashed);

    /// <summary>Requires the entity in the current Workspace to have finished loading.</summary>
    public static ConditionManifest WorkspaceContentIsLoaded() => For(Constants.Conditions.WorkspaceContentIsLoaded);

    // ── Entity ────────────────────────────────────────────────────────────────

    /// <summary>Requires the current entity to be of the given type.</summary>
    public static ConditionManifest EntityType(string type) =>
        new ConditionManifest(Constants.Conditions.EntityType) with { Match = type };

    /// <summary>Requires the current entity to be one of the given types.</summary>
    public static ConditionManifest EntityType(params string[] types) =>
        new ConditionManifest(Constants.Conditions.EntityType) with { OneOf = types.Cast<object>().ToArray() };

    /// <summary>Requires the current entity's unique identifier to match the one specified.</summary>
    public static ConditionManifest EntityUnique(string unique) =>
        new ConditionManifest(Constants.Conditions.EntityUnique) with { Match = unique };

    /// <summary>Requires the current entity to have one or more children.</summary>
    public static ConditionManifest EntityHasChildren() => For(Constants.Conditions.EntityHasChildren);

    /// <summary>Requires the current entity's Content Type unique identifier to match the one specified.</summary>
    public static ConditionManifest EntityContentTypeUnique(string unique) =>
        new ConditionManifest(Constants.Conditions.EntityContentTypeUnique) with { Match = unique };

    /// <summary>Requires the current entity to be trashed.</summary>
    public static ConditionManifest EntityIsTrashed() =>
        new ConditionManifest(Constants.Conditions.EntityIsTrashed) with { Match = true };

    /// <summary>Requires the current entity not to be trashed.</summary>
    public static ConditionManifest EntityIsNotTrashed() =>
        new ConditionManifest(Constants.Conditions.EntityIsNotTrashed) with { Match = true };

    // ── Collection ────────────────────────────────────────────────────────────

    /// <summary>Requires the current Collection Alias to match the one specified.</summary>
    public static ConditionManifest CollectionAlias(string collectionAlias) =>
        new ConditionManifest(Constants.Conditions.CollectionAlias) with { Match = collectionAlias };

    /// <summary>Requires the current Collection to contain one or more items.</summary>
    public static ConditionManifest CollectionHasItems() => For(Constants.Conditions.CollectionHasItems);

    // ── Property ──────────────────────────────────────────────────────────────

    /// <summary>Requires the current property to have a value.</summary>
    public static ConditionManifest PropertyHasValue() => For(Constants.Conditions.PropertyHasValue);

    /// <summary>Requires the current property to be writable (not read-only).</summary>
    public static ConditionManifest PropertyWritable() => For(Constants.Conditions.PropertyWritable);

    // ── Current User ──────────────────────────────────────────────────────────

    /// <summary>Requires the current user to be an admin.</summary>
    public static ConditionManifest CurrentUserIsAdmin() => For(Constants.Conditions.CurrentUserIsAdmin);

    /// <summary>Requires the current user to belong to a specific group by GUID.</summary>
    public static ConditionManifest CurrentUserGroupId(string groupId) =>
        new ConditionManifest(Constants.Conditions.CurrentUserGroupId) with { Match = groupId };

    /// <summary>
    /// Entry point for multi-group current-user conditions.
    /// Chain with <c>WithOneOf</c>, <c>WithAllOf</c>, or <c>WithNoneOf</c>.
    /// </summary>
    public static ConditionManifest CurrentUserGroupId() => For(Constants.Conditions.CurrentUserGroupId);

    /// <summary>Requires the current user to be allowed to change their password.</summary>
    public static ConditionManifest CurrentUserAllowChangePassword() => For(Constants.Conditions.CurrentUserAllowChangePassword);

    /// <summary>Requires the current user to be allowed to manage Multi-Factor Authentication.</summary>
    public static ConditionManifest CurrentUserAllowMfaAction() => For(Constants.Conditions.CurrentUserAllowMfaAction);

    /// <summary>Requires the current user to be allowed to access the Document recycle bin.</summary>
    public static ConditionManifest CurrentUserAllowDocumentRecycleBin() => For(Constants.Conditions.CurrentUserAllowDocumentRecycleBin);

    /// <summary>Requires the current user to be allowed to access the Media recycle bin.</summary>
    public static ConditionManifest CurrentUserAllowMediaRecycleBin() => For(Constants.Conditions.CurrentUserAllowMediaRecycleBin);

    // ── User Management Actions ───────────────────────────────────────────────

    public static ConditionManifest UserAllowChangePassword() => For(Constants.Conditions.UserAllowChangePassword);
    public static ConditionManifest UserAllowDeleteAction() => For(Constants.Conditions.UserAllowDeleteAction);
    public static ConditionManifest UserAllowDisableAction() => For(Constants.Conditions.UserAllowDisableAction);
    public static ConditionManifest UserAllowEnableAction() => For(Constants.Conditions.UserAllowEnableAction);
    public static ConditionManifest UserAllowUnlockAction() => For(Constants.Conditions.UserAllowUnlockAction);
    public static ConditionManifest UserAllowExternalLoginAction() => For(Constants.Conditions.UserAllowExternalLoginAction);
    public static ConditionManifest UserAllowMfaAction() => For(Constants.Conditions.UserAllowMfaAction);
    public static ConditionManifest UserIsDefaultKind() => For(Constants.Conditions.UserIsDefaultKind);
    public static ConditionManifest UserAllowResendInviteAction() => For(Constants.Conditions.UserAllowResendInviteAction);

    // ── User Permissions ──────────────────────────────────────────────────────

    /// <summary>Requires the current user to have specific Document permissions (e.g. "Umb.Document.Save").</summary>
    public static ConditionManifest UserPermissionDocument(string permission) =>
        new ConditionManifest(Constants.Conditions.UserPermissionDocument) with { Match = permission };

    /// <summary>Requires the current user to have the required permission for the Document's property values.</summary>
    public static ConditionManifest UserPermissionDocumentPropertyValue() => For(Constants.Conditions.UserPermissionDocumentPropertyValue);

    /// <summary>Requires the current user to have the required permission for the given Language.</summary>
    public static ConditionManifest UserPermissionLanguage(string language) =>
        new ConditionManifest(Constants.Conditions.UserPermissionLanguage) with { Match = language };

    /// <summary>
    /// Fallback permission condition. Chain with <c>WithAllOf</c> or <c>WithOneOf</c>.
    /// </summary>
    public static ConditionManifest UserPermissionFallback() => For(Constants.Conditions.UserPermissionFallback);

    // ── Templating & Data Types ───────────────────────────────────────────────

    public static ConditionManifest TemplateAllowDeleteAction() => For(Constants.Conditions.TemplateAllowDeleteAction);
    public static ConditionManifest DataTypeAllowDeleteAction() => For(Constants.Conditions.DataTypeAllowDeleteAction);

    // ── Property Editors ──────────────────────────────────────────────────────

    public static ConditionManifest EntityDataPickerSupportsTextFilter() => For(Constants.Conditions.EntityDataPickerSupportsTextFilter);

    // ── Block ─────────────────────────────────────────────────────────────────

    public static ConditionManifest BlockHasSettings() => For(Constants.Conditions.BlockHasSettings);
    public static ConditionManifest BlockEntryShowContentEdit() => For(Constants.Conditions.BlockEntryShowContentEdit);
    public static ConditionManifest BlockWorkspaceIsExposed() => For(Constants.Conditions.BlockWorkspaceIsExposed);
    public static ConditionManifest BlockWorkspaceIsReadOnly() => For(Constants.Conditions.BlockWorkspaceIsReadOnly);
}
