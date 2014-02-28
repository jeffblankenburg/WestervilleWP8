using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WestervilleWP8
{
    public class RecreationItem : POI
    {
        public override Grid GetPushpin(string color, SolidColorBrush brush)
        {
            Grid g = new Grid();
            RowDefinition rd = new RowDefinition { Height = new GridLength(75) };
            ColumnDefinition cd1 = new ColumnDefinition { Width = new GridLength(50) };
            ColumnDefinition cd2 = new ColumnDefinition { Width = new GridLength(100) };
            g.RowDefinitions.Add(rd);
            g.ColumnDefinitions.Add(cd1);
            g.ColumnDefinitions.Add(cd2);
            Image image = new Image();
            image.Name = Name;
            image.Width = 40;
            image.Height = 40;
            g.Tap += Grid_Tap;
            Uri uri = new Uri("Assets/Icons/" + ImageName + "_" + color + ".png", UriKind.Relative);
            ImageSource imageSource = new BitmapImage(uri);
            image.Source = imageSource;
            g.Children.Add(image);

            //Rectangle r = new Rectangle();
            //r.Fill = new SolidColorBrush(Colors.White);
            //Grid.SetColumn(r, 1);
            //g.Children.Add(r);

            TextBlock t = new TextBlock();
            t.Text = Name;
            t.TextWrapping = TextWrapping.Wrap;
            t.VerticalAlignment = VerticalAlignment.Center;
            t.Margin = new Thickness(5);
            t.Foreground = brush;
            t.FontSize = 14;
            Grid.SetColumn(t, 1);
            g.Children.Add(t);
            return g;
        }
    }
}
