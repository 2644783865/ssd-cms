using CMS.BE.DTO;
using MahApps.Metro.Controls;
using System.Windows;

namespace CMS.UI.Windows.Event
{
    /// <summary>
    /// Interaction logic for EventDetails.xaml
    /// </summary>
    public partial class EventDetails : MetroWindow
    {
        private EventDTO currentEvent;
        public EventDetails(EventDTO currentEvent)
        {
            InitializeComponent();
            this.currentEvent = currentEvent;
            FillEventBoxes();
        }

        private void FillEventBoxes()
        {
            try
            {
                IdLabel.Content = currentEvent.EventId;
                TitleLabel.Content = currentEvent.Title;
                DescriptionBox.Text = currentEvent.Description;
                BeginDateLabel.Content = currentEvent.BeginDate;
                EndDateLabel.Content = currentEvent.EndDate;
                RoomLabel.Content = currentEvent.RoomId.HasValue ? currentEvent.RoomCode : "-";
            }
            catch
            {
                MessageBox.Show("Something went wrong while loading information");
            }
        }
    }
}
