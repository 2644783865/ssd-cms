using MahApps.Metro.Controls;
using System.Windows;


namespace CMS.UI.Windows.Award
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class ManageAwards : MetroWindow
    {
        public ManageAwards()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            FillSessionTypeBoxes();
        }

        private void FillSessionTypeBoxes()
        {
            SessionComboBox.Items.Add("Session");
            SessionComboBox.Items.Add("SpecialSession");
            SessionComboBox.SelectedIndex = 0;
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            PresentationDataGrid.SelectedIndex = -1;
        }
    }
}
