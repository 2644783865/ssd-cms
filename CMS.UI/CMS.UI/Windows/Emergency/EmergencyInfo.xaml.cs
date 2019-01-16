using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Windows;
using System.Threading.Tasks;

namespace CMS.UI.Windows.Emergency
{
    /// <summary>
    /// Interaction logic for EmergencyInfo.xaml
    /// </summary>
    public partial class EmergencyInfo : MetroWindow
    {
        private EmergencyInfoDTO currentEmergency;

        public EmergencyInfo()
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            LoadData();
        }
 
        private async void LoadData()
        {
            await LoadEmergency();
        }

        private async Task LoadEmergency()
        {
            IEmergencyInfoCore emergencyCore = new EmergencyInfoCore();
            currentEmergency = await emergencyCore.GetEmergencyInfoByConferenceIdAsync(UserCredentials.Conference.ConferenceId);
            if (currentEmergency != null)
            {
                EmergencyNumBox.Text = currentEmergency.EmergencyNum;
                EmergencyInfoBox.Text = currentEmergency.EmergencyInfo1;
                this.Title = "Edit Emergency Info";
                SaveButton.Content = "Save";
            }
            else
            {
                this.Title = "Add Emergency Info";
                SaveButton.Content = "Add";
            }
        }

        private async void Button_Save(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (ValidateForm()) using (IEmergencyInfoCore core = new EmergencyInfoCore())
                {
                    bool result = false;

                    if (currentEmergency == null)
                    {
                        var emergencyModel = new EmergencyInfoDTO()
                        {
                            EmergencyNum = EmergencyNumBox.Text,
                            EmergencyInfo1 = EmergencyInfoBox.Text,
                            ConferenceId = UserCredentials.Conference.ConferenceId
                        };
                        result = await core.AddEmergencyInfoAsync(emergencyModel);
                    }
                    else
                    {
                        currentEmergency.EmergencyNum= EmergencyNumBox.Text;
                        currentEmergency.EmergencyInfo1= EmergencyInfoBox.Text;
                        
                        result = await core.EditEmergencyInfoAsync(currentEmergency);
                    }

                    if (result)
                    {
                        MessageBox.Show("Success");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Failure");
                    }
                }
            else MessageBox.Show("Form invalid");
            ProgressSpin.IsActive = false;

        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(EmergencyNumBox.Text.Length > 0, EmergencyNumBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(EmergencyInfoBox.Text.Length > 0, EmergencyInfoBox) ? false : result;
            return result;
        }

        private async void Button_Delete(object sender, RoutedEventArgs e)
        {
            IEmergencyInfoCore emergencyCore = new EmergencyInfoCore();
            currentEmergency = await emergencyCore.GetEmergencyInfoByConferenceIdAsync(UserCredentials.Conference.ConferenceId);
            if (currentEmergency != null)
            {
                var result = await emergencyCore.DeleteEmergencyInfoAsync(currentEmergency.EmergencyInfoId);
                if (result)
                {
                    MessageBox.Show("Successfully deleted emergency");
                    Close();
                }
                else MessageBox.Show("Error occured while deleting emergency");
            }
            else MessageBox.Show("There is nothing to delete");
        }
    }
}

