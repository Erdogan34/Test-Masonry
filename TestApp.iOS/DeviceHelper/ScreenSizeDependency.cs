using System;
using TestApp.AppStatics;
using TestApp.iOS.DeviceHelper;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ScreenSizeDependency))]
namespace TestApp.iOS.DeviceHelper
{
    public class ScreenSizeDependency : IDeviceHelper
    {
        public AppStatics.DeviceHelper GetDevice()
        {
            AppStatics.DeviceHelper _helper = new AppStatics.DeviceHelper
            {
                ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height,
                ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width
            };
            return _helper;
        }
    }
}
