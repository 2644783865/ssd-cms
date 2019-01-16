using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CMS.UI.Windows.Session
{
    /// <summary>
    /// Interaction logic for PresentationSpecialSession.xaml
    /// </summary>
    public partial class PresentationSpecialSession : MetroWindow
    {
        private SpecialSessionDTO session;
        private IPresentationCore core;
        private IArticleCore articleCore;
        public PresentationSpecialSession(SpecialSessionDTO session)
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            this.session = session;
            core = new PresentationCore();
            articleCore = new ArticleCore();
            FillSessionBoxes();
            LoadPresentations();
        }

        private void FillSessionBoxes()
        {
            TitleLabel.Content = session.Title;
            BeginLabel.Content = session.BeginDate;
            EndLabel.Content = session.EndDate;
            PlaceLabel.Content = session.RoomCode;
        }

        private async void LoadPresentations()
        {
            PresentationsList.ClearValue(ItemsControl.ItemsSourceProperty);
            PresentationsList.DisplayMemberPath = "Title";
            PresentationsList.SelectedValuePath = "PresentationId";
            PresentationsList.ItemsSource = (await core.GetPresentationsByIdAsync(UserCredentials.Conference.ConferenceId))
                .Where(p => p.SpecialSessionId.HasValue && p.SpecialSessionId.Value == session.SpecialSessionId);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditSession newWindow = new AddEditSession(null, session);
            newWindow.ShowDialog();
        }

        private void PresentationsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DetailsButton_Click(null, null);
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (PresentationsList.SelectedIndex >= 0)
            {
                var presentation = (PresentationDTO)PresentationsList.SelectedItem;
                PresentationDetails newWindow = new PresentationDetails(presentation);
                newWindow.ShowDialog();
            }
            else MessageBox.Show("Select presentation first");
        }

        private async void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (PresentationsList.SelectedIndex >= 0)
            {
                var presentation = (PresentationDTO)PresentationsList.SelectedItem;
                if (await articleCore.RejectArticleAsync(presentation.ArticleId, UserCredentials.Account.AccountId))
                {
                    MessageBox.Show("Presentation and article rejected");
                    LoadPresentations();
                }
                else MessageBox.Show("Something went wrong while rejecting presentation and article");
            }
            else MessageBox.Show("Select presentation first");
        }

        private void MetroWindow_Activated(object sender, EventArgs e)
        {
            LoadPresentations();
        }
    }
}
