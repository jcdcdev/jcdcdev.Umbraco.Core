using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class BlockListExtensions
{
    public static List<BlockListItem<TContent>> Items<TContent>(this IEnumerable<IBlockReference<IPublishedElement, IPublishedElement>>? model) where TContent : IPublishedElement
    {
        var items = new List<BlockListItem<TContent>>();
        if (model == null)
        {
            return items;
        }

        foreach (var block in model)
        {
            if (block is BlockListItem<TContent> item)
            {
                items.Add(item);
            }
        }

        return items;
    }

    public static IEnumerable<BlockListItem<TContent, TSettings>> Items<TContent, TSettings>(this IEnumerable<IBlockReference<IPublishedElement, IPublishedElement>>? model)
        where TContent : IPublishedElement where TSettings : IPublishedElement
    {
        foreach (var block in model ?? new List<IBlockReference<IPublishedElement, IPublishedElement>>())
        {
            if (block is BlockListItem<TContent, TSettings> item)
            {
                yield return item;
            }
        }
    }
}
