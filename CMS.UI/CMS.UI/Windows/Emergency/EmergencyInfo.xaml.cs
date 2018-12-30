using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Windows;


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
            //currentEmergency = 
            //if (emergency != null) InitializeEditFields();
            this.Title = "Add Emergency Info";

        }

        private void InitializeEditFields()
        {
            currentEmergency.EmergencyNum= EmergencyNumBox.Text;
            currentEmergency.EmergencyInfo1= EmergencyInfoBox.Text;
            this.Title = "Edit Emergency Info";

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
    }
}

