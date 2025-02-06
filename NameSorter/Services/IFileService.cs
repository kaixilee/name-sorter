namespace NameSorter.Services;

public interface IFileService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    Task<string[]> ReadFileFromPathAsync(string path);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    Task WriteFileToPathAsync(string path, List<string> content);
}