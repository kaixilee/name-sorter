namespace NameSorter.Models;

public class Person
{
    public string FullName { get; }
    public string LastName { get; }
    public string GivenNames { get; }

    /// <summary>
    /// Initializes a new instance of the Person class with the specified full name.
    /// The name must have one last name, at least one given name, and not more than three given names.
    /// The last name is set to the last part of the full name, and the given names are set to the remaining parts.
    /// </summary>
    public Person(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Name can not be null");

        FullName = fullName.Trim();
        var nameParts = FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries); //split the full name into separate parts

        if (nameParts.Length == 1)
            throw new ArgumentException($"The name \"{fullName}\" is invalid. A full name must consist of a last name and at least one given name.");
        if (nameParts.Length > 4)
            throw new ArgumentException($"The name \"{fullName}\" is invalid. A full name must not have more than three given names.");
        
        LastName = nameParts[^1];  //get the last part of the full name
        GivenNames = string.Join(" ", nameParts[..^1]);  //get the remaining part(s) of the full name
    }
}
