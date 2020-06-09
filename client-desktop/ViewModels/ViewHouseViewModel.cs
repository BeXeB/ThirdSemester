using client_desktop.Models;
using client_desktop.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Person = client_desktop.Models.Person;

namespace client_desktop.ViewModels
{
    class ViewHouseViewModel : ViewModelBase
    {
        private static readonly HouseServiceReference.IHouseService houseService = new HouseServiceReference.HouseServiceClient();
        private static readonly ChatServiceReference.IChatService chatService = new ChatServiceReference.ChatServiceClient();
        private static readonly ChoreServiceReference.IChoreService choreService = new ChoreServiceReference.ChoreServiceClient();

        public static HouseItem House { get; set; }

        public ICommand GoToChoresCommand
        {
            get
            {
                return new DelegateCommand(GoToChores);
            }
        }

        private void GoToChores()
        {
            ChoreServiceReference.Chore[] serverList = choreService.GetChoresForHouseAsync(House.Id).Result;
            House.Chores.Clear();
            foreach (var item in serverList)
            {
                Person person;
                if (item.Person == null)
                {
                    person = null;
                }
                else
                {
                    person = new Person { UserName = item.Person.UserName };
                }
                House.Chores.Add( new ChoreItem { Id = item.Id, EndDate = item.DueDate, Name = item.Description, Status = (ChoreItem.StatusEnum)item.Status, Person = person });
            }
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHousePageTo(typeof(ChoresPage));
        }

        public ICommand GoToChatCommand
        {
            get
            {
                return new DelegateCommand(GoToChat);
            }
        }

        private void GoToChat()
        {
            ObservableCollection<ChatServiceReference.ChatMessage> serverList = chatService.GetChatMessagesAsync(House.Id).Result;
            House.Chat.Clear();
            foreach (var item in serverList)
            {
                House.Chat.Add(new ChatItem { SendDate = item.SendDate, Id = item.Id, Message = item.Message, Author = new Person { Id = item.Sender.Id, UserName = item.Sender.UserName } });
            }
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHousePageTo(typeof(ChatPage));
        }

        public ICommand LeaveHouseCommand
        {
            get
            {
                return new DelegateCommand(LeaveHouse);
            }
        }

        private void LeaveHouse()
        {
            houseService.LeaveHouseAsync(new HouseServiceReference.House { Id = House.Id }, Account.GetInstace().Session);
            HouseListViewModel.Houses.Remove(House);
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHomePageTo(typeof(HouseListPage));
        }
    }
}
