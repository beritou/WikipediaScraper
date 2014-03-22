using System.Linq;
using HtmlAgilityPack;

namespace WikipediaScraper
{
    public class Scraper    
    {
        public string Scrape(ScrapeRequest scrapeRequest)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(scrapeRequest.HTML);
            string html = htmlDoc.DocumentNode.SelectNodes(scrapeRequest.XPath).First().InnerHtml;
            return html;
        }
    }
}