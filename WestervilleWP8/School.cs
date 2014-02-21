using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestervilleWP8
{
    public class School
    {
        public string Name { get; set; }
        public GeoCoordinate Location { get; set; }
        public Uri WebAddress { get; set; }
        public string ImageName { get; set; }
    }
}
