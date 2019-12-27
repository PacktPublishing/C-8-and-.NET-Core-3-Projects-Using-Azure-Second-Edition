using System;
using Xunit;
using PhotoStorage.Helpers.FileHelper;

namespace PhotoStorage.UnitTests
{
    public class FileHelperTests
    {
        [Theory]
        [InlineData("test.jpg", true)]
        [InlineData("face.png", true)]
        [InlineData("logfile.txt", false)]
        [InlineData("file.exe", false)]
        public void IsImage(string filename, bool expectedResult)
        {
            // Arrange            

            // Act
            bool isImage = FileHelper.IsImage(filename);

            // Assert
            Assert.Equal(expectedResult, isImage);
        }
    }
}
