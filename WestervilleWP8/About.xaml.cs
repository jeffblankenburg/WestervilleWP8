using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace WestervilleWP8
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
        }

        private void Email_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask ect = new EmailComposeTask();
            ect.To = "westerville@jeffblankenburg.com";
            ect.Subject = "Westerville WP8 Feedback";
            ect.Show();
        }
    }
}