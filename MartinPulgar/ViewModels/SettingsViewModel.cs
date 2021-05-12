using GalaSoft.MvvmLight;
using MartinPulgar.Services.Settings;
using MartinPulgar.Styles;
using MartinPulgar.Utils;
using System.Windows.Input;
using Xamarin.Forms;

namespace MartinPulgar.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// True if LightTheme has been selected
        /// </summary>
        bool _isLightTheme;
        public bool IsLightTheme
        {
            get { return _isLightTheme; }
            set
            {
                _isLightTheme = value;
                RaisePropertyChanged();
                if (IsLightTheme)
                {
                    IsDarkTheme = false;
                    IsSystemPreferredTheme = false;
                }
            }
        }

        /// <summary>
        /// True if DarkTheme has been selected
        /// </summary>
        bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get { return _isDarkTheme; }
            set
            {
                _isDarkTheme = value;
                RaisePropertyChanged();
                if (IsDarkTheme)
                {
                    IsLightTheme = false;
                    IsSystemPreferredTheme = false;
                }
            }
        }

        /// <summary>
        /// True if SystemPreferredTheme has been selected
        /// </summary>
        bool _isSystemPreferredTheme;
        public bool IsSystemPreferredTheme
        {
            get { return _isSystemPreferredTheme; }
            set
            {
                _isSystemPreferredTheme = value;
                RaisePropertyChanged();
                if (IsSystemPreferredTheme)
                {
                    IsLightTheme = false;
                    IsDarkTheme = false;
                }
            }
        }

        public SettingsViewModel()
        {
            GetThemeSetting();
        }

        /// <summary>
        /// Function to get the current Theme preference
        /// </summary>
        void GetThemeSetting()
        {
            string theme = SettingsService.GetSetting(SettingsService.Setting.AppTheme);

            var appTheme = EnumsConverter.ConvertToEnum<SettingsService.Theme>(theme);

            switch (appTheme)
            {
                case SettingsService.Theme.LightTheme:
                    IsLightTheme = true;
                    break;
                case SettingsService.Theme.DarkTheme:
                    IsDarkTheme = true;
                    break;
                case SettingsService.Theme.SystemPreferred:
                    IsSystemPreferredTheme = true;
                    break;
                default:
                    IsSystemPreferredTheme = true;
                    break;
            }
        }

        /// <summary>
        /// Function to change user's Theme in realtime 
        /// when user chooses a  different Theme preference
        /// </summary>
        void ChangeTheme(string theme)
        {
            var appTheme = EnumsConverter.ConvertToEnum<SettingsService.Theme>(theme);

            switch (appTheme)
            {
                case SettingsService.Theme.LightTheme:
                    IsLightTheme = true;
                    ThemeHelper.ChangeToLightTheme();
                    break;
                case SettingsService.Theme.DarkTheme:
                    IsDarkTheme = true;
                    ThemeHelper.ChangeToDarkTheme();
                    break;
                case SettingsService.Theme.SystemPreferred:
                    IsSystemPreferredTheme = true;
                    ThemeHelper.ChangeToSystemPreferredTheme();
                    break;
                default:
                    IsSystemPreferredTheme = true;
                    ThemeHelper.ChangeToSystemPreferredTheme();
                    break;
            }
        }

        /// <summary>
        /// Command to change theme
        /// </summary>
        ICommand _themeChangeCommand = null;

        public ICommand ThemeChangeCommand
        {
            get
            {
                return _themeChangeCommand ?? (_themeChangeCommand =
                                          new Command((object obj) => ChangeTheme((string)obj)));
            }
        }
    }
}
