using FluentAssertions;
using NameSorter.Services;
using System.IO.Abstractions.TestingHelpers;

namespace NameSorter.Tests.Services
{
    public class FileServiceTests
    {
        private const string FilePath = "/path/to/file.txt";
        private const string FileContents = "fileContents";

        private readonly MockFileSystem _mockFileSystem = new();
        private readonly FileService _fileService;

        public FileServiceTests()
        {
            _fileService = new FileService(_mockFileSystem);
        }

        [Fact]
        public async Task ReadFileFromPathAsync_ShouldReturnFileContents()
        {
            // arrange
            _mockFileSystem.AddFile(FilePath, new MockFileData(FileContents));

            // act
            var result = await _fileService.ReadFileFromPathAsync(FilePath);

            // assert
            result.Should().Equal(FileContents);
        }

        [Fact]
        public async Task ReadFileFromPathAsync_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
        {
            // act & assert
            await Assert.ThrowsAsync<FileNotFoundException>(() => _fileService.ReadFileFromPathAsync(FilePath));
        }

        [Fact]
        public async Task WriteFileToPathAsync_ShouldWriteContentsToFile()
        {
            // arrange
            _mockFileSystem.AddDirectory("/path/to");

            // act
            await _fileService.WriteFileToPathAsync(FilePath, [FileContents]);

            // assert
            var result = await _mockFileSystem.File.ReadAllLinesAsync(FilePath);
            result.Should().Equal(FileContents);
        }
        
        [Fact]
        public async Task WriteFileToPathAsync_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
        {
            // act & assert
            await Assert.ThrowsAsync<DirectoryNotFoundException>(() => _fileService.WriteFileToPathAsync(FilePath, [FileContents]));
        }
    }
}