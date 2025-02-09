using Moq;
using NameSorter.Services;

namespace NameSorter.Tests.App
{
    public class NameSorterAppTests
    {
        private readonly Mock<IFileService> _fileServiceMock = new();
        private readonly Mock<INameSorterService> _nameSorterServiceMock = new();
        private readonly NameSorterApp _nameSorterApp;

        public NameSorterAppTests()
        {
            _nameSorterApp = new NameSorterApp(_fileServiceMock.Object, _nameSorterServiceMock.Object);
        }

        [Fact]
        public async Task RunAsync_ShouldSortNamesAndWriteToFile()
        {
            // arrange
            const string inputFilePath = "unsorted-names-list.txt";
            const string outputFilePath = "sorted-names-list.txt";
            var unsortedNames = new[] { "Christopher Robin", "Winnie The Pooh", "Kanga Roo" };
            var sortedNames = new List<string> { "Kanga Roo", "Winnie The Pooh", "Christopher Robin" };

            _fileServiceMock.Setup(fs => fs.ReadFileFromPathAsync(inputFilePath)).ReturnsAsync(unsortedNames);
            _nameSorterServiceMock.Setup(nss => nss.SortNames(unsortedNames)).Returns(sortedNames);
            _fileServiceMock.Setup(fs => fs.WriteFileToPathAsync(outputFilePath, sortedNames)).Returns(Task.CompletedTask);

            // act
            await _nameSorterApp.RunAsync(inputFilePath);

            // assert
            _fileServiceMock.Verify(fs => fs.ReadFileFromPathAsync(inputFilePath), Times.Once);
            _nameSorterServiceMock.Verify(ns => ns.SortNames(unsortedNames), Times.Once);
            _fileServiceMock.Verify(fs => fs.WriteFileToPathAsync(outputFilePath, sortedNames), Times.Once);
        }

        [Fact]
        public async Task RunAsync_ShouldHandleExceptions()
        {
            // arrange
            const string inputFilePath = "unsorted-names-list.txt";
            const string exceptionMessage = "File not found";

            _fileServiceMock.Setup(fs => fs.ReadFileFromPathAsync(inputFilePath)).ThrowsAsync(new Exception(exceptionMessage));

            // act & assert
            await Assert.ThrowsAsync<Exception>(() => _nameSorterApp.RunAsync(inputFilePath));
        }
    }
}