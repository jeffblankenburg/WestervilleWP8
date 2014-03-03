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
                
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //LoadData();
            ShowEducation();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gcw = new GeoCoordinateWatcher();
            gcw.PositionChanged += gcw_PositionChanged;
            gcw.Start();
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
            myLocationOverlay.PositionOrigin = new Point(0, 0.5);
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

            foreach(School s in App.Schools)
            {
                MapOverlay overlay = new MapOverlay();
                Grid g = s.GetPushpin(overlaycolor, overlaybrush);
                g.Tap += g_Tap;
                overlay.Content = g;
                overlay.PositionOrigin = new Point(0, 0.5);
                //overlay.PositionOrigin = new Point(0, 0);
                overlay.GeoCoordinate = s.Location;

                layerEducation.Add(overlay);
            }

            TheMap.Layers.Add(layerEducation);
        }

        void g_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g = sender as Grid;
            POI poi = (POI)g.DataContext;
            string type = g.DataContext.GetType().ToString().Replace("WestervilleWP8.", "");
            
            NavigationService.Navigate(new Uri("/POIDetail.xaml?type=" + type + "&poi=" + poi.Name, UriKind.Relative));
        }

        private void ShowRecreation()
        {
            Recreation_Box.Fill = highlight;
            TheMap.Layers.Remove(layerRecreation);
            layerRecreation = new MapLayer();

            foreach (RecreationItem ri in App.RecreationItems)
            {
                MapOverlay overlay = new MapOverlay();
                Grid g = ri.GetPushpin(overlaycolor, overlaybrush);
                g.Tap += g_Tap;
                overlay.Content = g;
                overlay.PositionOrigin = new Point(0, 0.5);
                //overlay.PositionOrigin = new Point(0, 0);
                overlay.GeoCoordinate = ri.Location;

                layerRecreation.Add(overlay);
            }

            TheMap.Layers.Add(layerRecreation);
        }

        private void ShowDining()
        {
            //Dining_Box.Fill = highlight;
            //TheMap.Layers.Remove(layerDining);
            //layerDining = new MapLayer();

            //foreach (DiningItem di in App.DiningItems)
            //{
            //    MapOverlay overlay = new MapOverlay();
            //    Grid g = di.GetPushpin(overlaycolor, overlaybrush);
            //    g.Tap += g_Tap;
            //    overlay.Content = g;
            //    overlay.PositionOrigin = new Point(0, 0.5);
            //    //overlay.PositionOrigin = new Point(0, 0);
            //    overlay.GeoCoordinate = di.Location;

            //    layerDining.Add(overlay);
            //}

            //TheMap.Layers.Add(layerDining);
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
            //Dining_Box.Fill = original;
        }
    }
}