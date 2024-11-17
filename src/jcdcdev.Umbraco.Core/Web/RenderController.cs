using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;

namespace jcdcdev.Umbraco.Core.Web;

public abstract class RenderController<T>(
    ILogger<RenderController> logger,
    ICompositeViewEngine compositeViewEngine,
    IUmbracoContextAccessor umbracoContextAccessor,
    UmbracoHelper helper)
    : RenderController(logger, compositeViewEngine, umbracoContextAccessor)
    where T : class, IPublishedContent
{
    protected UmbracoHelper Helper { get; } = helper;
    public IUmbracoContextAccessor UmbracoContextAccessor { get; } = umbracoContextAccessor;

    protected override T CurrentPage => base.CurrentPage as T ?? throw new InvalidOperationException();
}
