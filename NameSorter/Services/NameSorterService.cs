using NameSorter.Models;

namespace NameSorter.Services
{
    public class NameSorterService : INameSorterService
    {
        public List<string> SortNames(IEnumerable<string> names)
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
    }
}