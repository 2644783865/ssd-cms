using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Windows.Articles;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private IConferenceCore confCore;
        public MySessions()
        {
            InitializeComponent();
            core = new SessionCore();
            articleCore = new ArticleCore();
            presentationCore = new PresentationCore();
            confCore = new ConferenceCore();
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

        private async void ListOfPresentersButton_Click(object sender, RoutedEventArgs e)
        {
            if (SessionsBox.SelectedIndex >= 0)
            {
                ListOfPresentersButton.IsEnabled = false;
                try
                {
                    byte[] document = null;
                    if (SpecialCheck.IsChecked.Value) document = await core.GetPresentersListAsync(null,((SpecialSessionDTO)SessionsBox.SelectedItem).SpecialSessionId);
                    else document = await core.GetPresentersListAsync(((SessionDTO)SessionsBox.SelectedItem).SessionId, null);
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        AddExtension = true,
                        Filter = "pdf files (*.pdf)|*.pdf",
                        FileName = $"List of presenters for {(SpecialCheck.IsChecked.Value ? ((SpecialSessionDTO)SessionsBox.SelectedItem).Title : ((SessionDTO)SessionsBox.SelectedItem).Title)}.pdf"
                    };

                    if ((bool)saveFileDialog.ShowDialog())
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.Create)))
                        {
                            writer.Write(document);
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Cannot override the file. The file may be opened.");
                }
                catch
                {
                    MessageBox.Show("Error downloading list of presenters");
                }
                ListOfPresentersButton.IsEnabled = true;
            }
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
            PresentationDetailsReadOnly newWindow = new PresentationDetailsReadOnly(presentation);
            newWindow.ShowDialog();
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

        private async void DownloadICal_Click(object sender, RoutedEventArgs e)
        {
            DownloadICal.IsEnabled = false;
            try
            {
                var document = await confCore.GetConferenceScheduleICalAsync(UserCredentials.Account.AccountId, UserCredentials.Conference.ConferenceId);
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    AddExtension = true,
                    Filter = "ics files (*.ics)|*.ics",
                    FileName = $"{UserCredentials.Conference.Title} sessions schedule for {UserCredentials.Account.Name} iCal.ics"
                };

                if ((bool)saveFileDialog.ShowDialog())
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.Create)))
                    {
                        writer.Write(document);
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot override the file. The file may be opened.");
            }
            catch
            {
                MessageBox.Show("Error downloading schedule iCal");
            }
            DownloadICal.IsEnabled = true;
        }
    }
}
