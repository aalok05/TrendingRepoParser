using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrendingRepoParser
{
    public class TrendingRepoParserService
    {
        /// <summary>
        /// Gets Trending repositories in a time range
        /// </summary>
        /// <param name="range">TimeRange enum</param>
        /// <returns>List of Tuple of owner name and repository name of the trending repositories</returns>
        public async static Task<List<Tuple<string, string>>> ExtractTrendingRepoNames(TimeRange range)
        {
            string url = "";

            List<Tuple<string, string>> repoNames = new List<Tuple<string, string>>();

            if (range == TimeRange.TODAY)
            {
                url = "https://github.com/trending?since=daily";
            }
            if (range == TimeRange.WEEKLY)
            {
                url = "https://github.com/trending?since=weekly";
            }
            if (range == TimeRange.MONTHLY)
            {
                url = "https://github.com/trending?since=monthly";
            }

            //
            // The following code loads the HTML page and looks for specific tags so that we get what we want.
            // This code will have to be changed as and when the Github Trending page changes its HTML.
            // We will have to revise the logic as per the new page structure.
            //

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = await web.LoadFromWebAsync(url);
            var h3 = doc.DocumentNode.Descendants("h3");

            foreach (var i in h3)
            {
                var s = i.Descendants("a").First();
                var names = s.Attributes["href"].Value.Split('/');
                repoNames.Add(new Tuple<string, string>(names[1], names[2]));
            }
            return repoNames;
        }

        public async static Task<List<Tuple<string, string>>> ExtractTrendingRepoNames(TimeRange range, Language language)
        {
            string url = "";

            List<Tuple<string, string>> repoNames = new List<Tuple<string, string>>();

            if (range == TimeRange.TODAY)
            {
                url = "https://github.com/trending/" + language.ToString() + "?since=daily";
            }
            if (range == TimeRange.WEEKLY)
            {
                url = "https://github.com/trending/" + language.ToString() + "?since=weekly";
            }
            if (range == TimeRange.MONTHLY)
            {
                url = "https://github.com/trending/"+ language.ToString() +"?since=monthly";
            }

            //
            // The following code loads the HTML page and looks for specific tags so that we get what we want.
            // This code will have to be changed as and when the Github Trending page changes its HTML.
            // We will have to revise the logic as per the new page structure.
            //

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = await web.LoadFromWebAsync(url);
            var h3 = doc.DocumentNode.Descendants("h3");

            foreach (var i in h3)
            {
                var s = i.Descendants("a").First();
                var names = s.Attributes["href"].Value.Split('/');
                repoNames.Add(new Tuple<string, string>(names[1], names[2]));
            }
            return repoNames;
        }
    }
}
