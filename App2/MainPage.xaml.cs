using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            await this.DisplayToastAsync("Link Copied!");
        }
    }
}
