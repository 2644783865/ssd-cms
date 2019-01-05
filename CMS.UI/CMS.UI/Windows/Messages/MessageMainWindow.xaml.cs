using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
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
    /// Interaction logic for MessageMainWindow.xaml
    /// </summary>
    public partial class MessageMainWindow : MetroWindow
    {
        
        private class ContactListItem
        {
            public String Name { get; set; }
            public int AccountId { get; set; }

            public bool gotmessage { get; set; }

        }

        IMessageCore core;
        IAuthenticationCore authcore;
        List<MessageDTO> chat;
        List<LastMessageDTO> mostrecent;
        List<ContactListItem> contactlist = new List<ContactListItem>();
        int CurrentUserAccountID;
        public MessageMainWindow()
        {
            CurrentUserAccountID = UserCredentials.Account.AccountId;
            core =  new MessageCore();
            authcore = new AuthenticationCore();
            InitializeComponent();
            LoadMessageImmediately();
            CastToContactList();
            DataContext = contactlist;
            DisplayMessages();

        }

        public async void LoadMessages()
        {

            chat = await core.GetMessagesByAccountIdAsync(UserCredentials.Account.AccountId);
            mostrecent = await core.GetLastMessagesByAccountIdAsync(UserCredentials.Account.AccountId);
        }

        public void LoadMessageImmediately()
        {
            chat = Task.Run(async () => { return await core.GetMessagesByAccountIdAsync(UserCredentials.Account.AccountId); }).Result;
            mostrecent = Task.Run(async () => { return await core.GetLastMessagesByAccountIdAsync(UserCredentials.Account.AccountId); }).Result;
            chatscroll.ScrollToEnd();
        }

        

        private async void DisplayMessages()
        {
            if(chat==null || chat.Count() == 0)
            {
                chatBlock.Text = "Your conversation is empty. Say Hi!";
            } else
            {
                chatBlock.Text = "";
                foreach (var message in chat)
                {
                    String author;
                    if(message.SenderId == UserCredentials.Account.AccountId)
                    {
                        author = "You";
                    } else
                    {
                        AccountDTO receiver_account = await authcore.GetAccountByIdAsync(message.ReceiverId);
                        author = receiver_account.Name;
                    }
                    String msg = message.Date.ToString() + ", " + author + " : " + message.Content + "\n\n";
                    chatBlock.Text = chatBlock.Text + msg;
                }
            }
            
        }

        private async void CastToContactList()
        {
            foreach(var recent_msg in mostrecent)
            {
                ContactListItem converted = new ContactListItem();
                converted.AccountId = recent_msg.FirstId == CurrentUserAccountID ? recent_msg.SecondId : recent_msg.FirstId;
                AccountDTO contact_account = await authcore.GetAccountByIdAsync(converted.AccountId);
                if (contact_account == null) continue;
                converted.Name = contact_account.Name;
                converted.gotmessage = false; // todo: check if message
                contactlist.Add(converted);
            }
        }

        private void DisplayContactList()
        {
            foreach(var linked_contact in mostrecent)
            {
                //string dummy = linked_contact.

                contacts.Items.Add("fhfhf");
            }
        }
                   
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageDTO msg_to_be_sent = new MessageDTO();
            msg_to_be_sent.Content = userinputmessageBox.Text.Trim();
            msg_to_be_sent.SenderId = UserCredentials.Account.AccountId;
            msg_to_be_sent.ReceiverId = 2;
            msg_to_be_sent.Date = DateTime.Now;

            bool response = await core.AddMessageAsync(msg_to_be_sent);
            if (response)
            {
                userinputmessageBox.Text = "success";
                LoadMessageImmediately();
                DisplayMessages();
            } else {
                userinputmessageBox.Text = "failure";
            }
        }

    }


}
