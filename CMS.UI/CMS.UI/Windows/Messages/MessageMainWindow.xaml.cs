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
using System.Collections.ObjectModel;

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

            public String Date { get; set; }
            public String LastMessageContent { get; set; }
            public bool gotmessage { get; set; }

        }

        IMessageCore core;
        IAuthenticationCore authcore;
        List<LastMessageDTO> mostrecent;
        List<MessageDTO> target;
        Dictionary<int, string> targeted_conversation;
        ObservableCollection<ContactListItem> contactlist = new ObservableCollection<ContactListItem>();
        int CurrentUserAccountID;
        int recentlyselected;
        public MessageMainWindow()
        {
            CurrentUserAccountID = UserCredentials.Account.AccountId;
            core =  new MessageCore();
            authcore = new AuthenticationCore();
            targeted_conversation = new Dictionary<int, string>();
            InitializeComponent();
            LoadRecentMessagesImmediately();
            GetPrimaryFocusAtContactAsync();
            DataContext = contactlist;
            SendButton.IsEnabled = false;
            //DisplayMessages(null);

        }

        private void GetPrimaryFocusAtContactAsync()
        {
            if(mostrecent.Count > 0)
            {
                contacts.SelectedIndex = 0;
                contacts.Focus();

            }
        }

        public async void LoadRecentMessages()
        {

            mostrecent = await core.GetLastMessagesByAccountIdAsync(UserCredentials.Account.AccountId);


        }

        public void LoadRecentMessagesImmediately()
        {
            mostrecent = Task.Run(async () => { return await core.GetLastMessagesByAccountIdAsync(UserCredentials.Account.AccountId); }).Result;
            chatscroll.ScrollToEnd();
            CastToContactList();

        }

        

        private async void DisplayMessages(List<MessageDTO> conversation, int targetId, bool forced = false)
        {
            /*
             if there is new message , load and if there is no previously loaded msgs , also load
             
             */
            if (Convert.ToBoolean(await core.HasNewMessages()) || !targeted_conversation.ContainsKey(targetId) || forced)
            {


                if (conversation == null || conversation.Count() == 0)
                {
                    chatBlock.Text = "Your conversation is empty. Say Hi!";
                }
                else
                {
                    string chat_content_buffer = "";
                    foreach (var message in conversation)
                    {
                        String author;
                        if (message.SenderId == UserCredentials.Account.AccountId)
                        {
                            author = "You";
                        }
                        else
                        {
                            AccountDTO receiver_account = await authcore.GetAccountByIdAsync(message.ReceiverId);
                            author = receiver_account.Name;
                        }
                        String msg = message.Date.ToString() + ", " + author + " : " + message.Content + "\n\n";
                        chat_content_buffer = chat_content_buffer + msg;
                    }
                    chatBlock.Text = chat_content_buffer;
                }

                targeted_conversation[targetId] = chatBlock.Text;
            } else
            {
                String result;
                targeted_conversation.TryGetValue(targetId, out result);
                if (result!= null)
                {
                    chatBlock.Text = result;
                }
            }
            
        }

        private async void CastToContactList()
        {
            if (mostrecent != null)
            {
                contactlist.Clear();
                foreach(var recent_msg in mostrecent)
                {
                    ContactListItem converted = new ContactListItem();
                    converted.AccountId = recent_msg.FirstId == CurrentUserAccountID ? recent_msg.SecondId : recent_msg.FirstId;
                    AccountDTO contact_account = await authcore.GetAccountByIdAsync(converted.AccountId);
                    if (contact_account == null || recent_msg.LastDate == null /* after added but not sent message*/) continue;
                    converted.Name = contact_account.Name;
                    converted.LastMessageContent = recent_msg.LastMessage1;
                    converted.Date = recent_msg.LastDate.Date.ToShortDateString();
                    converted.gotmessage = false; // todo: check if message
                    contactlist.Add(converted);
                }

                

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

        private int getSelectedContactId()
        {
            int selectedid = ((ContactListItem)contacts.SelectedItem).AccountId;
            if(selectedid.Equals(null))
            {
                return recentlyselected;
            }
            recentlyselected = selectedid;
            return selectedid;
        }
                   
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int targetReceiver = getSelectedContactId();
            MessageDTO msg_to_be_sent = new MessageDTO();
            msg_to_be_sent.Content = userinputmessageBox.Text.Trim();
            msg_to_be_sent.SenderId = UserCredentials.Account.AccountId;
            msg_to_be_sent.ReceiverId = targetReceiver;
            msg_to_be_sent.Date = DateTime.Now;

            bool response = await core.AddMessageAsync(msg_to_be_sent);
            if (response)
            {
                userinputmessageBox.Text = "success";
                LoadRecentMessagesImmediately();
                var targetedConversation = await core.GetMessagesByTargetIdAsync(CurrentUserAccountID, targetReceiver);
                DisplayMessages(targetedConversation, targetReceiver, true);
            } else {
                userinputmessageBox.Text = "failure";
            }
        }



        private async void contacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SendButton.IsEnabled = true;
            ContactListItem selectedContactItem = ((ContactListItem)contacts.SelectedItem);
            if (selectedContactItem != null)
            {
                var selectedId = selectedContactItem.AccountId;
                var targetedConversation = await core.GetMessagesByTargetIdAsync(CurrentUserAccountID, selectedId);
                DisplayMessages(targetedConversation, selectedId);
                if (!selectedContactItem.gotmessage)
                {
                    await core.markReceived(CurrentUserAccountID, selectedId);
                }
            }
            
            
        }

        private void chatscroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (chatscroll.VerticalOffset.Equals(0))
            {
                userinputmessageBox.Text = "jest zero";
            } else
            {
                userinputmessageBox.Text = "nima";
            }
        }

    }


}
