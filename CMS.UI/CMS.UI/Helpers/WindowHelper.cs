using CMS.Core.Core;
using CMS.UI.Windows.Home;
using System.Windows;
using System.Windows.Controls;

namespace CMS.UI.Helpers
{
    public static class WindowHelper
    {
        public static void WindowSettings(Window window, Label userLabel = null, Label conferenceLabel = null)
        {
            window.WindowState = WindowState.Maximized;
            window.ResizeMode = ResizeMode.CanMinimize;
            if (userLabel != null) userLabel.Content = "User: " + UserCredentials.Username;
            if (conferenceLabel != null)
                conferenceLabel.Content = $"Conference: {UserCredentials.Conference.Title} [{UserCredentials.Conference.ConferenceId}]";
        }

        public static bool CheckOtherWindows()
        {
            if (Application.Current.Windows.Count > 2)
            {
                MessageBox.Show("Close other windows first");
                return false;
            }
            return true;
        }

        public static void Logout(Window window)
        {
            if (CheckOtherWindows())
            {
                UserCredentials.Clear();
                LogIn newLoginWindow = new LogIn();
                newLoginWindow.Show();
                window.Close();
            }
        }
    }
}
