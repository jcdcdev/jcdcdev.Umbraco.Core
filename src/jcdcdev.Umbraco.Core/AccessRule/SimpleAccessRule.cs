#if UMBRACO_13_OR_LESS
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Dashboards;

namespace jcdcdev.Umbraco.Core.AccessRule;

public static class SimpleAccessRule
{
    public static IAccessRule AllowEditorGroup => GrantByUserGroup(Constants.Security.EditorGroupAlias);
    public static IAccessRule AllowAdminGroup => GrantByUserGroup(Constants.Security.AdminGroupAlias);
    public static IAccessRule AllowTranslatorGroup => GrantByUserGroup(Constants.Security.TranslatorGroupAlias);
    public static IAccessRule AllowWriterGroup => GrantByUserGroup(Constants.Security.WriterGroupAlias);

    public static IAccessRule AllowContentSection => GrantBySection(Constants.Applications.Content);
    public static IAccessRule AllowUsersSection => GrantBySection(Constants.Applications.Users);
    public static IAccessRule AllowFormsSection => GrantBySection(Constants.Applications.Forms);
    public static IAccessRule AllowMediaSection => GrantBySection(Constants.Applications.Media);
    public static IAccessRule AllowMembersSection => GrantBySection(Constants.Applications.Members);
    public static IAccessRule AllowPackagesSection => GrantBySection(Constants.Applications.Packages);
    public static IAccessRule AllowSettingsSection => GrantBySection(Constants.Applications.Settings);
    public static IAccessRule AllowTranslationSection => GrantBySection(Constants.Applications.Translation);

    public static IAccessRule DenyEditorGroup => DenyUserGroup(Constants.Security.EditorGroupAlias);
    public static IAccessRule DenyAdminGroup => DenyUserGroup(Constants.Security.AdminGroupAlias);
    public static IAccessRule DenyTranslatorGroup => DenyUserGroup(Constants.Security.TranslatorGroupAlias);
    public static IAccessRule DenyWriterGroup => DenyUserGroup(Constants.Security.WriterGroupAlias);

    public static IAccessRule GrantByUserGroup(string groupAlias) => new global::Umbraco.Cms.Core.Dashboards.AccessRule { Type = AccessRuleType.Grant, Value = groupAlias };

    public static IAccessRule GrantBySection(string section) => new global::Umbraco.Cms.Core.Dashboards.AccessRule { Type = AccessRuleType.GrantBySection, Value = section };

    public static IAccessRuleBuilder Allow() => AccessRuleBuilder.Allow();

    public static IAccessRule DenyUserGroup(string userGroup) => AccessRuleBuilder.Deny().UserGroup(userGroup);
}
#endif
