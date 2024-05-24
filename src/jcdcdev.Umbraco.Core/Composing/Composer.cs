using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace jcdcdev.Umbraco.Core.Composing;

internal class Composer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddSimplePackageManifests();
    }
}
