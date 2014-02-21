using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WestervilleWP8.Resources;
using Windows.Devices.Geolocation;
using System.Device.Location;
using System.Windows.Shapes;
using System.Windows.Media;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;

namespace WestervilleWP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        GeoCoordinateWatcher gcw;
        MapLayer layerLocation = new MapLayer();
        MapLayer layerRecreation = new MapLayer();
        MapLayer layerMunicipal = new MapLayer();
        MapLayer layerEntertainment = new MapLayer();
        MapLayer layerDining = new MapLayer();
        MapLayer layerEducation = new MapLayer();

        public List<School> Schools = new List<School>();
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LoadData();
            gcw = new GeoCoordinateWatcher();
            gcw.PositionChanged += gcw_PositionChanged;
            gcw.Start();
            ShowEducation();
        }

        private void LoadData()
        {
 	        LoadSchools();
        }

        private void LoadSchools()
        {
            Schools.Clear();
            Schools.Add(new School { Name = "Alcott Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=1"), Location = new GeoCoordinate(40.156598, -82.90424), ImageName="Assets/Schools/ele_alcott.jpg" });
            Schools.Add(new School { Name = "Annehurst Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=2"), Location = new GeoCoordinate(40.125258, -82.9614592), ImageName = "Assets/Schools/ele_annehurst.jpg" });
            Schools.Add(new School { Name = "Cherrington Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=4"), Location = new GeoCoordinate(40.114384, -82.907953), ImageName = "Assets/Schools/ele_cherrington.jpg" });
            Schools.Add(new School { Name = "Emerson Magnet School", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=10"), Location = new GeoCoordinate(40.127319, -82.928815), ImageName = "Assets/Schools/ele_emerson.jpg" });
            Schools.Add(new School { Name = "Fouse Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=11"), Location = new GeoCoordinate(40.1697843, -82.9107486), ImageName = "Assets/Schools/ele_fouse.jpg" });
            Schools.Add(new School { Name = "Hanby Magnet", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=14"), Location = new GeoCoordinate(40.124451, -82.930546), ImageName = "Assets/Schools/ele_hanby.jpg" });
            Schools.Add(new School { Name = "Hawthorne Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=16"), Location = new GeoCoordinate(40.1201858, -83.0468496), ImageName = "Assets/Schools/ele_hawthorne.jpg" });
            Schools.Add(new School { Name = "Huber Ridge Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=17"), Location = new GeoCoordinate(40.0911929, -82.918261), ImageName = "Assets/Schools/ele_huberridge.jpg" });
            Schools.Add(new School { Name = "Mark Twain Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=19"), Location = new GeoCoordinate(40.119239, -82.902072), ImageName = "Assets/Schools/ele_marktwain.jpg" });
            Schools.Add(new School { Name = "McVay Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=20"), Location = new GeoCoordinate(40.1157704, -82.894139), ImageName = "Assets/Schools/ele_mcvay.jpg" });
            Schools.Add(new School { Name = "Pointview Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=21"), Location = new GeoCoordinate(40.1061089, -82.912998), ImageName = "Assets/Schools/ele_pointview.jpg" });
            Schools.Add(new School { Name = "Robert Frost Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=22"), Location = new GeoCoordinate(40.1337055, -82.9015901), ImageName = "Assets/Schools/ele_robertfrost.jpg" });
            Schools.Add(new School { Name = "Whittier Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=23"), Location = new GeoCoordinate(40.122439, -82.924392), ImageName = "Assets/Schools/ele_whittier.jpg" });
            Schools.Add(new School { Name = "Wilder Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=24"), Location = new GeoCoordinate(40.088535, -82.904195), ImageName = "Assets/Schools/ele_wilder.jpg" });

            Schools.Add(new School { Name = "Blendon Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=25"), Location = new GeoCoordinate(40.119526, -82.922496), ImageName = "Assets/Schools/ms_blendon.jpg" });
            Schools.Add(new School { Name = "Genoa Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=26"), Location = new GeoCoordinate(40.1677173, -82.9123294), ImageName = "Assets/Schools/ms_genoa.jpg" });
            Schools.Add(new School { Name = "Heritage Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=27"), Location = new GeoCoordinate(40.1356107, -82.902453), ImageName = "Assets/Schools/ms_heritage.jpg" });
            Schools.Add(new School { Name = "Walnut Springs Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=28"), Location = new GeoCoordinate(40.122377, -82.900039), ImageName = "Assets/Schools/ms_walnutsprings.jpg" });

            Schools.Add(new School { Name = "Westerville South High School", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=31"), Location = new GeoCoordinate(40.119015, -82.923719), ImageName = "Assets/Schools/hs_south.jpg" });
            Schools.Add(new School { Name = "Westerville North High School", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=30"), Location = new GeoCoordinate(40.134544, -82.898109), ImageName = "Assets/Schools/hs_north.jpg" });
            Schools.Add(new School { Name = "Westerville Central High School", WebAddress = new Uri("http://www.westerville.k12.oh.us/school_home.aspx?schoolID=29"), Location = new GeoCoordinate(40.154286, -82.903701), ImageName = "Assets/Schools/hs_central.jpg" });
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            gcw.PositionChanged -= gcw_PositionChanged;
        }

        void gcw_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            ShowLocation(e.Position.Location);
            //TheMap.Center = e.Position.Location;
        }

        private void ShowLocation(GeoCoordinate geoCoordinate)
        {
            Ellipse dot = new Ellipse();
            dot.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xD5, 0x73, 0x28));
            dot.Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x07, 0x2e, 0x2b));
            dot.StrokeThickness = 2;
            dot.Height = 20;
            dot.Width = 20;
            dot.Opacity = 50;

            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = dot;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = geoCoordinate;

            layerLocation = new MapLayer();
            layerLocation.Add(myLocationOverlay);

            TheMap.Layers.Add(layerLocation);
        }

        private void ShowEducation()
        {
            TheMap.Layers.Remove(layerEducation);
            layerEducation = new MapLayer();

            foreach(School s in Schools)
            {
                MapOverlay overlay = new MapOverlay();
                overlay.Content = BuildImage(s);
                overlay.PositionOrigin = new Point(0.5, 0.5);
                overlay.GeoCoordinate = s.Location;

                layerEducation.Add(overlay);
            }

            TheMap.Layers.Add(layerEducation);
        }

        private Image BuildImage(School school)
        {
            Image image = new Image();
            image.Name = school.Name;
            image.Width = 90;
            image.Height = 50;
            image.Tap += School_Tap;
            image.DataContext = school;
            Uri uri = new Uri(school.ImageName, UriKind.Relative);
            ImageSource imageSource = new BitmapImage(uri);
            image.Source = imageSource;
            return image;
        }

        private void School_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image i = sender as Image;
            School s = (School)i.DataContext;
            WebBrowserTask wbt = new WebBrowserTask();
            wbt.Uri = s.WebAddress;
            wbt.Show();
        }


        
        
        
    }
}