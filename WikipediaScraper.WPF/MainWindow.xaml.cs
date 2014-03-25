using System;
using System.Net;
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
            string html = String.Empty;
            using (WebClient client = new WebClient())
                html = client.DownloadString("http://en.wikipedia.org/wiki/Main_Page");
            var request = new ScrapeRequest {HTML = html, XPath = "//*[@id=\"mp-dyk\"]/ul"};
            var scraper = new Scraper();
            string result = scraper.Scrape(request);
            WebBrowser.NavigateToString(result);
        }
    }
}
