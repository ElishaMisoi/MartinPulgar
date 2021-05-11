using MartinPulgar.Services.Dependency.Interfaces;
using MartinPulgar.Services.Settings;
using MartinPulgar.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MartinPulgar.Styles
{
    public class ThemeHelper
    {
        /// <summary>
        /// Get's and applies the users preferred Theme
        /// </summary>
        public static void GetAppTheme()
        {
            string theme = SettingsService.GetSetting(SettingsService.Setting.AppTheme);

            if (!string.IsNullOrEmpty(theme))
            {
                var appTheme = EnumsConverter.ConvertToEnum<SettingsService.Theme>(theme);

                switch (appTheme)
                {
                    case SettingsService.Theme.LightTheme:
                        ChangeToLightTheme();
                        break;
                    case SettingsService.Theme.DarkTheme:
                        ChangeToDarkTheme();
                        break;
                    case SettingsService.Theme.SystemPreferred:
                        ChangeToSystemPreferredTheme();
                        break;
                    default:
                        ChangeToLightTheme();
                        break;
                }
            }
            else
            {
                ChangeToLightTheme();
            }
        }

        /// <summary>
        /// Changes theme to Light Theme
        /// </summary>
        public static void ChangeToLightTheme()
        {
            Application.Current.Resources = new LightTheme();
            DependencyService.Get<IStatusBar>().ChangeStatusBarColorToWhite();
            SettingsService.AddSetting(SettingsService.Setting.AppTheme, EnumsConverter.ConvertToString(SettingsService.Theme.LightTheme));
        }

        /// <summary>
        /// Changes to Dark Theme
        /// </summary>
        public static void ChangeToDarkTheme()
        {
            Application.Current.Resources = new DarkTheme();
            DependencyService.Get<IStatusBar>().ChangeStatusBarColorToBlack();
            SettingsService.AddSetting(SettingsService.Setting.AppTheme, EnumsConverter.ConvertToString(SettingsService.Theme.DarkTheme));
        }

        /// <summary>
        /// Changes to SystemPreferred Theme
        /// </summary>
        public static void ChangeToSystemPreferredTheme()
        {
            AppTheme appTheme = AppInfo.RequestedTheme;

            if (appTheme == AppTheme.Dark)
            {
                ChangeToDarkTheme();
            }
            else if (appTheme == AppTheme.Light)
            {
                ChangeToLightTheme();
            }
            else
            {
                ChangeToLightTheme();
            }

            SettingsService.AddSetting(SettingsService.Setting.AppTheme, EnumsConverter.ConvertToString(SettingsService.Theme.SystemPreferred));
        }
    }
}
