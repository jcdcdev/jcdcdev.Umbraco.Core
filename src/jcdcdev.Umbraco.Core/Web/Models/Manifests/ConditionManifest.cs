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
    private ConditionManifest(string alias)
    {
        Alias = alias;
    }

    public string Alias { get; init; }
    public object? Match { get; init; }
    public object[]? OneOf { get; init; }
    public object[]? AllOf { get; init; }
    public object[]? NoneOf { get; init; }

    // ── Builder entry point ───────────────────────────────────────────────────

    /// <summary>
    /// Creates a condition builder for the given alias.
    /// Call a single <c>With*</c> method to set the match value and produce the final
    /// <see cref="IConditionManifest"/>. For flag-style conditions with no match value,
    /// the returned <see cref="IConditionManifestBuilder"/> can be used directly as
    /// <see cref="IConditionManifest"/> without calling a <c>With*</c> method.
    /// </summary>
    public static IConditionManifestBuilder For(string alias) => new ConditionManifest(alias);

    // ── IConditionManifestBuilder implementation ──────────────────────────────

    IConditionManifest IConditionManifestBuilder.WithMatch(string match) => this with { Match = match };
    IConditionManifest IConditionManifestBuilder.WithMatch(bool match) => this with { Match = match };
    IConditionManifest IConditionManifestBuilder.WithMatch(int match) => this with { Match = match };
    IConditionManifest IConditionManifestBuilder.WithOneOf(params string[] oneOf) => this with { OneOf = oneOf.Cast<object>().ToArray() };
    IConditionManifest IConditionManifestBuilder.WithAllOf(params string[] allOf) => this with { AllOf = allOf.Cast<object>().ToArray() };
    IConditionManifest IConditionManifestBuilder.WithNoneOf(params string[] noneOf) => this with { NoneOf = noneOf.Cast<object>().ToArray() };

    // ── General / Environment ─────────────────────────────────────────────────

    /// <summary>Toggles on and off based on the frequency set in seconds.</summary>
    public static IConditionManifest Switch(int frequencySeconds) =>
        For(Constants.Conditions.Switch).WithMatch(frequencySeconds);

    /// <summary>Requires the app to have more than one language.</summary>
    public static IConditionManifest MultipleAppLanguages() =>
        For(Constants.Conditions.MultipleAppLanguages);

    /// <summary>Requires the extension to be rendered inside a modal.</summary>
    public static IConditionManifest InModal() =>
        For(Constants.Conditions.InModal);

    /// <summary>Requires the server to be running in production mode.</summary>
    public static IConditionManifest ServerIsProductionMode() =>
        For(Constants.Conditions.ServerIsProductionMode);

    /// <summary>Delays availability of the extension by the given number of milliseconds.</summary>
    public static IConditionManifest Delay(int offsetMilliseconds) =>
        For(Constants.Conditions.Delay).WithMatch(offsetMilliseconds);

    /// <summary>Requires (or excludes) the extension being rendered within a routable context.</summary>
    public static IConditionManifest IsRoutableContext(bool match = true) =>
        For(Constants.Conditions.IsRoutableContext).WithMatch(match);

    // ── Section ───────────────────────────────────────────────────────────────

    /// <summary>Requires the current Section Alias to match the one specified.</summary>
    public static IConditionManifest SectionAlias(string sectionAlias) =>
        For(Constants.Conditions.SectionAlias).WithMatch(sectionAlias);

    /// <summary>Requires the current Section Alias to match one of the specified aliases.</summary>
    public static IConditionManifest SectionAlias(params string[] sectionAliases) =>
        For(Constants.Conditions.SectionAlias).WithOneOf(sectionAliases);

    /// <summary>Requires the current user to have permissions to the given Section Alias.</summary>
    public static IConditionManifest SectionUserPermission(string sectionAlias) =>
        For(Constants.Conditions.SectionUserPermission).WithMatch(sectionAlias);

    // ── Menu ──────────────────────────────────────────────────────────────────

    /// <summary>Requires the current Menu Alias to match the one specified.</summary>
    public static IConditionManifest MenuAlias(string menuAlias) =>
        For(Constants.Conditions.MenuAlias).WithMatch(menuAlias);

    // ── Workspace ─────────────────────────────────────────────────────────────

    /// <summary>Requires the current Workspace Alias to match the one specified.</summary>
    public static IConditionManifest WorkspaceAlias(string workspaceAlias) =>
        For(Constants.Conditions.WorkspaceAlias).WithMatch(workspaceAlias);

    /// <summary>Requires the current workspace to work on the given Entity Type.</summary>
    public static IConditionManifest WorkspaceEntityType(string entityType) =>
        For(Constants.Conditions.WorkspaceEntityType).WithMatch(entityType);

    /// <summary>Requires the current Workspace data to be new, not yet persisted on the server.</summary>
    public static IConditionManifest WorkspaceEntityIsNew() =>
        For(Constants.Conditions.WorkspaceEntityIsNew).WithMatch(true);

    /// <summary>Requires the current workspace to be based on a Content Type whose Alias matches the one specified.</summary>
    public static IConditionManifest WorkspaceContentTypeAlias(string contentTypeAlias) =>
        For(Constants.Conditions.WorkspaceContentTypeAlias).WithMatch(contentTypeAlias);

    /// <summary>Requires the current workspace to be based on a Content Type whose Alias matches one of the specified aliases.</summary>
    public static IConditionManifest WorkspaceContentTypeAlias(params string[] contentTypeAliases) =>
        For(Constants.Conditions.WorkspaceContentTypeAlias).WithOneOf(contentTypeAliases);

    /// <summary>Requires the current workspace to be based on a Content Type that uniquely matches the one specified.</summary>
    public static IConditionManifest WorkspaceContentTypeUnique(string unique) =>
        For(Constants.Conditions.WorkspaceContentTypeUnique).WithMatch(unique);

    /// <summary>Requires the Content Type of the current Workspace to have properties.</summary>
    public static IConditionManifest WorkspaceContentHasProperties() =>
        For(Constants.Conditions.WorkspaceContentHasProperties).WithMatch(true);

    /// <summary>Requires the current Workspace to have a Content Collection.</summary>
    public static IConditionManifest WorkspaceHasCollection() =>
        For(Constants.Conditions.WorkspaceHasCollection).WithMatch(true);

    /// <summary>Requires the document in the current Workspace to be in the recycle bin.</summary>
    public static IConditionManifest WorkspaceDocumentIsTrashed() =>
        For(Constants.Conditions.WorkspaceDocumentIsTrashed);

    /// <summary>Requires the document in the current Workspace not to be in the recycle bin.</summary>
    public static IConditionManifest WorkspaceDocumentIsNotTrashed() =>
        For(Constants.Conditions.WorkspaceDocumentIsNotTrashed);

    /// <summary>Requires the entity in the current Workspace to have finished loading.</summary>
    public static IConditionManifest WorkspaceContentIsLoaded() =>
        For(Constants.Conditions.WorkspaceContentIsLoaded);

    // ── Entity ────────────────────────────────────────────────────────────────

    /// <summary>Requires the current entity to be of the given type.</summary>
    public static IConditionManifest EntityType(string type) =>
        For(Constants.Conditions.EntityType).WithMatch(type);

    /// <summary>Requires the current entity to be one of the given types.</summary>
    public static IConditionManifest EntityType(params string[] types) =>
        For(Constants.Conditions.EntityType).WithOneOf(types);

    /// <summary>Requires the current entity's unique identifier to match the one specified.</summary>
    public static IConditionManifest EntityUnique(string unique) =>
        For(Constants.Conditions.EntityUnique).WithMatch(unique);

    /// <summary>Requires the current entity to have one or more children.</summary>
    public static IConditionManifest EntityHasChildren() =>
        For(Constants.Conditions.EntityHasChildren);

    /// <summary>Requires the current entity's Content Type unique identifier to match the one specified.</summary>
    public static IConditionManifest EntityContentTypeUnique(string unique) =>
        For(Constants.Conditions.EntityContentTypeUnique).WithMatch(unique);

    /// <summary>Requires the current entity to be trashed.</summary>
    public static IConditionManifest EntityIsTrashed() =>
        For(Constants.Conditions.EntityIsTrashed).WithMatch(true);

    /// <summary>Requires the current entity not to be trashed.</summary>
    public static IConditionManifest EntityIsNotTrashed() =>
        For(Constants.Conditions.EntityIsNotTrashed).WithMatch(true);

    // ── Collection ────────────────────────────────────────────────────────────

    /// <summary>Requires the current Collection Alias to match the one specified.</summary>
    public static IConditionManifest CollectionAlias(string collectionAlias) =>
        For(Constants.Conditions.CollectionAlias).WithMatch(collectionAlias);

    /// <summary>Requires the current Collection to contain one or more items.</summary>
    public static IConditionManifest CollectionHasItems() =>
        For(Constants.Conditions.CollectionHasItems);

    // ── Property ──────────────────────────────────────────────────────────────

    /// <summary>Requires the current property to have a value.</summary>
    public static IConditionManifest PropertyHasValue() =>
        For(Constants.Conditions.PropertyHasValue);

    /// <summary>Requires the current property to be writable (not read-only).</summary>
    public static IConditionManifest PropertyWritable() =>
        For(Constants.Conditions.PropertyWritable);

    // ── Current User ──────────────────────────────────────────────────────────

    /// <summary>Requires the current user to be an admin.</summary>
    public static IConditionManifest CurrentUserIsAdmin() =>
        For(Constants.Conditions.CurrentUserIsAdmin);

    /// <summary>Requires the current user to belong to a specific group by GUID.</summary>
    public static IConditionManifest CurrentUserGroupId(string groupId) =>
        For(Constants.Conditions.CurrentUserGroupId).WithMatch(groupId);

    /// <summary>
    /// Entry point for multi-group current-user conditions.
    /// Chain with <c>WithOneOf</c>, <c>WithAllOf</c>, or <c>WithNoneOf</c>.
    /// </summary>
    public static IConditionManifestBuilder CurrentUserGroupId() =>
        For(Constants.Conditions.CurrentUserGroupId);

    /// <summary>Requires the current user to be allowed to change their password.</summary>
    public static IConditionManifest CurrentUserAllowChangePassword() =>
        For(Constants.Conditions.CurrentUserAllowChangePassword);

    /// <summary>Requires the current user to be allowed to manage Multi-Factor Authentication.</summary>
    public static IConditionManifest CurrentUserAllowMfaAction() =>
        For(Constants.Conditions.CurrentUserAllowMfaAction);

    /// <summary>Requires the current user to be allowed to access the Document recycle bin.</summary>
    public static IConditionManifest CurrentUserAllowDocumentRecycleBin() =>
        For(Constants.Conditions.CurrentUserAllowDocumentRecycleBin);

    /// <summary>Requires the current user to be allowed to access the Media recycle bin.</summary>
    public static IConditionManifest CurrentUserAllowMediaRecycleBin() =>
        For(Constants.Conditions.CurrentUserAllowMediaRecycleBin);

    // ── User Management Actions ───────────────────────────────────────────────

    public static IConditionManifest UserAllowChangePassword() => For(Constants.Conditions.UserAllowChangePassword);
    public static IConditionManifest UserAllowDeleteAction() => For(Constants.Conditions.UserAllowDeleteAction);
    public static IConditionManifest UserAllowDisableAction() => For(Constants.Conditions.UserAllowDisableAction);
    public static IConditionManifest UserAllowEnableAction() => For(Constants.Conditions.UserAllowEnableAction);
    public static IConditionManifest UserAllowUnlockAction() => For(Constants.Conditions.UserAllowUnlockAction);
    public static IConditionManifest UserAllowExternalLoginAction() => For(Constants.Conditions.UserAllowExternalLoginAction);
    public static IConditionManifest UserAllowMfaAction() => For(Constants.Conditions.UserAllowMfaAction);
    public static IConditionManifest UserIsDefaultKind() => For(Constants.Conditions.UserIsDefaultKind);
    public static IConditionManifest UserAllowResendInviteAction() => For(Constants.Conditions.UserAllowResendInviteAction);

    // ── User Permissions ──────────────────────────────────────────────────────

    /// <summary>Requires the current user to have specific Document permissions (e.g. "Umb.Document.Save").</summary>
    public static IConditionManifest UserPermissionDocument(string permission) =>
        For(Constants.Conditions.UserPermissionDocument).WithMatch(permission);

    /// <summary>Requires the current user to have the required permission for the Document's property values.</summary>
    public static IConditionManifest UserPermissionDocumentPropertyValue() =>
        For(Constants.Conditions.UserPermissionDocumentPropertyValue);

    /// <summary>Requires the current user to have the required permission for the given Language.</summary>
    public static IConditionManifest UserPermissionLanguage(string language) =>
        For(Constants.Conditions.UserPermissionLanguage).WithMatch(language);

    /// <summary>
    /// Fallback permission condition.
    /// Chain with <c>WithAllOf</c> or <c>WithOneOf</c>.
    /// </summary>
    public static IConditionManifestBuilder UserPermissionFallback() => For(Constants.Conditions.UserPermissionFallback);

    // ── Templating & Data Types ───────────────────────────────────────────────

    public static IConditionManifest TemplateAllowDeleteAction() => For(Constants.Conditions.TemplateAllowDeleteAction);
    public static IConditionManifest DataTypeAllowDeleteAction() => For(Constants.Conditions.DataTypeAllowDeleteAction);

    // ── Property Editors ──────────────────────────────────────────────────────

    public static IConditionManifest EntityDataPickerSupportsTextFilter() => For(Constants.Conditions.EntityDataPickerSupportsTextFilter);

    // ── Block ─────────────────────────────────────────────────────────────────

    public static IConditionManifest BlockHasSettings() => For(Constants.Conditions.BlockHasSettings);
    public static IConditionManifest BlockEntryShowContentEdit() => For(Constants.Conditions.BlockEntryShowContentEdit);
    public static IConditionManifest BlockWorkspaceIsExposed() => For(Constants.Conditions.BlockWorkspaceIsExposed);
    public static IConditionManifest BlockWorkspaceIsReadOnly() => For(Constants.Conditions.BlockWorkspaceIsReadOnly);
}
