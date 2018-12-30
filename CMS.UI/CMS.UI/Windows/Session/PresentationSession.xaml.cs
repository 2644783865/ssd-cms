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
using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;

namespace CMS.UI.Windows.Session
{
    /// <summary>
    /// Interaction logic for PresentationSession.xaml
    /// </summary>
    public partial class PresentationSession : MetroWindow
    {
        private SessionDTO session;
        private IPresentationCore core;
        public PresentationSession(SessionDTO session)
        {
            InitializeComponent();
            this.session = session;
            core = new PresentationCore();
            FillSessionBoxes();
            LoadUnassinged();
        }

        private void FillSessionBoxes()
        {
            TitleLabel.Content = session.Title;
            BeginLabel.Content = session.BeginDate;
            EndLabel.Content = session.EndDate;
            PlaceLabel.Content = session.RoomCode;
        }

        private async void LoadAssigned()
        {
            AssignedPresentations.ClearValue(ItemsControl.ItemsSourceProperty);
            AssignedPresentations.DisplayMemberPath = "PresentationDesc";
            AssignedPresentations.SelectedValuePath = "PresentationId";
            AssignedPresentations.ItemsSource = (await core.GetPresentationsByIdAsync(UserCredentials.Conference.ConferenceId)).Where(p => p.SessionId.HasValue && p.SessionId == session.SessionId);
        }

        private async void LoadUnassinged()
        {
            UnassignedPresentations.ClearValue(ItemsControl.ItemsSourceProperty);
            UnassignedPresentations.DisplayMemberPath = "PresentationDesc";
            UnassignedPresentations.SelectedValuePath = "PresentationId";
            UnassignedPresentations.ItemsSource = (await core.GetPresentationsByIdAsync(UserCredentials.Conference.ConferenceId)).Where(p => !p.SessionId.HasValue);
        }

        private async void LoadOther()
        {
            UnassignedPresentations.ClearValue(ItemsControl.ItemsSourceProperty);
            UnassignedPresentations.DisplayMemberPath = "PresentationDesc";
            UnassignedPresentations.SelectedValuePath = "PresentationId";
            UnassignedPresentations.ItemsSource = (await core.GetPresentationsByIdAsync(UserCredentials.Conference.ConferenceId)).Where(p => p.SessionId.HasValue && p.SessionId.Value != session.SessionId);
        }

        private async void LoadAll()
        {
            UnassignedPresentations.ClearValue(ItemsControl.ItemsSourceProperty);
            UnassignedPresentations.DisplayMemberPath = "PresentationDesc";
            UnassignedPresentations.SelectedValuePath = "PresentationId";
            UnassignedPresentations.ItemsSource = (await core.GetPresentationsByIdAsync(UserCredentials.Conference.ConferenceId));
        }

        private void Refresh()
        {
            if (UnassignedButton.Foreground == Brushes.Black) LoadUnassinged();
            if (OtherButton.Foreground == Brushes.Black) LoadOther();
            if (AllButton.Foreground == Brushes.Black) LoadAll();
            LoadAssigned();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditSession newWindow = new AddEditSession(session, null);
            newWindow.ShowDialog();
        }

        private void UnassignedButton_Click(object sender, RoutedEventArgs e)
        {
            UnassignedButton.Background = Brushes.GreenYellow;
            UnassignedButton.Foreground = Brushes.Black;
            OtherButton.Background = Brushes.Gray;
            OtherButton.Foreground = Brushes.White;
            AllButton.Background = Brushes.Gray;
            AllButton.Foreground = Brushes.White;
            LoadUnassinged();
        }

        private void OtherButton_Click(object sender, RoutedEventArgs e)
        {
            UnassignedButton.Background = Brushes.Gray;
            UnassignedButton.Foreground = Brushes.White;
            OtherButton.Background = Brushes.GreenYellow;
            OtherButton.Foreground = Brushes.Black;
            AllButton.Background = Brushes.Gray;
            AllButton.Foreground = Brushes.White;
            LoadOther();
        }

        private void AllButton_Click(object sender, RoutedEventArgs e)
        {
            UnassignedButton.Background = Brushes.Gray;
            UnassignedButton.Foreground = Brushes.White;
            OtherButton.Background = Brushes.Gray;
            OtherButton.Foreground = Brushes.White;
            AllButton.Background = Brushes.GreenYellow;
            AllButton.Foreground = Brushes.Black;
            LoadAll();
        }

        private async void AssignButton_Click(object sender, RoutedEventArgs e)
        {
            if (UnassignedPresentations.SelectedIndex >= 0)
            {
                AssignButton.IsEnabled = false;
                UnassignButton.IsEnabled = false;

                var presentarion = (PresentationDTO)UnassignedPresentations.SelectedItem;
                presentarion.SessionId = session.SessionId;
                if (!(await core.EditPresentationAsync(presentarion))) MessageBox.Show("Something went wrong");
                Refresh();
                AssignButton.IsEnabled = true;
                UnassignButton.IsEnabled = true;
            }
            else MessageBox.Show("Select presentation first");
        }

        private async void UnassignButton_Click(object sender, RoutedEventArgs e)
        {
            if (AssignedPresentations.SelectedIndex >= 0)
            {
                AssignButton.IsEnabled = false;
                UnassignButton.IsEnabled = false;

                var presentarion = (PresentationDTO)AssignedPresentations.SelectedItem;
                presentarion.SessionId = null;
                if (!(await core.EditPresentationAsync(presentarion))) MessageBox.Show("Something went wrong");
                Refresh();
                AssignButton.IsEnabled = true;
                UnassignButton.IsEnabled = true;
            }
            else MessageBox.Show("Select presentation first");
        }

        private void UnassignedPresentations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var presentation = (PresentationDTO)((ListBox)sender).SelectedItem;
            PresentationDetails newWindow = new PresentationDetails(presentation);
            newWindow.ShowDialog();
        }
    }
}
