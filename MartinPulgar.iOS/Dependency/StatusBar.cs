using MartinPulgar.iOS.Dependency;
using MartinPulgar.Services.Dependency.Interfaces;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(StatusBar))]
namespace MartinPulgar.iOS.Dependency
{
    public class StatusBar : IStatusBar
    {
        public void ChangeStatusBarColorToBlack()
        {
            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.Default;
        }

        public void ChangeStatusBarColorToWhite()
        {
            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
        }

        public void HideStatusBar()
        {
            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackTranslucent;
        }
    }
}