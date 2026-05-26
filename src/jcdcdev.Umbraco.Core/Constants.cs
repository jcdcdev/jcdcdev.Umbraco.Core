namespace jcdcdev.Umbraco.Core;

public static class Constants
{
    public class Menus
    {
        public const string Content = "Umb.Menu.Content";
        public const string Help = "Umb.Menu.Help";
        public const string Media = "Umb.Menu.Media";
        public const string MemberManagement = "Umb.Menu.MemberManagement";
        public const string StructureSettings = "Umb.Menu.StructureSettings";
        public const string AdvancedSettings = "Umb.Menu.AdvancedSettings";
        public const string Templating = "Umb.Menu.Templating";
        public const string Translation = "Umb.Menu.Translation";
        public const string UserManagement = "Umb.Menu.UserManagement";

        // ReSharper disable once InconsistentNaming
        public const string uSync = "usync.menu";
    }

    public class Conditions
    {
        // General / Environment
        public const string Switch = "Umb.Condition.Switch";
        public const string MultipleAppLanguages = "Umb.Condition.MultipleAppLanguages";
        public const string InModal = "Umb.Condition.InModal";
        public const string ServerIsProductionMode = "Umb.Condition.Server.IsProductionMode";
        public const string Delay = "Umb.Condition.Delay";
        public const string IsRoutableContext = "Umb.Condition.IsRoutableContext";

        // Section
        public const string SectionAlias = "Umb.Condition.SectionAlias";
        public const string SectionUserPermission = "Umb.Condition.SectionUserPermission";

        // Menu
        public const string MenuAlias = "Umb.Condition.MenuAlias";

        // Workspace
        public const string WorkspaceAlias = "Umb.Condition.WorkspaceAlias";
        public const string WorkspaceEntityType = "Umb.Condition.WorkspaceEntityType";
        public const string WorkspaceEntityIsNew = "Umb.Condition.WorkspaceEntityIsNew";
        public const string WorkspaceContentTypeAlias = "Umb.Condition.WorkspaceContentTypeAlias";
        public const string WorkspaceContentTypeUnique = "Umb.Condition.WorkspaceContentTypeUnique";
        public const string WorkspaceContentHasProperties = "Umb.Condition.Workspace.ContentHasProperties";
        public const string WorkspaceHasCollection = "Umb.Condition.WorkspaceHasContentCollection";
        public const string WorkspaceDocumentIsTrashed = "Umb.Condition.Workspace.DocumentIsTrashed";
        public const string WorkspaceDocumentIsNotTrashed = "Umb.Condition.Workspace.DocumentIsNotTrashed";
        public const string WorkspaceContentIsLoaded = "Umb.Condition.Workspace.ContentIsLoaded";

        // Entity
        public const string EntityType = "Umb.Condition.Entity.Type";
        public const string EntityUnique = "Umb.Condition.Entity.Unique";
        public const string EntityHasChildren = "Umb.Condition.EntityHasChildren";
        public const string EntityContentTypeUnique = "Umb.Condition.EntityContentType.Unique";
        public const string EntityIsTrashed = "Umb.Condition.EntityIsTrashed";
        public const string EntityIsNotTrashed = "Umb.Condition.EntityIsNotTrashed";

        // Collection
        public const string CollectionAlias = "Umb.Condition.CollectionAlias";
        public const string CollectionBulkActionPermission = "Umb.Condition.CollectionBulkActionPermission";
        public const string CollectionHasItems = "Umb.Condition.CollectionHasItems";

        // Property
        public const string PropertyHasValue = "Umb.Condition.Property.HasValue";
        public const string PropertyWritable = "Umb.Condition.Property.Writable";

        // Current User
        public const string CurrentUserIsAdmin = "Umb.Condition.CurrentUser.IsAdmin";
        public const string CurrentUserGroupId = "Umb.Condition.CurrentUser.GroupId";
        public const string CurrentUserAllowChangePassword = "Umb.Condition.CurrentUser.AllowChangePassword";
        public const string CurrentUserAllowMfaAction = "Umb.Condition.CurrentUser.AllowMfaAction";
        public const string CurrentUserAllowDocumentRecycleBin = "Umb.Condition.CurrentUser.AllowDocumentRecycleBin";
        public const string CurrentUserAllowMediaRecycleBin = "Umb.Condition.CurrentUser.AllowMediaRecycleBin";

