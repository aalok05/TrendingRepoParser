using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace TrendingRepoParser.Tests
{
    public class TrendingRepoParserServiceTests
    {
        [Theory]
        [InlineData(TimeRange.TODAY)]
        [InlineData(TimeRange.WEEKLY)]
        [InlineData(TimeRange.MONTHLY)]
        public async Task ReturnsTrendingPages(TimeRange timeRange)
        {
            var trendingPages = await TrendingRepoParserService.ExtractTrendingRepoNames(timeRange);

            trendingPages.Should().NotBeNull();
            trendingPages.Should().NotBeEmpty();
            foreach (var trendingPage in trendingPages)
            {
                trendingPage.Item1.Should().NotBeNullOrEmpty();
                trendingPage.Item2.Should().NotBeNullOrEmpty();
            }
        }
    }
}
