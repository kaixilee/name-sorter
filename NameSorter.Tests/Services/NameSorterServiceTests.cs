using FluentAssertions;
using NameSorter.Services;

namespace NameSorter.Tests.Services;

public class NameSorterServiceTests
{
    private readonly NameSorterService _nameSorterService;

    public NameSorterServiceTests()
    {
        _nameSorterService = new NameSorterService();
    }

    [Fact]
    public void SortNames_SortsListOfNames()
    {
        // arrange
        var unsortedNames = new[] {"Christopher Robin", "Winnie The Pooh", "Kanga Roo"};
        
        // act
        var result = _nameSorterService.SortNames(unsortedNames);

        // assert
        var expectedSortedNames = new[] { "Winnie The Pooh", "Christopher Robin", "Kanga Roo" };
        result.Should().Equal(expectedSortedNames);
    }
    
    [Fact]
    public void SortNames_SortsSingleName()
    {
        // arrange
        var unsortedNames = new[] {"Winnie The Pooh"};
        
        // act
        var result = _nameSorterService.SortNames(unsortedNames);

        // assert
        var expectedSortedNames = new[] { "Winnie The Pooh" };
        result.Should().Equal(expectedSortedNames);
    }
    
    [Fact]
    public void SortNames_ThrowsExceptionForMononymousNames()
    {
        // arrange
        var unsortedNames = new[] { "Eeyore" };
        
        // act & assert
        Assert.Throws<ArgumentException>(() => _nameSorterService.SortNames(unsortedNames));
    }
}