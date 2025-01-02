using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class DataTypeContainerServiceExtensions
{
    public static async Task DeleteAllEmptyContainersAsync(
        this IDataTypeContainerService dataTypeContainerService,
        IDataTypeService dataTypeService,
        Guid? userKey = null)
    {
        var allDataTypes = await dataTypeService.GetAllAsync();
        var userKeyValue = userKey.GetValueOrDefault(global::Umbraco.Cms.Core.Constants.Security.SuperUserKey);
        var lookup = allDataTypes.GroupBy(x => x.ParentId).ToLookup(x => x.Key, x => x.Count());
        var containers = await dataTypeContainerService.GetAllAsync();

        foreach (var container in containers)
        {
            var hasChildren = lookup.Contains(container.Id);

            if (hasChildren)
            {
                continue;
            }

            await dataTypeContainerService.DeleteAsync(container.Key, userKeyValue);
        }
    }

    /// <summary>
    /// Gets or creates a container with the specified name
    /// <param name="folderName">The name to assign to the container</param>
    /// <param name="parentId">Id of the parent container</param>
    /// <param name="parentKey">Key of the parent container</param>
    /// <param name="userKey">Key of the user issuing the update</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// </summary>
    public static async Task<EntityContainer> GetOrCreateFolderAsync(
        this IDataTypeContainerService dataTypeService,
        string folderName,
        int parentId = -1,
        Guid? parentKey = null,
        Guid? userKey = null)
    {
        parentKey ??= global::Umbraco.Cms.Core.Constants.System.RootKey;
        var userKeyValue = userKey.GetValueOrDefault(global::Umbraco.Cms.Core.Constants.Security.SuperUserKey);
        var folders = await dataTypeService.GetAllAsync();
        var folder = folders.FirstOrDefault(x => x.ParentId == parentId && x.Name.InvariantEquals(folderName));
        if (folder != null)
        {
            return folder;
        }

        var attempt = await dataTypeService.CreateAsync(null, folderName, parentKey, userKeyValue);
        if (!attempt.Success || attempt.Result == null)
        {
            throw new InvalidOperationException($"Failed to create folder '{folderName}'", attempt.Exception);
        }

        return attempt.Result;
    }
}
