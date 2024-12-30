namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class ConditionManifest : IConditionManifest
{
    private ConditionManifest(string alias, object match)
    {
        Alias = alias;
        Match = match;
    }

    public static ConditionManifest Create(string alias, string match) => new(alias, match);
    public static ConditionManifest Create(string alias, bool match) => new(alias, match);

    /// <summary>
    /// Requires the current Section Alias to match the one specified.
    /// </summary>
    /// <param name="sectionAlias"> Section alias (e.g "Umb.Section.Content")</param>
    public static ConditionManifest SectionAlias(string sectionAlias)
    {
        return Create(Constants.Conditions.SectionAlias, sectionAlias);
    }

    /// <summary>
    /// Requires the current Menu Alias to match the one specified.
    /// </summary>
    /// <param name="menuAlias">Menu alias (e.g "Umb.Menu.Content")</param>
    public static ConditionManifest MenuAlias(string menuAlias) => Create(Constants.Conditions.MenuAlias, menuAlias);

    /// <summary>
    /// Requires the current Workspace Alias to match the one specified.
    /// </summary>
    /// <param name="workspaceAlias">Workspace alias (e.g "Umb.Workspace.Document")</param>
    public static ConditionManifest WorkspaceAlias(string workspaceAlias)
    {
        return Create(Constants.Conditions.WorkspaceAlias, workspaceAlias);
    }

    /// <summary>
    /// Requires the current workspace to work on the given Entity Type.
    /// </summary>
    /// <param name="entityType">Entity type (e.g "document", "block", "user")</param>
    public static ConditionManifest WorkspaceEntityType(string entityType)
    {
        return Create(Constants.Conditions.WorkspaceEntityType, entityType);
    }

    /// <summary>
    /// Requires the current workspace to be based on a Content Type which Alias matches the one specified.
    /// </summary>
    /// <param name="contentTypeAlias">Content Type alias (e.g "Umb.ContentType.Article")</param>
    public static ConditionManifest WorkspaceContentTypeAlias(string contentTypeAlias)
    {
        return Create(Constants.Conditions.WorkspaceContentTypeAlias, contentTypeAlias);
    }

    /// <summary>
    /// Requires the Content Type of the current Workspace to have properties.
    /// </summary>
    public static ConditionManifest WorkspaceContentHasProperties()
    {
        return Create(Constants.Conditions.WorkspaceContentHasProperties, true);
    }

    /// <summary>
    /// Requires the current Workspace to have a Collection.
    /// </summary>
    public static ConditionManifest WorkspaceHasCollection()
    {
        return Create(Constants.Conditions.WorkspaceHasCollection, true);
    }

    /// <summary>
    /// Requires the current Workspace data to be new, not yet persisted on the server.
    /// </summary>
    public static ConditionManifest WorkspaceEntityIsNew()
    {
        return Create(Constants.Conditions.WorkspaceEntityIsNew, true);
    }

    /// <summary>
    /// Requires the current entity to be trashed.
    /// </summary>
    public static ConditionManifest EntityIsTrashed()
    {
        return Create(Constants.Conditions.EntityIsTrashed, true);
    }

    /// <summary>
    /// Requires the current entity to not be trashed.
    /// </summary>
    public static ConditionManifest EntityIsNotTrashed()
    {
        return Create(Constants.Conditions.EntityIsNotTrashed, true);
    }

    /// <summary>
    /// Requires the current user to have permissions to the given Section Alias.
    /// </summary>
    /// <param name="sectionAlias">Section alias (e.g "Umb.Section.Content")</param>
    public static ConditionManifest SectionUserPermission(string sectionAlias)
    {
        return Create(Constants.Conditions.SectionUserPermission, sectionAlias);
    }

    /// <summary>
    /// Requires the current user to have specific Document permissions.
    /// </summary>
    /// <param name="documentPermission">Document permission (e.g "Umb.Document.Save")</param>
    public static ConditionManifest UserPermissionDocument(string documentPermission)
    {
        return Create(Constants.Conditions.UserPermissionDocument, documentPermission);
    }


    public string Alias { get; }
    public object Match { get; }
}

public interface IConditionManifest
{
    public string Alias { get; }
    public object Match { get; }
}
