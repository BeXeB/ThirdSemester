using client_desktop.Models;
using client_desktop.Pages;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace client_desktop.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private static readonly HouseServiceReference.IHouseService houseService = new HouseServiceReference.HouseServiceClient();
        private static readonly ListServiceReference.IListService listService = new ListServiceReference.ListServiceClient();
        private static readonly AccountServiceReference.IAccountService accountService = new AccountServiceReference.AccountServiceClient();

        public ICommand GoToAccountCommand
        {
            get
            {
                return new DelegateCommand(GoToAccount);
            }
        }

        private void GoToAccount() 
        {
            AccountServiceReference.Person me = accountService.GetAccountIfromationAsync(Account.GetInstace().Session).Result;
            Account.GetInstace().UserName = me.UserName;
            Account.GetInstace().FirstName = me.FirstName;
            Account.GetInstace().LastName = me.LastName;
            Account.GetInstace().Phone = me.Phone;
            Account.GetInstace().Email = me.Email;
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHomePageTo(typeof(AccountPage));
        }

        public ICommand GoToCreateHouseCommand
        {
            get
            {
                return new DelegateCommand(GoToCreateHouse);
            }
        }

        private void GoToCreateHouse()
        {
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHomePageTo(typeof(CreateHousePage));
        }

        public ICommand GoToJoinHouseCommand
        {
            get
            {
                return new DelegateCommand(GoToJoinHouse);
            }
        }

        private void GoToJoinHouse()
        {
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHomePageTo(typeof(JoinHousePage));
        }

        public ICommand GoToListCommand
        {
            get
            {
                return new DelegateCommand(GoToList);
            }
        }

        private void GoToList()
        {
            ObservableCollection<ListServiceReference.MemoList> serverlist = listService.GetAllListAsync(Account.GetInstace().Session).Result;
            ListsViewModel.Lists.Clear();
            foreach (var list in serverlist)
            {
                ListsViewModel.Lists.Add(new ListItem { Id = list.Id, List = list.Description, Title = list.Title });
            }
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHomePageTo(typeof(ListsPage));
        }

        public ICommand GoToHouseListCommand
        {
            get
            {
                return new DelegateCommand(GoToHouseList);
            }
        }

        private void GoToHouseList()
        {
            ObservableCollection<HouseServiceReference.House> serverlist = houseService.GetAllHouseAsync(Account.GetInstace().Session).Result;
            HouseListViewModel.Houses.Clear();
            foreach (var house in serverlist)
            {
                ObservableCollection<Person> people = new ObservableCollection<Person>();
                foreach (var person in house.People)
                {
                    people.Add(new Person { UserName = person.Person.UserName });
                }
                HouseListViewModel.Houses.Add(new HouseItem { City = house.Address.City, DoorNo = house.Address.DoorNo, Floor = house.Address.FloorNo, HouseNo = house.Address.HouseNo, Id = house.Id, Street = house.Address.Street, ZipCode = house.Address.ZipCode, InviteCode = house.InviteCode, People = people, Chat = new ObservableCollection<ChatItem>(), Chores = new ObservableCollection<ChoreItem>() });
            }
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHomePageTo(typeof(HouseListPage));
        }

        public ICommand LogOutCommand
        {
            get
            {
                return new DelegateCommand(LogOut);
            }
        }

        private void LogOut()
        {
            Account.NullOut();
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateTo(typeof(LoginRegister));
        }
    }
}
