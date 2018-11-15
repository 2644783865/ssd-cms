using System;
using System.Configuration;
using System.Linq;

namespace CMS.API.BLL.Helpers
{
    public class AppSettings
    {
        public static string DefaultPassword
        {
            get { return KeyHasValue("DefaultPassword") ? GetString("DefaultPassword") : String.Empty; }
        }

        private static bool KeyHasValue(string key) => ConfigurationManager.AppSettings.AllKeys.Contains(key)
            && ConfigurationManager.AppSettings[key] != string.Empty;

        private static string GetString(string key) => ConfigurationManager.AppSettings[key];
    }
}
