namespace NameSorter.Services;

public interface IFileService
{
    /// <summary>
    /// Reads all lines from the file at the specified path
    /// </summary>
    /// <param name="path">The path to the file to read</param>
    /// <returns>An array of strings representing the lines of the file</returns>
    Task<string[]> ReadFileFromPathAsync(string path);
    
    /// <summary>
    /// Writes the specified content to the file at the specified path
    /// </summary>
    /// <param name="path">The path to the file to write</param>
    /// <param name="content">The content to write to the file</param>
    Task WriteFileToPathAsync(string path, List<string> content);
}