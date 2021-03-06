using Android.OS;
using Android.Views;
using MartinPulgar.Droid.Dependency;
using MartinPulgar.Services.Dependency.Interfaces;
using Plugin.CurrentActivity;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(StatusBar))]
namespace MartinPulgar.Droid.Dependency
{
    public class StatusBar : IStatusBar
    {
        public void ChangeStatusBarColorToBlack()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                    currentWindow.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#121212"));
                    currentWindow.SetTitleColor(Android.Graphics.Color.White);
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Black);
                });
            }
        }

        public void ChangeStatusBarColorToWhite()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                var currentWindow = GetCurrentWindow();
                currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
                currentWindow.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#e0e0e0"));
                currentWindow.SetTitleColor(Android.Graphics.Color.Gray);
                currentWindow.SetStatusBarColor(Android.Graphics.Color.White);
            }
        }

        public void HideStatusBar()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                var currentWindow = GetCurrentWindow();
                currentWindow.DecorView.SystemUiVisibility = StatusBarVisibility.Hidden;
                currentWindow.SetTitleColor(Android.Graphics.Color.Black);
                currentWindow.SetNavigationBarColor(Android.Graphics.Color.Black);
                currentWindow.SetStatusBarColor(Android.Graphics.Color.Black);
            }
        }

        Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;

            // clear FLAG_TRANSLUCENT_STATUS flag:
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            // add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }
    }
}