using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.DependencyInjection;
using Umbraco.Extensions;

#if UMBRACO_14
using Umbraco.Cms.Core.DependencyInjection;
#endif

namespace jcdcdev.Umbraco.Core.Extensions;

public static class LinkExtensions
{
    public static string? Url(this Link? link, UrlMode mode = UrlMode.Default)
    {
        if (link == null || link.Url.IsNullOrWhiteSpace())
        {
            return string.Empty;
        }

        if (link.Type == LinkType.External)
        {
            return link.Url;
        }

        try
        {
            var pathAndQuery = link.Url.Split("?");
            var path = pathAndQuery[0];
            if (!path.StartsWith("/"))
            {
                return path;
            }

            var query = pathAndQuery.Length > 1 ? pathAndQuery[1] : string.Empty;
            var applicationUrl = StaticServiceProvider.Instance.GetRequiredService<IUmbracoContextAccessor>().GetRequiredUmbracoContext().CleanedUmbracoUrl;
            var b = new UriBuilder(applicationUrl)
            {
                Scheme = "https",
                Port = -1,
                Path = path,
                Query = query
            };

            if (mode != UrlMode.Absolute)
            {
                b.Host = string.Empty;
            }

            return b.Uri.ToString();
        }
        catch (Exception e)
        {
            StaticApplicationLogging.Logger.LogError(e, "Error getting application URL");
        }

        return string.Empty;
    }
}
