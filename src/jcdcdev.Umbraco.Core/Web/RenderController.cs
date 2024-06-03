using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;

namespace jcdcdev.Umbraco.Core.Web;

public abstract class RenderController<T> : RenderController where T : class, IPublishedContent
{
    protected RenderController(
        ILogger<RenderController> logger,
        ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor,
        UmbracoHelper helper) : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        Helper = helper;
        UmbracoContextAccessor = umbracoContextAccessor;
    }

    protected UmbracoHelper Helper { get; }
    public IUmbracoContextAccessor UmbracoContextAccessor { get; }

    protected override T CurrentPage => base.CurrentPage as T ?? throw new InvalidOperationException();
}
