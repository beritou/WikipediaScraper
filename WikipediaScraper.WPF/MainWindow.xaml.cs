using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace WikipediaScraper.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string html = String.Empty;

        public MainWindow()
        {
            InitializeComponent();
            WebScrapeFromWikipedia();
        }

        private async void WebScrapeFromWikipedia()
        {
            html = await DownloadHTMLFromWikipedia();
            var request = new ScrapeRequest { HTML = html, XPath = "//*[@id=\"mp-dyk\"]/ul" };
            var scraper = new Scraper();
            string result = scraper.Scrape(request);
            WebBrowser.NavigateToString(result);
        }

        async Task<string> DownloadHTMLFromWikipedia()
        {
            var client = new WebClient();
            Task<string> downloadStringTask = client.DownloadStringTaskAsync(new Uri("http://en.wikipedia.org/wiki/Main_Page"));
            string html = await downloadStringTask;
            return html;
        }
    }
}
