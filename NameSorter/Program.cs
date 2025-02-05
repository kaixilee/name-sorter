namespace NameSorter;

public class Program
{
    private const string OutputFilePath = "sorted-names-list.txt";

    public static async Task Main(string[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Please provide exactly one file path containing the names to be sorted, e.g. name-sorter <file-path>");
        }

        var inputFilePath = args[0];
        if (!File.Exists(inputFilePath))
        {
            throw new FileNotFoundException($"File '{inputFilePath}' not found.");
        }

        try
        {
            var names = await NameSorter.ReadNamesFromFileAsync(inputFilePath);
            var sortedNames = NameSorter.SortNames(names);
            await NameSorter.WriteNamesToFileAsync(OutputFilePath, sortedNames);

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