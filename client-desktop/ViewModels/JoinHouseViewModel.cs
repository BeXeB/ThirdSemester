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
    class JoinHouseViewModel : ViewModelBase
    {
        private static readonly HouseServiceReference.IHouseService houseService = new HouseServiceReference.HouseServiceClient();

        private string invitatincode_ = string.Empty;
        private string errorMessage_ = string.Empty;

        public string InvitationCode 
        {
            get 
            {
                return invitatincode_;
            }
            set 
            {
                invitatincode_ = value;
                OnPropertyChanged("InvitationCode");
            }
        }

        public string ErrorMessage 
        {
            get 
            {
                return errorMessage_;
            }
            set 
            {
                errorMessage_ = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public ICommand JoinHouseCommand
        {
            get
            {
                return new DelegateCommand(JoinHouse);
            }
        }

        private void JoinHouse()
        {
            try
            {
                if (CheckFields())
                {
                    houseService.JoinHouseAsync(InvitationCode, Account.GetInstace().Session).Wait();
                    ObservableCollection<HouseServiceReference.House> serverlist = houseService.GetAllHouseAsync(Account.GetInstace().Session).Result;
                    HouseListViewModel.Houses.Clear();
                    foreach (var house in serverlist)
                    {
                        ObservableCollection<Person> people = new ObservableCollection<Person>();
                        foreach (var person in house.People)
                        {
                            people.Add(new Person { UserName = person.Person.UserName });
                        }
                        HouseListViewModel.Houses.Add(new HouseItem { City = house.Address.City, DoorNo = house.Address.DoorNo, Floor = house.Address.FloorNo, HouseNo = house.Address.HouseNo, Id = house.Id, Street = house.Address.Street, ZipCode = house.Address.ZipCode, InviteCode = house.InviteCode, People = people });
                    }
                    NavigationService navigationService = new NavigationService();
                    navigationService.NavigateHomePageTo(typeof(HouseListPage));
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        private bool CheckFields()
        {
            if (InvitationCode.Equals(string.Empty))
            {
                throw new Exception("Please fill in the field");
            }
            return true;
        }
    }
}
