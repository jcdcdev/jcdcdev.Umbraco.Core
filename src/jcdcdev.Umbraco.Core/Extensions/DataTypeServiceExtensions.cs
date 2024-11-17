using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class DataTypeServiceExtensions
{
    [Obsolete("Please use IDataTypeContainerService for all data type container operations. Will be removed in V15.")]
    public static IEnumerable<EntityContainer> GetAllContainers(this IDataTypeService dataTypeService) => dataTypeService.GetContainers([]);

    [Obsolete("Please use IDataTypeContainerService for all data type container operations. Will be removed in V15.")]
    public static void DeleteAllEmptyContainers(this IDataTypeService dataTypeService)
    {
        var dataTypes = dataTypeService.GetAll();
        var lookup = dataTypes.GroupBy(x => x.ParentId).ToLookup(x => x.Key, x => x.Count());
        var containers = dataTypeService.GetAllContainers();

        foreach (var container in containers)
        {
            var hasChildren = lookup.Contains(container.Id);

            if (hasChildren)
            {
                continue;
            }

            dataTypeService.DeleteContainer(container.Id);
        }
    }

    [Obsolete("Please use IDataTypeContainerService for all data type container operations. Will be removed in V15.")]
    public static EntityContainer GetOrCreateFolder(
        this IDataTypeService dataTypeService,
        string folder,
        int parentId = -1)
    {
        var dts = dataTypeService
            .GetAllContainers()
            .FirstOrDefault(x => x.ParentId == parentId && x.Name.InvariantEquals(folder));

        if (dts == null)
        {
            dts = dataTypeService.CreateContainer(parentId, new Guid(), folder).Result?.Entity;
        }

        return dts ?? throw new Exception();
    }
}
