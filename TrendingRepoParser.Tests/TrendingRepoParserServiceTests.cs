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
        public async Task ReturnsTrendingRepos(TimeRange timeRange)
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

        [Theory]
        [InlineData(TimeRange.TODAY, Language.Go)]
        [InlineData(TimeRange.WEEKLY, Language.CSharp)]
        [InlineData(TimeRange.MONTHLY, Language.JavaScript)]
        public async Task ReturnsTrendingReposOfLanguage(TimeRange timeRange, Language language)
        {
            var trendingPages = await TrendingRepoParserService.ExtractTrendingRepoNames(timeRange, language);

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
