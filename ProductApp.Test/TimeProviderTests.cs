using System;
using Xunit;
using ProductApp.Services;

namespace ProductApp.Tests
{
    public class TimeProviderTests
    {
        [Fact]
        public void GetCurrentTime_ReturnsValueBetweenBeforeAndAfter()
        {
            // Arrange
            var sut = new AppTimeProvider();
            var before = DateTime.Now;

            // Act
            var result = sut.GetCurrentTime();

            var after = DateTime.Now;

            // Assert: result should be within [before, after]
            Assert.True(result >= before && result <= after,
                $"Expected {result} to be between {before} and {after}");
        }
    }
}