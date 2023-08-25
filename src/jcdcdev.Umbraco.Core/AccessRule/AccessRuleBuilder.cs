using Umbraco.Cms.Core.Dashboards;

namespace jcdcdev.Umbraco.Core.AccessRule;

public class AccessRuleBuilder : IAccessRuleBuilder
{
    private readonly global::Umbraco.Cms.Core.Dashboards.AccessRule _rule;
    private readonly bool _allow;

    public static IAccessRuleUserGroupBuilder Deny()
    {
        return new AccessRuleBuilder(false);
    }

    public static IAccessRuleBuilder Allow()
    {
        return new AccessRuleBuilder();
    }

    private AccessRuleBuilder(bool allow = true)
    {
        _rule = new global::Umbraco.Cms.Core.Dashboards.AccessRule();
        _allow = allow;
    }

    public IAccessRule Section(string section)
    {
        _rule.Type = _allow ? AccessRuleType.GrantBySection : AccessRuleType.Deny;
        _rule.Value = section;
        return _rule;
    }

    public IAccessRule UserGroup(string userGroup)
    {
        _rule.Type = _allow ? AccessRuleType.Grant : AccessRuleType.Deny;
        _rule.Value = userGroup;
        return _rule;
    }
}
