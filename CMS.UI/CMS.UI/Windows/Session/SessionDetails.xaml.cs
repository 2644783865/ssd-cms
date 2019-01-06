using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using System.Windows;

namespace CMS.UI.Windows.Session
{
    /// <summary>
    /// Interaction logic for SessionDetails.xaml
    /// </summary>
    public partial class SessionDetails : MetroWindow
    {
        private SessionDTO session;
        private SpecialSessionDTO specialSession;
        private IRoomCore roomCore;
        public SessionDetails(SessionDTO session, SpecialSessionDTO specialSession)
        {
            InitializeComponent();
            this.session = session;
            this.specialSession = specialSession;
            roomCore = new RoomCore();
            if (specialSession != null) Title = "Special session details";
            FillSessionBoxes();
        }

        private void FillSessionBoxes()
        {
            try
            {
                IdLabel.Content = session != null ? session.SessionId : specialSession.SpecialSessionId;
                TitleLabel.Content = session != null ? session.Title : specialSession.Title;
                DescriptionBox.Text = session != null ? session.Description : specialSession.Description;
                ChairLabel.Content = session != null ? session.AccountName : specialSession.AccountName;
                BeginDateLabel.Content = session != null ? session.BeginDate : specialSession.BeginDate;
                EndDateLabel.Content = session != null ? session.EndDate : specialSession.EndDate;
                RoomLabel.Content = session != null ? $"r:{session.RoomCode}" : $"r:{specialSession.RoomCode}";
            }
            catch
            {
                MessageBox.Show("Something went wrong while loading information");
            }
        }
    }
}
