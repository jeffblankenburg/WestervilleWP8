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
        SolidColorBrush highlight = new SolidColorBrush(Color.FromArgb(0xFF, 0xd5, 0x73, 0x28));
        SolidColorBrush original = new SolidColorBrush(Color.FromArgb(0x66, 0x00, 0x00, 0x00));
        SolidColorBrush overlaybrush = new SolidColorBrush(Colors.Black);
        string overlaycolor = "black";
        string CurrentLayer = "Education";

        public List<School> Schools = new List<School>();
        public List<RecreationItem> RecreationItems = new List<RecreationItem>();
        public List<DiningItem> DiningItems = new List<DiningItem>();
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            LoadData();
            ShowEducation();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gcw = new GeoCoordinateWatcher();
            gcw.PositionChanged += gcw_PositionChanged;
            gcw.Start();
        }

        private void LoadData()
        {
 	        LoadSchools();
            LoadRecreation();
            LoadDining();
        }

        private void LoadSchools()
        {
            Schools.Clear();
            Schools.Add(new School { Name = "Alcott Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/1"), Location = new GeoCoordinate(40.156598, -82.90424), ImageName="Assets/Schools/ele_alcott.jpg" });
            Schools.Add(new School { Name = "Annehurst Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/2"), Location = new GeoCoordinate(40.125258, -82.9614592), ImageName = "Assets/Schools/ele_annehurst.jpg" });
            Schools.Add(new School { Name = "Cherrington Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/4"), Location = new GeoCoordinate(40.114384, -82.907953), ImageName = "Assets/Schools/ele_cherrington.jpg" });
            Schools.Add(new School { Name = "Emerson Magnet School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/10"), Location = new GeoCoordinate(40.127319, -82.928815), ImageName = "Assets/Schools/ele_emerson.jpg" });
            Schools.Add(new School { Name = "Fouse Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/11"), Location = new GeoCoordinate(40.1697843, -82.9107486), ImageName = "Assets/Schools/ele_fouse.jpg" });
            Schools.Add(new School { Name = "Hanby Magnet", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/14"), Location = new GeoCoordinate(40.124451, -82.930546), ImageName = "Assets/Schools/ele_hanby.jpg" });
            Schools.Add(new School { Name = "Hawthorne Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/16"), Location = new GeoCoordinate(40.079516, -82.9346), ImageName = "Assets/Schools/ele_hawthorne.jpg" });
            Schools.Add(new School { Name = "Huber Ridge Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/17"), Location = new GeoCoordinate(40.0911929, -82.918261), ImageName = "Assets/Schools/ele_huberridge.jpg" });
            Schools.Add(new School { Name = "Mark Twain Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/19"), Location = new GeoCoordinate(40.119239, -82.902072), ImageName = "Assets/Schools/ele_marktwain.jpg" });
            Schools.Add(new School { Name = "McVay Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/20"), Location = new GeoCoordinate(40.1157704, -82.894139), ImageName = "Assets/Schools/ele_mcvay.jpg" });
            Schools.Add(new School { Name = "Pointview Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/21"), Location = new GeoCoordinate(40.1061089, -82.912998), ImageName = "Assets/Schools/ele_pointview.jpg" });
            Schools.Add(new School { Name = "Robert Frost Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/22"), Location = new GeoCoordinate(40.1337055, -82.9015901), ImageName = "Assets/Schools/ele_robertfrost.jpg" });
            Schools.Add(new School { Name = "Whittier Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/23"), Location = new GeoCoordinate(40.122439, -82.924392), ImageName = "Assets/Schools/ele_whittier.jpg" });
            Schools.Add(new School { Name = "Wilder Elementary", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/24"), Location = new GeoCoordinate(40.088535, -82.904195), ImageName = "Assets/Schools/ele_wilder.jpg" });

            Schools.Add(new School { Name = "Blendon Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/25"), Location = new GeoCoordinate(40.119526, -82.922496), ImageName = "Assets/Schools/ms_blendon.jpg" });
            Schools.Add(new School { Name = "Genoa Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/26"), Location = new GeoCoordinate(40.1677173, -82.9123294), ImageName = "Assets/Schools/ms_genoa.jpg" });
            Schools.Add(new School { Name = "Heritage Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/27"), Location = new GeoCoordinate(40.1356107, -82.902453), ImageName = "Assets/Schools/ms_heritage.jpg" });
            Schools.Add(new School { Name = "Walnut Springs Middle School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/28"), Location = new GeoCoordinate(40.122377, -82.900039), ImageName = "Assets/Schools/ms_walnutsprings.jpg" });

            Schools.Add(new School { Name = "Westerville South High School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/31"), Location = new GeoCoordinate(40.119015, -82.923719), ImageName = "Assets/Schools/hs_south.jpg" });
            Schools.Add(new School { Name = "Westerville North High School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/30"), Location = new GeoCoordinate(40.134544, -82.898109), ImageName = "Assets/Schools/hs_north.jpg" });
            Schools.Add(new School { Name = "Westerville Central High School", WebAddress = new Uri("http://www.westerville.k12.oh.us/mobile/Schools/Details/29"), Location = new GeoCoordinate(40.154286, -82.903701), ImageName = "Assets/Schools/hs_central.jpg" });
        }

        private void LoadRecreation()
        {
            RecreationItems.Clear();
            RecreationItems.Add(new RecreationItem { Name = "Alum Creek Park North", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=278"), Location = new GeoCoordinate(40.124775, -82.939911), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Alum Creek Park South", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=276"), Location = new GeoCoordinate(40.1131334, -82.936166), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Brooksedge Bark Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=273"), Location = new GeoCoordinate(40.107341, -82.936598), ImageName = "dog" });
            RecreationItems.Add(new RecreationItem { Name = "Ernest Cherrington Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=272"), Location = new GeoCoordinate(40.116954, -82.936974), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Hanby Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=268"), Location = new GeoCoordinate(40.123428, -82.92665), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Hannah Mayne Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=266"), Location = new GeoCoordinate(40.120614, -82.93224), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Heritage Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=274"), Location = new GeoCoordinate(40.12699, -82.947249), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Highlands Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=384"), Location = new GeoCoordinate(40.117014, -82.90442), ImageName = "swim" });
            RecreationItems.Add(new RecreationItem { Name = "Hoff Woods Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=264"), Location = new GeoCoordinate(40.140221, -82.918625), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Huber Village Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=386"), Location = new GeoCoordinate(40.103959, -82.909613), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Millstone Creek Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=261"), Location = new GeoCoordinate(40.14515, -82.902328), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Olde Town Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=481"), Location = new GeoCoordinate(40.13386, -82.929013), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Paul Metzger Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=387"), Location = new GeoCoordinate(40.129217, -82.960269), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Spring Grove North", WebAddress = new Uri("http://jeffblankenburg.com"), Location = new GeoCoordinate(40.130903, -82.888407), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Towers Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=482"), Location = new GeoCoordinate(40.130739, -82.907344), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Walnut Ridge Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=480"), Location = new GeoCoordinate(40.118634, -82.910954), ImageName = "park" });
            RecreationItems.Add(new RecreationItem { Name = "Westerville Community Center", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=246"), Location = new GeoCoordinate(40.135568, -82.945291), ImageName = "running" });
            RecreationItems.Add(new RecreationItem { Name = "Westerville Sports Complex", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=244"), Location = new GeoCoordinate(40.134049, -82.948682), ImageName = "running" });
            RecreationItems.Add(new RecreationItem { Name = "Astronaut Grove Park", WebAddress = new Uri("http://www.westerville.org/modules/showdocument.aspx?documentid=277"), Location = new GeoCoordinate(40.125877, -82.941279), ImageName = "park" });
        }

        private void LoadDining()
        {
            DiningItems.Clear();
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
            Education_Box.Fill = highlight;
            TheMap.Layers.Remove(layerEducation);
            layerEducation = new MapLayer();

            foreach(School s in Schools)
            {
                MapOverlay overlay = new MapOverlay();
                overlay.Content = s.GetPushpin(overlaycolor, overlaybrush);
                overlay.PositionOrigin = new Point(0.5, 0.5);
                //overlay.PositionOrigin = new Point(0, 0);
                overlay.GeoCoordinate = s.Location;

                layerEducation.Add(overlay);
            }

            TheMap.Layers.Add(layerEducation);
        }

        private void ShowRecreation()
        {
            Recreation_Box.Fill = highlight;
            TheMap.Layers.Remove(layerRecreation);
            layerRecreation = new MapLayer();

            foreach (RecreationItem ri in RecreationItems)
            {
                MapOverlay overlay = new MapOverlay();
                overlay.Content = ri.GetPushpin(overlaycolor, overlaybrush);
                overlay.PositionOrigin = new Point(0.5, 0.5);
                //overlay.PositionOrigin = new Point(0, 0);
                overlay.GeoCoordinate = ri.Location;

                layerRecreation.Add(overlay);
            }

            TheMap.Layers.Add(layerRecreation);
        }

        private void ShowDining()
        {
            Dining_Box.Fill = highlight;
            TheMap.Layers.Remove(layerDining);
            layerDining = new MapLayer();

            foreach (DiningItem di in DiningItems)
            {
                MapOverlay overlay = new MapOverlay();
                overlay.Content = di.GetPushpin(overlaycolor, overlaybrush);
                overlay.PositionOrigin = new Point(0.5, 0.5);
                //overlay.PositionOrigin = new Point(0, 0);
                overlay.GeoCoordinate = di.Location;

                layerDining.Add(overlay);
            }

            TheMap.Layers.Add(layerDining);
        }

        private void School_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image i = sender as Image;
            School s = (School)i.DataContext;
            WebBrowserTask wbt = new WebBrowserTask();
            wbt.Uri = s.WebAddress;
            wbt.Show();
        }

        private void MapMode_Click(object sender, EventArgs e)
        {
            if (TheMap.CartographicMode == MapCartographicMode.Aerial)
            {
                TheMap.CartographicMode = MapCartographicMode.Hybrid;
                overlaycolor = "white";
                overlaybrush = new SolidColorBrush(Colors.White);
            }
            else if (TheMap.CartographicMode == MapCartographicMode.Hybrid)
            {
                TheMap.CartographicMode = MapCartographicMode.Road;
                overlaycolor = "black";
                overlaybrush = new SolidColorBrush(Colors.Black);
            }
            else if (TheMap.CartographicMode == MapCartographicMode.Road)
            {
                TheMap.CartographicMode = MapCartographicMode.Terrain;
                overlaycolor = "black";
                overlaybrush = new SolidColorBrush(Colors.Black);
            }
            else if (TheMap.CartographicMode == MapCartographicMode.Terrain)
            {
                TheMap.CartographicMode = MapCartographicMode.Aerial;
                overlaycolor = "white";
                overlaybrush = new SolidColorBrush(Colors.White);
            }

            ShowLayers();
        }

        private void Menu_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g = sender as Grid;
            CurrentLayer = g.Name;

            ShowLayers();
        }

        private void ShowLayers()
        {
            ResetLayers();

            switch (CurrentLayer)
            {
                case "Education":
                    ShowEducation();
                    break;
                case "Recreation":
                    ShowRecreation();
                    break;
                case "Dining":
                    ShowDining();
                    break;
            }
        }

        private void ResetLayers()
        {
            TheMap.Layers.Clear();
            Education_Box.Fill = original;
            Recreation_Box.Fill = original;
            Dining_Box.Fill = original;
        }
    }
}