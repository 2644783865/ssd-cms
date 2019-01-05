using MahApps.Metro.Controls;
using System.Windows;
using CMS.Core.Interfaces;
using CMS.Core.Core;
using CMS.BE.DTO;

namespace CMS.UI.Windows.Rooms
{
    /// <summary>
    /// Interaction logic for AddBuilding.xaml
    /// </summary>
    public partial class AddBuildingWindow : MetroWindow
    {
        private IRoomCore core;
        public AddBuildingWindow()
        {
            core = new RoomCore();
            InitializeComponent();
        }

        async private void addbuildingbutton_Click(object sender, RoutedEventArgs e)
        {
            BuildingDTO candidate_building = new BuildingDTO();
            candidate_building.Name = inputname.Text;
            candidate_building.Address = inputaddress.Text;
            bool response = await core.AddBuildingAsync(candidate_building);
            if (response)
            {
                MessageBox.Show("Successfully added!");
                Close();
            }
            else
            {
                MessageBox.Show("Could not add the building!");
            }

        }
    }
}
