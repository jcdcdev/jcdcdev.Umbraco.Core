using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Cache;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class ControllerExtensions
{
    public static async Task<string> RenderViewComponentToStringAsync<T>(this Controller controller, string viewComponentName, T model)
    {
        var sp = controller.HttpContext.RequestServices;
        var helper = new DefaultViewComponentHelper(
            sp.GetRequiredService<IViewComponentDescriptorCollectionProvider>(),
            NullHtmlEncoder.Default,
            sp.GetRequiredService<IViewComponentSelector>(),
            sp.GetRequiredService<IViewComponentInvokerFactory>(),
            sp.GetRequiredService<IViewBufferScope>());

        await using var writer = new StringWriter();
        var viewContext = new ViewContext(controller.ControllerContext, NullView.Instance, controller.ViewData, controller.TempData, writer, new HtmlHelperOptions());
        helper.Contextualize(viewContext);
        var vcResult = await helper.InvokeAsync(viewComponentName, new { Model = model });
        vcResult.WriteTo(writer, NullHtmlEncoder.Default);
        await writer.FlushAsync();
        return writer.ToString();
    }

    public static async Task<string> RenderViewResultToStringAsync(this Controller controller, ViewEngineResult result, object? model)
    {
        if (result.View == null)
        {
            throw new ArgumentNullException(nameof(result.View));
        }

        var writer = new StringWriter();
        var actionContext = new ActionContext(controller.HttpContext, controller.RouteData, controller.ControllerContext.ActionDescriptor, controller.ModelState);
        var viewContext = new ViewContext(actionContext, result.View, controller.ViewData, controller.TempData, writer, new HtmlHelperOptions())
        {
            ViewData =
            {
                Model = model
            }
        };

        await result.View.RenderAsync(viewContext);
        return writer.ToString();
    }

    public static bool ViewComponentExists(this Controller controller, string viewComponentName)
    {
        var sp = controller.HttpContext.RequestServices;
        var appCaches = sp.GetRequiredService<AppCaches>();
        var viewComponentDescriptorProvider = sp.GetRequiredService<IViewComponentDescriptorProvider>();
        var runtimeCache = appCaches.RuntimeCache;

        return runtimeCache.GetCacheItem(viewComponentName, () =>
        {
            var viewComponentDescriptors = viewComponentDescriptorProvider.GetViewComponents();
            return viewComponentDescriptors.Any(vc => vc.ShortName == viewComponentName);
        });
    }

    internal sealed class NullView : IView
    {
        public static readonly NullView Instance = new();

        public string Path => string.Empty;

        public Task RenderAsync(ViewContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            return Task.CompletedTask;
        }
    }
}
