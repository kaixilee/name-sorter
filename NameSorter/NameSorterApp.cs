using NameSorter.Services;

namespace NameSorter
{
    public class NameSorterApp
    {
        private readonly IFileService _fileService;
        private readonly INameSorterService _nameSorterService;
        private const string OutputFilePath = "sorted-names-list.txt";

        public NameSorterApp(IFileService fileService, INameSorterService nameSorterService)
        {
            _fileService = fileService;
            _nameSorterService = nameSorterService;
        }

        public async Task RunAsync(string inputFilePath)
        {
            try
            {
                // sort the names and write the output to sorted-names-list.txt
                var names = await _fileService.ReadFileFromPathAsync(inputFilePath);
                var sortedNames = _nameSorterService.SortNames(names);
                await _fileService.WriteFileToPathAsync(OutputFilePath, sortedNames);

                // print the sorted names to console
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
}