using System.IO.Abstractions;
using NameSorter.Services;

namespace NameSorter;

public class Program
{
    public static async Task Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Please provide exactly one file path containing the names to be sorted.");
            return;
        }

        var inputFilePath = args[0];
        IFileService fileService = new FileService(new FileSystem());
        INameSorterService nameSorterService = new NameSorterService();

        var app = new NameSorterApp(fileService, nameSorterService);
        await app.RunAsync(inputFilePath);
    }
}
