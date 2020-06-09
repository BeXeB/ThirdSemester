using client_desktop.Models;
using client_desktop.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace client_desktop.ViewModels
{
    class ChatViewModel : ViewModelBase
    {
        private static readonly ChatServiceReference.IChatService chatService = new ChatServiceReference.ChatServiceClient();

        private string messageText_ = string.Empty;
        private string errorMsg_ = string.Empty;

        public string MessageText
        {
            get
            {
                return messageText_;
            }
            set
            {
                messageText_ = value;
                OnPropertyChanged("MessageText");
            }
        }

        public string ErrorMsg
        {
            get
            {
                return errorMsg_;
            }
            set
            {
                errorMsg_ = value;
                OnPropertyChanged("ErrorMsg");
            }
        }

        public ICommand SendMessageCommand
        {
            get
            {
                return new DelegateCommand(SendMessage);
            }
        }

        private void SendMessage()
        {
            try
            {
                if (CheckField())
                {
                    chatService.SendMessageAsync(new ChatServiceReference.ChatMessage { Message = MessageText, SendDate = DateTime.Now }, ViewHouseViewModel.House.Id, Account.GetInstace().Session).Wait();
                    ObservableCollection<ChatServiceReference.ChatMessage> serverList = chatService.GetChatMessagesAsync(ViewHouseViewModel.House.Id).Result;
                    ViewHouseViewModel.House.Chat.Clear();
                    foreach (var item in serverList)
                    {
                        ViewHouseViewModel.House.Chat.Add(new ChatItem { SendDate = item.SendDate, Id = item.Id, Message = item.Message, Author = new Person { Id = item.Sender.Id, UserName = item.Sender.UserName } });
                    }
                    NavigationService navigationService = new NavigationService();
                    navigationService.NavigateHousePageTo(typeof(ChatPage));
                }
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }
         }

        private bool CheckField()
        {
            if (MessageText.Equals(string.Empty))
            {
                throw new Exception("Please send a valid message");
            }
            return true;
        }
    }
}