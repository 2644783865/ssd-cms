using System;
using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using CMS.Core.Interfaces;
using CMS.Core.Core;
using CMS.BE.DTO;

namespace CMS.UI.Windows.Rooms
{
    /// <summary>
    /// Interaction logic for EditBuilding.xaml
    /// </summary>
    public partial class EditBuildingWindow : MetroWindow
    {
        private IRoomCore core;
        private String originalName, originalAddress;
        private BuildingDTO originalAtomic; 
        public EditBuildingWindow(BuildingDTO edited_building)
        {
            originalAtomic = edited_building;
          
            core = new RoomCore();
            InitializeComponent();
            initializeData();
            buildingNameTextBox.Text = originalName;
            addressTextBox.Text = originalAddress;
            updateButton.IsEnabled = false;
        }

        private void buildingNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            checkIfUpdatePossible();
        }

        private void addressTextBox_TextChanges(object sender, TextChangedEventArgs e)
        {

            checkIfUpdatePossible();
        }

        async private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            buildingNameTextBox.Text = buildingNameTextBox.Text.Trim();
            addressTextBox.Text = addressTextBox.Text.Trim();
            BuildingDTO candidateToEdit = new BuildingDTO();
            candidateToEdit.Name = buildingNameTextBox.Text;
            candidateToEdit.Address = addressTextBox.Text;
            candidateToEdit.BuildingID = originalAtomic.BuildingID;
            bool response = await core.EditBuildingAsync(candidateToEdit);
            if (response)
            {
                this.originalAtomic = candidateToEdit;
                initializeData();
                checkIfUpdatePossible();
                MessageBox.Show("Successfully edited!");
                Close();
            }
            else
            {
                MessageBox.Show("Could not edit the room's code!");
            }

        }

        private void checkIfUpdatePossible()
        {
            bool relative_change = (!buildingNameTextBox.Text.Equals(originalName) || !addressTextBox.Text.Equals(originalAddress));
            bool notEmpty = buildingNameTextBox.Text.Length > 0 && addressTextBox.Text.Length > 0;
            updateButton.IsEnabled = relative_change && notEmpty;
           
        }

        private void initializeData()
        {
            originalName = originalAtomic.Name;
            originalAddress = originalAtomic.Address;
        }
    }
}
