using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CMS.UI.Windows.Award
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class ManageAwards : MetroWindow
    {
        private ISessionCore sessionCore;
        private IPresentationCore presentationCore;
        private IAwardCore core;

        public ManageAwards()
        {
            InitializeComponent();
            sessionCore = new SessionCore();
            presentationCore = new PresentationCore();
            core = new AwardCore();
            InitializeData();
        }

        private void InitializeData()
        {
            FillSessionTypeBoxes();
            LoadSessions();
        }

        private void FillSessionTypeBoxes()
        {
            SessionComboBox.Items.Add("Session");
            SessionComboBox.Items.Add("SpecialSession");
            SessionComboBox.SelectedIndex = 0;
        }

        private async void LoadSessions()
        {
            SessionList.ClearValue(ItemsControl.ItemsSourceProperty);
            if (SessionComboBox.SelectedIndex == 0)
            {
                SessionList.DisplayMemberPath = "SessionDesc";
                SessionList.SelectedValuePath = "SessionId";
                SessionList.ItemsSource = await sessionCore.GetSessionsAsync(UserCredentials.Conference.ConferenceId);
            }
            else
            {
                SessionList.DisplayMemberPath = "SpecialSessionDesc";
                SessionList.SelectedValuePath = "SpecialSessionId";
                SessionList.ItemsSource = await sessionCore.GetSpecialSessionsAsync(UserCredentials.Conference.ConferenceId);
            }
        }

        private async void LoadPresentations()
        {
            PresentationList.ClearValue(ItemsControl.ItemsSourceProperty);
            PresentationList.DisplayMemberPath = "PresentationDesc";
            PresentationList.SelectedValuePath = "PresentationId";
            if (SessionList.SelectedIndex >= 0)
            {
                if (SessionComboBox.SelectedIndex != 0)
                {
                    PresentationList.ItemsSource = (await presentationCore.GetPresentationsByIdAsync(UserCredentials.Conference.ConferenceId))
                        .Where(s => s.SpecialSessionId.HasValue
                        && s.SpecialSessionId.Value == (int)SessionList.SelectedValue);
                    var award = await core.GetAwardForSessionAsync(null, (int)SessionList.SelectedValue);
                    if (award != null) PresentationList.SelectedValue = award.PresentationId;
                    else PresentationList.SelectedIndex = -1;
                }
                else
                {
                    PresentationList.ItemsSource = (await presentationCore.GetPresentationsByIdAsync(UserCredentials.Conference.ConferenceId))
                        .Where(s => s.SessionId.HasValue
                        && s.SessionId.Value == (int)SessionList.SelectedValue);
                    var award = await core.GetAwardForSessionAsync((int)SessionList.SelectedValue, null);
                    if (award != null) PresentationList.SelectedValue = award.PresentationId;
                    else PresentationList.SelectedIndex = -1;
                }
            }
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            PresentationList.SelectedIndex = -1;
        }

        private void SessionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadPresentations();
        }

        private async void PresentationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SessionList.SelectedValue != null)
            {
                AwardDTO award = null;
                if (SessionComboBox.SelectedIndex != 0)
                {
                    award = await core.GetAwardForSessionAsync(null, (int)SessionList.SelectedValue);
                }
                else
                {
                    award = await core.GetAwardForSessionAsync((int)SessionList.SelectedValue, null);
                }

                if (award != null)
                {
                    if (PresentationList.SelectedIndex < 0)
                    {
                        await core.DeleteAwardAsync(award.AwardId);
                    }
                    else if ((int)PresentationList.SelectedValue != award.PresentationId)
                    {
                        award.PresentationId = (int)PresentationList.SelectedValue;
                        await core.EditAwardAsync(award);
                    }
                }
                else
                {
                    if (PresentationList.SelectedIndex >= 0)
                    {
                        await core.AddAwardAsync(new AwardDTO()
                        {
                            Date = DateTime.Now,
                            PresentationId = (int)PresentationList.SelectedValue
                        });
                    }
                }
            }
        }


        private void SessionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadSessions();
        }
    }
}
