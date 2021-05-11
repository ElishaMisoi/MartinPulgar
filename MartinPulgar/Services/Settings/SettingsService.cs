using MartinPulgar.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MartinPulgar.Services.Settings
{
    public static class SettingsService
    {
        /// <summary>
        /// Settings enums for easier identity of saved items
        /// </summary>
        public enum Setting
        {
            AppTheme
        }

        /// <summary>
        /// Theme enums for easier identity of saved items
        /// </summary>
        public enum Theme
        {
            LightTheme,
            DarkTheme,
            SystemPreferred
        }

        /// <summary>
        /// Client type enum
        /// </summary>
        public enum ClientType
        {
            Android,
            iOS
        }

        /// <summary>
        /// Method to add setting
        /// </summary>
        /// <param name="preference">Takes in settings enum</param>
        /// <param name="setting">takes in the setting in string</param>
        public static void AddSetting(Setting preference, string setting)
        {
            Preferences.Set(EnumsConverter.ConvertToString(preference), setting);
        }

        /// <summary>
        /// Method to get setting
        /// </summary>
        /// <param name="preference">Takes in settings enum</param>
        /// <returns>Setting string</returns>
        public static string GetSetting(Setting preference)
        {
            bool hasKey = Preferences.ContainsKey(EnumsConverter.ConvertToString(preference));

            if (hasKey)
            {
                return Preferences.Get(EnumsConverter.ConvertToString(preference), null);
            }

            return null;
        }

        /// <summary>
        /// Method to remove setting
        /// </summary>
        /// <param name="preference">Takes in the setting enum</param>
        public static void RemoveSetting(Setting preference)
        {
            Preferences.Remove(EnumsConverter.ConvertToString(preference));
        }

        /// <summary>
        /// Method to clear all settings
        /// </summary>
        public static void ClearSettings()
        {
            Preferences.Clear();
        }

        /// <summary>
        /// Method to get clientType
        /// </summary>
        public static string GetClientType()
        {
            string client = "";

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    client = EnumsConverter.ConvertToString(ClientType.iOS);
                    break;
                case Device.Android:
                    client = EnumsConverter.ConvertToString(ClientType.Android);
                    break;
            }

            return client;
        }
    }
}
