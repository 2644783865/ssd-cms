using MahApps.Metro.Controls;
using System.Windows;
using CMS.Core.Interfaces;
using CMS.Core.Core;
using CMS.BE.DTO;
using CMS.UI.Helpers;

namespace CMS.UI.Windows.Rooms
{
    /// <summary>
    /// Interaction logic for AddBuilding.xaml
    /// </summary>
    public partial class AddBuildingWindow : MetroWindow
    {
        private IRoomCore core;
        private string defaultInputName;
        private string defaultInputAddress;
        public AddBuildingWindow()
        {
            core = new RoomCore();
            InitializeComponent();
            defaultInputName = inputname.Text;
            defaultInputAddress = inputaddress.Text;
        }

        async private void addbuildingbutton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
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
            else MessageBox.Show("Form invalid");
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(inputname.Text.Length > 0, inputname) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(inputaddress.Text.Length > 0, inputaddress) ? false : result;
            return result;
        }

        private void Inputname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (inputname.Text.Equals(defaultInputName))
            {
                inputname.Text = "";
            }
        }

        private void Inputaddress_GotFocus(object sender, RoutedEventArgs e)
        {
            if (inputaddress.Text.Equals(defaultInputAddress))
            {
                inputaddress.Text = "";
            }
        }
    }
}
