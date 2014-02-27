using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WestervilleWP8
{
    public class POI
    {
        public string Name { get; set; }
        public GeoCoordinate Location { get; set; }
        public Uri WebAddress { get; set; }
        public string ImageName { get; set; }

        public virtual Grid GetPushpin()
        {
            return new Grid();
        }

        public void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask wbt = new WebBrowserTask();
            wbt.Uri = WebAddress;
            wbt.Show();
        }
    }
}
