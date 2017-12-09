# TrendingRepoParser
[![NuGet](https://img.shields.io/nuget/dt/TrendingRepoParser.svg)](https://www.nuget.org/packages/TrendingRepoParser)

A .NET Standard library that parses owner and repository name from GitHub Trending page.

<a href="https://www.nuget.org/packages/TrendingRepoParser/"><img src="http://i.pi.gy/r8Wr.png" alt="Get it from NuGet" width='280' /></a>

# Usage
You can get Today, Weekly and Monthly trending repositories.
```csharp
public enum TimeRange
{
    TODAY, WEEKLY, MONTHLY
}
```
Just pass the `TimeRange` enum to `ExtractTrendingRepoNames` method
```csharp
await TrendingRepoParserService.ExtractTrendingRepoNames(TrendingRepoParserService.TimeRange.TODAY);
```
# Dependencies
* [HTML Agility Pack](https://www.nuget.org/packages/HtmlAgilityPack)
