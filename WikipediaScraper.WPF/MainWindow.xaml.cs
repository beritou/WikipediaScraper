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
        public MainWindow()
        {
            InitializeComponent();
            WebBrowser.NavigateToString("Downloading from Wikipedia...");
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainWindow_Loaded;
            WebScrapeFromWikipedia();
        }

        private async void WebScrapeFromWikipedia()
        {
            string html = await DownloadHTMLFromWikipedia();
            var request = new ScrapeRequest { HTML = html, XPath = "//*[@id=\"mp-dyk\"]/ul" };
            var scraper = new Scraper();
            string result = scraper.Scrape(request);
            DisplayResult(result);
        }

        async Task<string> DownloadHTMLFromWikipedia()
        {
            var client = new WebClient();
            Task<string> downloadStringTask = client.DownloadStringTaskAsync(new Uri("http://en.wikipedia.org/wiki/Main_Page"));
            string html = await downloadStringTask;
            return html;
        }

        private void DisplayResult(string result)
        {
            WebBrowser.NavigateToString(result);
        }
    }
}
