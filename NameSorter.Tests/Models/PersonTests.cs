using FluentAssertions;
using NameSorter.Models;

namespace NameSorter.Tests.Models;

public class PersonTests
{
    [Theory]
    [InlineData("Winnie The Pooh", "Pooh", "Winnie The")]
    [InlineData("Christopher          Robin", "Robin", "Christopher")]
    public void Person_ShouldInitialiseNamesProperly(string fullName, string lastName, string givenNames)
    {
        // act
        var person = new Person(fullName);

        // assert
        person.FullName.Should().Be(fullName);
        person.LastName.Should().Be(lastName);
        person.GivenNames.Should().Be(givenNames);
    }

    [Fact]
    public void Person_ShouldThrowExceptionForMononymousName()
    {
        // arrange
        var fullName = "Piglet";

        // act & assert
        Assert.Throws<ArgumentException>(() => new Person(fullName));
    }
    
    [Fact]
    public void Person_ShouldThrowExceptionForMoreThanThreeGivenNames()
    {
        // arrange
        var fullName = "Eeyore Rabbit Owl Kanga Roo";

        // act & assert
        Assert.Throws<ArgumentException>(() => new Person(fullName));
    }
}