using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WestervilleWP8
{
    public class DiningItem : POI
    {
        public override Grid GetPushpin(string color, System.Windows.Media.SolidColorBrush brush)
        {
            Grid g = new Grid();
            g.DataContext = this;

            return g;
        }
    }
}
