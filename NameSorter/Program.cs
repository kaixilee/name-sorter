using NameSorter.Services;

namespace NameSorter;

public class Program
{
    private const string OutputFilePath = "sorted-names-list.txt";

    public static async Task Main(string[] args)
    {
        
        if (args.Length != 1)
            throw new ArgumentException("Please provide exactly one file path containing the names to be sorted, e.g. name-sorter <file-path>");

        var inputFilePath = args[0];
        IFileService fileService = new FileService();
        INameSorterService nameSorterService = new NameSorterService();

        try
        {
            //sort the names and write the output to sorted-names-list.txt
            var names = await fileService.ReadFileFromPathAsync(inputFilePath);
            var sortedNames = nameSorterService.SortNames(names);
            await fileService.WriteFileToPathAsync(OutputFilePath, sortedNames);

            //print the sorted names to console
            foreach (var name in sortedNames)
            {
                Console.WriteLine(name);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}