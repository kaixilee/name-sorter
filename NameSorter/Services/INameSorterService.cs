namespace NameSorter.Services;

public interface INameSorterService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="names"></param>
    /// <returns></returns>
    List<string> SortNames(IEnumerable<string> names);
}