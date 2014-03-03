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
using Microsoft.Phone.Tasks;

namespace WestervilleWP8
{
    public partial class POIDetail : PhoneApplicationPage
    {
        POI item = new POI();
        
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
            

            switch (NavigationContext.QueryString["type"])
            {
                case "RecreationItem":
                    RecreationItem ri = (RecreationItem)App.RecreationItems.Find(x => x.Name == NavigationContext.QueryString["poi"]);
                    item = ri;
                    if (ri.Acreage != 0) POIAcreage.Text = "Acreage: " + ri.Acreage.ToString();
                    if (ri.AcquiredYear != 0) POIAcquiredYear.Text = "Year Acquired: " + ri.AcquiredYear.ToString();
                    if (ri.DevelopedYear != 0) POIDevelopedYear.Text = "Year Developed: " + ri.DevelopedYear.ToString();
                    break;
                case "School":
                    School s = (School)App.Schools.Find(x => x.Name == NavigationContext.QueryString["poi"]);
                    item = s;
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



            if (item.StreetAddress != String.Empty) POIStreetAddress.Text = item.StreetAddress;
            if (item.Description != String.Empty) POIDescription.Text = item.Description;
        }

        private void Address_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MapsDirectionsTask mdt = new MapsDirectionsTask();
            mdt.End = new LabeledMapLocation(item.Name, item.Location);
            mdt.Show();
        }
    }
}