namespace NameSorter.Models;

public class Person
{
    public string FullName { get; }
    public string LastName { get; }
    public string GivenNames { get; }

    public Person(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Name can not be null", nameof(fullName));

        FullName = fullName.Trim();
        var nameParts = FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (nameParts.Length == 1)
        {
            LastName = nameParts[0];
            GivenNames = string.Empty;
        }
        else
        {
            LastName = nameParts[^1];  //get the last part of the full name
            GivenNames = string.Join(" ", nameParts[..^1]);  //get the remaining part(s) of the full name
        }
    }
}