        // User Management Actions
        public const string UserAllowChangePassword = "Umb.Condition.User.AllowChangePassword";
        public const string UserAllowDeleteAction = "Umb.Condition.User.AllowDeleteAction";
        public const string UserAllowDisableAction = "Umb.Condition.User.AllowDisableAction";
        public const string UserAllowEnableAction = "Umb.Condition.User.AllowEnableAction";
        public const string UserAllowUnlockAction = "Umb.Condition.User.AllowUnlockAction";
        public const string UserAllowExternalLoginAction = "Umb.Condition.User.AllowExternalLoginAction";
        public const string UserAllowMfaAction = "Umb.Condition.User.AllowMfaAction";
        public const string UserIsDefaultKind = "Umb.Condition.User.IsDefaultKind";
        public const string UserAllowResendInviteAction = "Umb.Condition.User.AllowResendInviteAction";

        // User Permissions
        public const string UserPermissionDocument = "Umb.Condition.UserPermission.Document";
        public const string UserPermissionDocumentPropertyValue = "Umb.Condition.UserPermission.Document.PropertyValue";
        public const string UserPermissionLanguage = "Umb.Condition.UserPermission.Language";
        public const string UserPermissionFallback = "Umb.Condition.UserPermission.Fallback";

        // Templating & Data Types
        public const string TemplateAllowDeleteAction = "Umb.Condition.Template.AllowDeleteAction";
        public const string DataTypeAllowDeleteAction = "Umb.Condition.DataType.AllowDeleteAction";

        // Property Editors
        public const string EntityDataPickerSupportsTextFilter = "Umb.Condition.EntityDataPicker.SupportsTextFilter";

        // Block
        public const string BlockHasSettings = "Umb.Condition.BlockWorkspaceHasSettings";
        public const string BlockEntryShowContentEdit = "Umb.Condition.BlockEntryShowContentEdit";
        public const string BlockWorkspaceIsExposed = "Umb.Condition.BlockWorkspaceIsExposed";
        public const string BlockWorkspaceIsReadOnly = "Umb.Condition.BlockWorkspaceIsReadOnly";
    }

    public class Sections
    {
        public const string Content = "Umb.Section.Content";
        public const string Media = "Umb.Section.Media";
        public const string Settings = "Umb.Section.Settings";
        public const string Members = "Umb.Section.Members";
        public const string Packages = "Umb.Section.Packages";
        public const string Dictionary = "Umb.Section.Translation";
        public const string Users = "Umb.Section.Users";
    }

    public class Workspaces
    {
        public const string Block = "Umb.Workspace.Block";
        public const string BlockGridAreaType = "Umb.Workspace.BlockGridAreaType";
        public const string BlockGridType = "Umb.Workspace.BlockGridType";
        public const string BlockListType = "Umb.Workspace.BlockListType";
        public const string BlockRteType = "Umb.Workspace.BlockRteType";
        public const string DataType = "Umb.Workspace.DataType";
        public const string Dictionary = "Umb.Workspace.Dictionary";
        public const string Document = "Umb.Workspace.Document";
        public const string DocumentBlueprint = "Umb.Workspace.DocumentBlueprint";
        public const string DocumentBlueprintFolder = "Umb.Workspace.DocumentBlueprint.Folder";
        public const string DocumentBlueprintRoot = "Umb.Workspace.DocumentBlueprint.Root";
        public const string DocumentType = "Umb.Workspace.DocumentType";
        public const string ExtensionRoot = "Umb.Workspace.ExtensionRoot";
        public const string Language = "Umb.Workspace.Language";
        public const string LanguageRoot = "Umb.Workspace.LanguageRoot";
        public const string LogViewer = "Umb.Workspace.LogViewer";
        public const string Media = "Umb.Workspace.Media";
        public const string MediaType = "Umb.Workspace.MediaType";
        public const string Member = "Umb.Workspace.Member";
        public const string MemberGroup = "Umb.Workspace.MemberGroup";
        public const string MemberType = "Umb.Workspace.MemberType";
        public const string Package = "Umb.Workspace.Package";
        public const string PackageBuilder = "Umb.Workspace.PackageBuilder";
        public const string PartialView = "Umb.Workspace.PartialView";
        public const string PropertyType = "Umb.Workspace.PropertyType";
        public const string RelationType = "Umb.Workspace.RelationType";
        public const string RelationTypeRoot = "Umb.Workspace.RelationTypeRoot";
        public const string Script = "Umb.Workspace.Script";
        public const string Stylesheet = "Umb.Workspace.Stylesheet";
        public const string Template = "Umb.Workspace.Template";
        public const string User = "Umb.Workspace.User";
        public const string UserGroup = "Umb.Workspace.UserGroup";
        public const string Webhook = "Umb.Workspace.Webhook";
        public const string WebhookRoot = "Umb.Workspace.WebhookRoot";
    }
}
