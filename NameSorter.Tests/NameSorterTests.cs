using FluentAssertions;

namespace NameSorter.Tests;

public class NameSorterTests
{
    [Fact]
    public void SortNames_SortsListOfNames()
    {
        // arrange
        var unsortedNames = new[] {"Christopher Robin", "Winnie The Pooh", "Kanga Roo"};
        
        // act
        var result = NameSorter.SortNames(unsortedNames);

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
        var result = NameSorter.SortNames(unsortedNames);

        // assert
        var expectedSortedNames = new[] { "Winnie The Pooh" };
        result.Should().Equal(expectedSortedNames);
    }
    
    [Fact]
    public void SortNames_CanSortMononymousNames()
    {
        // arrange
        var unsortedNames = new[] {"Winnie The Pooh", "Christopher Robin", "Eeyore" };
        
        // act
        var result = NameSorter.SortNames(unsortedNames);

        // assert
        var expectedSortedNames = new[] { "Eeyore", "Winnie The Pooh", "Christopher Robin" };
        result.Should().Equal(expectedSortedNames);
    }
    
    [Fact]
    public void SaveSortedNames_Success()
    {
        
    }
    
    [Fact]
    public void SaveSortedNames_Fail()
    {
        
    }
}