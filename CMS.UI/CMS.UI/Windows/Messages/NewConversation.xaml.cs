﻿using System;
using MahApps.Metro.Controls;
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
using CMS.Core.Interfaces;
using CMS.Core.Core;
using CMS.BE.DTO;

namespace CMS.UI.Windows.Messages
{
    /// <summary>
    /// Interaction logic for NewConversation.xaml
    /// </summary>
    public partial class NewConversation : MetroWindow
    {
        IAuthenticationCore authcore = new AuthenticationCore();
        IMessageCore msgcore = new MessageCore();
        public NewConversation()
        {
            
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string login_requested = login_input.Text;
            AccountDTO account2sent = await authcore.GetAccountByLoginAsync(login_requested);
            if(account2sent != null)
            {
                MessageDTO message2sent = new MessageDTO();
                message2sent.Content = msgBox.Text;
                message2sent.SenderId = UserCredentials.Account.AccountId;
                message2sent.ReceiverId = account2sent.AccountId;
                message2sent.Date = DateTime.Now;
                bool respond = await msgcore.AddMessageAsync(message2sent);
                if (respond)
                {
                    this.Close();
                } else
                {
                    MessageBox.Show("The login is correct but there was a server error while sending message. Please try again");
                }

            } else
            {
                MessageBox.Show("The login is incorrect");
            }
        }
    }
}
