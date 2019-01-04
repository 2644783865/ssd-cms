using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Windows.Articles;
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

namespace CMS.UI.Windows.Session
{
    /// <summary>
    /// Interaction logic for MySessions.xaml
    /// </summary>
    public partial class MySessions : MetroWindow
    {
        private ISessionCore core;
        private IArticleCore articleCore;
        private IPresentationCore presentationCore;
        public MySessions()
        {
            InitializeComponent();
            core = new SessionCore();
            articleCore = new ArticleCore();
            presentationCore = new PresentationCore();
            InitializeGradeBox();
            LoadSessions();
        }

        private void InitializeGradeBox()
        {
            GradeBox.Items.Add("");
            for (int i = 0; i < 10; i++)
            {
                GradeBox.Items.Add(i);
            }
        }

        private async void LoadSessions()
        {
            SessionsBox.ClearValue(ItemsControl.ItemsSourceProperty);
            if (!SpecialCheck.IsChecked.Value)
            {
                SessionsBox.DisplayMemberPath = "SessionDesc";
                SessionsBox.SelectedValuePath = "SessionId";
                SessionsBox.ItemsSource = (await core.GetSessionsAsync(UserCredentials.Conference.ConferenceId))
                    .Where(s => s.ChairId == UserCredentials.Account.AccountId);
            }
            else
            {
                SessionsBox.DisplayMemberPath = "SpecialSessionDesc";
                SessionsBox.SelectedValuePath = "SpecialSessionId";
                SessionsBox.ItemsSource = (await core.GetSpecialSessionsAsync(UserCredentials.Conference.ConferenceId))
                    .Where(s => s.ChairId == UserCredentials.Account.AccountId);
            }
        }

        private async void LoadArticles()
        {
            ArticlesList.ClearValue(ItemsControl.ItemsSourceProperty);
            if (SessionsBox.SelectedIndex >= 0 && SpecialCheck.IsChecked.Value)
            {
                ArticlesList.DisplayMemberPath = "Topic";
                ArticlesList.SelectedValuePath = "ArticleId";
                ArticlesList.ItemsSource = (await articleCore.GetArticlesAsync(UserCredentials.Conference.ConferenceId))
                    .Where(s => s.SpecialSessionId.HasValue
                    && s.SpecialSessionId.Value == ((SpecialSessionDTO)SessionsBox.SelectedItem).SpecialSessionId);
            }
        }

        private async void LoadPresentations()
        {
            PresentationsGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            if (SessionsBox.SelectedIndex >= 0)
            {
                if (SpecialCheck.IsChecked.Value)
                {
                    PresentationsGrid.ItemsSource = (await presentationCore.GetPresentationsByIdAsync(UserCredentials.Conference.ConferenceId))
                        .Where(s => s.SpecialSessionId.HasValue
                        && s.SpecialSessionId.Value == ((SpecialSessionDTO)SessionsBox.SelectedItem).SpecialSessionId);
                }
                else
                {
                    PresentationsGrid.ItemsSource = (await presentationCore.GetPresentationsByIdAsync(UserCredentials.Conference.ConferenceId))
                        .Where(s => s.SessionId.HasValue
                        && s.SessionId.Value == ((SessionDTO)SessionsBox.SelectedItem).SessionId);
                }
            }
        }

        private void ListOfPresentersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SessionDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialCheck.IsChecked.Value)
            {
                var specialSession = (SpecialSessionDTO)SessionsBox.SelectedItem;
                //SessionDetails newWindow = new SessionDetails(null, specialSession);
                //newWindow.ShowDialog();
            }
            else
            {
                var session = (SessionDTO)SessionsBox.SelectedItem;
                //SessionDetails newWindow = new SessionDetails(session, null);
                //newWindow.ShowDialog();
            }
        }

        private void SpecialCheck_Checked(object sender, RoutedEventArgs e)
        {
            LoadSessions();
        }

        private void SessionsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadPresentations();
            LoadArticles();
        }

        private void ArticlesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var article = (ArticleDTO)ArticlesList.SelectedItem;
            ArticleDetails newWindow = new ArticleDetails(article);
            newWindow.ShowDialog();
        }

        private void PresentationsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var presentation = (PresentationDTO)PresentationsGrid.SelectedItem;
            //PresentationDetails newWindow = new PresentationDetails(presentation);
            //newWindow.ShowDialog();
        }

        private void PresentationsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PresentationsGrid.SelectedIndex >= 0)
            {
                var presentation = (PresentationDTO)PresentationsGrid.SelectedItem;
                if (presentation.Grade.HasValue) GradeBox.SelectedIndex = (int)presentation.Grade.Value+1;
                else GradeBox.SelectedIndex = -1;
            }
            else GradeBox.SelectedIndex = -1;
        }

        private async void GradeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GradeBox.SelectedIndex >= 0 && PresentationsGrid.SelectedIndex >= 0)
            {
                var presentation = (PresentationDTO)PresentationsGrid.SelectedItem;
                if (!presentation.Grade.HasValue || GradeBox.SelectedIndex == 0 
                    || presentation.Grade.Value != int.Parse(GradeBox.SelectedItem.ToString()))
                {
                    presentation.Grade = null;
                    if (GradeBox.SelectedIndex != 0) presentation.Grade = int.Parse(GradeBox.SelectedItem.ToString());
                    await presentationCore.EditPresentationAsync(presentation);
                    LoadPresentations();
                }
            }
        }
    }
}
