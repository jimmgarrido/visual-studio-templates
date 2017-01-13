using System;
using UIKit;

namespace MasterDetail.iOS
{
    public partial class TabBarController : UITabBarController
    {
        public TabBarController (IntPtr handle) : base (handle)
        {
			TabBar.Items[0].Title = "Browse";
            TabBar.Items[0].Image = UIImage.FromFile("tab_feed.png");

			TabBar.Items[1].Title = "About";
            TabBar.Items[1].Image = UIImage.FromFile("tab_about.png");
        }
    }
}