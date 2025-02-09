using System.IO.Abstractions;

namespace NameSorter.Services;

public class FileService : IFileService
{
    private readonly IFileSystem _fileSystem;
    public FileService(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }
    public async Task<string[]> ReadFileFromPathAsync(string path)
    {
        if (!_fileSystem.File.Exists(path))
            throw new FileNotFoundException($"File not found: {path}");
        
        return await _fileSystem.File.ReadAllLinesAsync(path);
    }

    public async Task WriteFileToPathAsync(string path, List<string> content)
    {
        var directory = _fileSystem.Path.GetDirectoryName(path);
        if (!_fileSystem.Directory.Exists(directory))
            throw new DirectoryNotFoundException($"Directory not found: {directory}");

        await _fileSystem.File.WriteAllLinesAsync(path, content);
    }
}