using NameSorter.Models;

namespace NameSorter
{
    public class NameSorter
    {
        public static List<string> SortNames(IEnumerable<string> names)
        {
            try
            {
                return names
                    .Where(name => !string.IsNullOrWhiteSpace(name))
                    .Select(name => new Person(name))
                    .OrderBy(person => person.LastName)
                    .ThenBy(person => person.GivenNames)
                    .Select(person => person.FullName)
                    .ToList();
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine($"There was an error sorting the given names: {exception.Message}");
                throw;
            }
        }
        
        public static async Task<string[]> ReadNamesFromFileAsync(string filePath)
        {
            return await File.ReadAllLinesAsync(filePath);
        }
        
        public static async Task WriteNamesToFileAsync(string filePath, IEnumerable<string> names)
        {
            await File.WriteAllLinesAsync(filePath, names);
        }
    }
}
