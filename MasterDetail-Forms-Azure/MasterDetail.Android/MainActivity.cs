﻿
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace MasterDetail.Droid
{
	[Activity(Label = "MasterDetail.Droid", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            Microsoft.Identity.Client.AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(
              requestCode, resultCode, data);
        }
    }
}
