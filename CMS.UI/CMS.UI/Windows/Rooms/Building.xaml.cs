using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
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

namespace CMS.UI.Windows.Rooms
{
    /// <summary>
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class ManageBuildingWindow : MetroWindow
    {
        IRoomCore core;
        public ManageBuildingWindow()
        {
            core = new RoomCore();
            InitializeComponent();
            LoadBuildingList();
            HideButtonsOnUnselectedCell();
        }

        async private void LoadBuildingList()
        {
            buildinglist.ClearValue(ItemsControl.ItemsSourceProperty);
            buildinglist.ItemsSource = await core.GetBuildingsAsync();
            
        }

        private void buildinglist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            openRoomManagementWindow();

        }

        private void buildinglist_CurrentCellChanged(object sender, EventArgs e)
        {
           editbuildingbutton.IsEnabled = true;
           deletebuildingbutton.IsEnabled = true;
           manageroomsbutton.IsEnabled = true;
        }

        async private void deletebuildingbutton_Click(object sender, RoutedEventArgs e)
        {
            BuildingDTO buildingtodelete = (BuildingDTO)buildinglist.SelectedItem;
            await core.DeleteBuildingAsync(buildingtodelete.BuildingID);
            LoadBuildingList();
            HideButtonsOnUnselectedCell();
        }

        private void HideButtonsOnUnselectedCell()
        {
            editbuildingbutton.IsEnabled = false;
            deletebuildingbutton.IsEnabled = false;
            manageroomsbutton.IsEnabled = false;
        }

        private void addbuildingbutton_Click(object sender, RoutedEventArgs e)
        {
            AddBuildingWindow newAddBuildingWindow = new AddBuildingWindow();
            newAddBuildingWindow.ShowDialog();
            //this can be improved by tracking user's adding activity
            LoadBuildingList();
            HideButtonsOnUnselectedCell();
        }

        private void openRoomManagementWindow()
        {
            BuildingDTO current = (BuildingDTO)buildinglist.SelectedItem;
            RoomWindow newRoomWindow = new RoomWindow(current.BuildingID);
            newRoomWindow.ShowDialog();
        }

        private void manageroomsbutton_Click(object sender, RoutedEventArgs e)
        {
            openRoomManagementWindow();
        }

        async private void editbuildingbutton_Click(object sender, RoutedEventArgs e)
        {
            BuildingDTO buildingToEdit = (BuildingDTO)buildinglist.SelectedItem;
            int focusID = buildingToEdit.BuildingID;
            EditBuildingWindow newEditBuildingWindow = new EditBuildingWindow(buildingToEdit);
            newEditBuildingWindow.ShowDialog();
            //this can be improved by tracking user's editing activity
            //await needed here explicitly, requires clarification
            // do not lose focus on cell after editing
            buildinglist.ItemsSource = await core.GetBuildingsAsync();
            foreach (BuildingDTO row in this.buildinglist.Items)
            {

                int currentRoomID = row.BuildingID;
                if (currentRoomID.Equals(focusID))
                {
                    buildinglist.CurrentCell = new DataGridCellInfo(row, buildinglist.Columns[0]);
                    buildinglist.SelectedItem = row;
                    break;
                }
            }

        }
    }
}
