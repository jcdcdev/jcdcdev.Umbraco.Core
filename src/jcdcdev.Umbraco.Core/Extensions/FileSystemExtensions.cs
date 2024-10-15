using Umbraco.Cms.Core.IO;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class FileSystemExtensions
{
    public static IEnumerable<string> GetFiles(this IFileSystem fs, string? path, bool recursive = false)
    {
        if (string.IsNullOrWhiteSpace(path) || !fs.DirectoryExists(path))
        {
            return Array.Empty<string>();
        }

        var files = fs.GetFiles(path);
        if (!recursive)
        {
            return files;
        }

        foreach (var directory in fs.GetDirectories(path))
        {
            files = files.Concat(GetFiles(fs, directory, true)).ToArray();
        }

        return files;
    }

    public static void CreateDirectoryIfNotExists(this IFileSystem fileSystem, string path)
    {
        if (!fileSystem.CanAddPhysical)
        {
            return;
        }

        if (!fileSystem.DirectoryExists(path))
        {
            fileSystem.CreateFolder(path);
        }
    }

    public static void CreateOrEmptyIfExists(this IFileSystem fileSystem, string backupDir)
    {
        if (!fileSystem.CanAddPhysical)
        {
            return;
        }

        DeleteDirectoryIfExists(fileSystem, backupDir, true);
        fileSystem.CreateFolder(backupDir);
    }

    public static void DeleteDirectoryIfExists(this IFileSystem fileSystem, string path, bool recursive = false)
    {
        if (!fileSystem.DirectoryExists(path))
        {
            fileSystem.DeleteDirectory(path, recursive);
        }
    }
}
