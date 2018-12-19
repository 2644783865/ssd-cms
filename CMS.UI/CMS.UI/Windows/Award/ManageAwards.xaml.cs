using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


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
