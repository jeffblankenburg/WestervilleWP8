using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml.Linq;
using Microsoft.Phone.Tasks;

namespace WestervilleWP8
{
    public partial class Calendar : PhoneApplicationPage
    {
        WebClient calendarfeed = new WebClient();
        
        public Calendar()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            calendarfeed.DownloadStringCompleted += calendarfeed_DownloadStringCompleted;
            calendarfeed.DownloadStringAsync(new Uri("http://westerville.org/Rss.aspx?type=4&paramtime=Future"));
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            calendarfeed.DownloadStringCompleted -= calendarfeed_DownloadStringCompleted;
        }

        void calendarfeed_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            XElement xmlEvents = XElement.Parse(e.Result);
            List<CalendarItem> CalendarItems = (from c in xmlEvents.Descendants("item")
                                       select new CalendarItem
                                       {
                                           Name = c.Element("title").Value,
                                           Uri = c.Element("link").Value,
                                           Date = DateTime.Parse(c.Element("pubDate").Value)
                                       }).ToList<CalendarItem>();

            CalendarList.ItemsSource = CalendarItems;
        }

        private void Calendar_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StackPanel g = sender as StackPanel;
            CalendarItem ci = g.DataContext as CalendarItem;
            WebBrowserTask wbt = new WebBrowserTask();
            wbt.Uri = new Uri(ci.Uri);
            wbt.Show();
        }
    }
}