using System.Windows;

namespace CMS.UI.Helpers
{
    public static class WindowHelper
    {
        public static void WindowSettings(Window window)
        {
            window.WindowState = WindowState.Maximized;
            window.ResizeMode = ResizeMode.CanMinimize;
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
    }
}
