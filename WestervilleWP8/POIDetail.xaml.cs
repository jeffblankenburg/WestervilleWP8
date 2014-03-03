using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WestervilleWP8
{
    public partial class POIDetail : PhoneApplicationPage
    {
        
        
        public POIDetail()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("poi") && NavigationContext.QueryString.ContainsKey("type"))
            {
                LoadPOI(NavigationContext.QueryString["poi"], NavigationContext.QueryString["type"]);
            }
        }

        private void LoadPOI(string name, string type)
        {
            var item = new POI();

            switch (NavigationContext.QueryString["type"])
            {
                case "RecreationItem":
                    item = (RecreationItem)App.RecreationItems.Find(x => x.Name == NavigationContext.QueryString["poi"]);
                    break;
                case "School":
                    item = (School)App.Schools.Find(x => x.Name == NavigationContext.QueryString["poi"]);
                    break;
                case "DiningItem":
                    item = (DiningItem)App.DiningItems.Find(x => x.Name == NavigationContext.QueryString["poi"]);
                    break;
            }

            //DataContext = item;

            POIName.Text = item.Name;

            Uri iconURI = new Uri("Assets/Icons/" + item.IconName + "_color.png", UriKind.Relative);
            ImageSource iconImageSource = new BitmapImage(iconURI);
            POIIcon.Source = iconImageSource;

            Uri imageURI = new Uri(item.ImageName, UriKind.Relative);
            ImageSource imageImageSource = new BitmapImage(imageURI);
            POIImage.Source = imageImageSource;
        }
    }
}