using System;
using Android.Content.Res;
using TestApp.AppStatics;
using TestApp.Droid.DeviceHelper;

[assembly: Xamarin.Forms.Dependency(typeof(ScreenSizeDependency))]
namespace TestApp.Droid.DeviceHelper
{
    public class ScreenSizeDependency : IDeviceHelper
    {
        public AppStatics.DeviceHelper GetDevice()
        {
            var metrics = Resources.System.DisplayMetrics;
            AppStatics.DeviceHelper _helper = new AppStatics.DeviceHelper
            {
                ScreenHeight = ConvertPixelsToDp(metrics.HeightPixels),
                ScreenWidth = ConvertPixelsToDp(metrics.WidthPixels)
            };
            return _helper;
        }
        private int ConvertPixelsToDp(int pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.System.DisplayMetrics.Density);
            return dp;
        }
    }
}
