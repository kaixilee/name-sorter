namespace NameSorter.Services;

public interface INameSorterService
{
    /// <summary>
    /// Sorts a list of names by last name and then by given names.
    /// A name must have at least one given name and may have up to three given names.
    /// </summary>
    /// <param name="names">The collection of names to be sorted</param>
    /// <returns>A list of sorted names</returns>
    List<string> SortNames(IEnumerable<string> names);
}