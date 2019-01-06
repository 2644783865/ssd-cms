using System;
using System.Configuration;
using System.Linq;

namespace CMS.API.Helpers
{
    public class AppSettings
    {
        public static string BasicAPIPassword => KeyHasValue("API_PASSWORD") ? GetString("API_PASSWORD") : String.Empty;

        public static string BasicAPIUsername => KeyHasValue("API_USERNAME") ? GetString("API_USERNAME") : String.Empty;

        private static bool KeyHasValue(string key) => ConfigurationManager.AppSettings.AllKeys.Contains(key)
            && ConfigurationManager.AppSettings[key] != string.Empty;

        private static string GetString(string key) => ConfigurationManager.AppSettings[key];
    }
}