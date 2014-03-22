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
            {
                client.Headers[HttpRequestHeader.Accept] = "text/html, image/png, image/jpeg, image/gif, */*;q=0.1";
                client.Headers[HttpRequestHeader.UserAgent] ="Mozilla/5.0 (Windows; U; Windows NT 6.1; de; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12";
                html = client.DownloadString("http://en.wikipedia.org/wiki/Main_Page");
            }
            var request = new ScrapeRequest {HTML = html, XPath = "//*[@id=\"mp-dyk\"]/ul"};
            var scraper = new Scraper();
            string result = scraper.Scrape(request);
            WebBrowser.NavigateToString(result);
        }
    }
}
