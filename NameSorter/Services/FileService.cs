namespace NameSorter.Services;

public class FileService : IFileService
{
    public async Task<string[]> ReadFileFromPathAsync(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"File not found: {path}");
        
        return await File.ReadAllLinesAsync(path);
    }

    public async Task WriteFileToPathAsync(string path, List<string> content)
    {
        await File.WriteAllLinesAsync(path, content);
    }
}