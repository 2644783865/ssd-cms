using System.Configuration;
using System.Linq;

namespace CMS.Core.Helpers
{
    public static class AppSettings
    {
        public static string BasicAPIPassword => KeyHasValue("API_PASSWORD") ? GetString("API_PASSWORD") : string.Empty;

        public static string BasicAPIUsername => KeyHasValue("API_USERNAME") ? GetString("API_USERNAME") : string.Empty;

        public static string ApiBaseURL => KeyHasValue("ApiBaseURL") ? GetString("ApiBaseURL") : string.Empty;

        public static string AdminLogin => KeyHasValue("AdminLogin") ? GetString("AdminLogin") : string.Empty;

        public static string AdminPassword => KeyHasValue("AdminPassword") ? GetString("AdminPassword") : string.Empty;

        private static bool KeyHasValue(string key) => ConfigurationManager.AppSettings.AllKeys.Contains(key)
            && ConfigurationManager.AppSettings[key] != string.Empty;

        private static string GetString(string key) => ConfigurationManager.AppSettings[key];
    }
}
