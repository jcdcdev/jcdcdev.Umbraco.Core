#if UMBRACO_13_OR_LESS
using Umbraco.Cms.Core.Dashboards;

namespace jcdcdev.Umbraco.Core.AccessRule;

public interface IAccessRuleUserGroupBuilder
{
    IAccessRule UserGroup(string userGroup);
}

public interface IAccessRuleSectionBuilder
{
    IAccessRule Section(string section);
}

public interface IAccessRuleBuilder : IAccessRuleUserGroupBuilder
{
}
#endif
