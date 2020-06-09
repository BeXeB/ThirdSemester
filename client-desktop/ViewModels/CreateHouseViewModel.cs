using client_desktop.HouseServiceReference;
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
using Windows.Foundation.Collections;
using Person = client_desktop.Models.Person;

namespace client_desktop.ViewModels
{
    class CreateHouseViewModel : ViewModelBase
    {
        private static readonly HouseServiceReference.IHouseService houseService = new HouseServiceReference.HouseServiceClient();

        private string name_ = string.Empty;
        private string addressStreet_ = string.Empty;
        private string addressHouseNo_ = string.Empty;
        private string addressCity_ = string.Empty;
        private string addressZip_ = string.Empty;
        private string addressFloor_;
        private string addressDoorNo_ = string.Empty;
        private string errorMsg_ = string.Empty;

        public string Name 
        {
            get
            {
                return name_;
            }
            set
            {
                name_ = value;
                OnPropertyChanged("Name");
            }
        }

        public string AddressStreet
        {
            get
            {
                return addressStreet_;
            }
            set
            {
                addressStreet_ = value;
                OnPropertyChanged("AddressStreet");
            }
        }

        public string AddressHouseNo
        {
            get
            {
                return addressHouseNo_;
            }
            set
            {
                addressHouseNo_ = value;
                OnPropertyChanged("AddressHouseNo");
            }
        }

        public string AddressCity
        {
            get
            {
                return addressCity_;
            }
            set
            {
                addressCity_ = value;
                OnPropertyChanged("AddressCity");
            }
        }

        public string AddressZip
        {
            get
            {
                return addressZip_;
            }
            set
            {
                addressZip_ = value;
                OnPropertyChanged("AddressZip");
            }
        }

        public string AddressFloor
        {
            get
            {
                return addressFloor_;
            }
            set
            {
                addressFloor_ = value;
                OnPropertyChanged("AddressFloor");
            }
        }

        public string AddressDoorNo
        {
            get
            {
                return addressDoorNo_;
            }
            set
            {
                addressDoorNo_ = value;
                OnPropertyChanged("AddressDoorNo");
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

        public ICommand CreateHouseCommand
        {
            get
            {
                return new DelegateCommand(CreateHouse);
            }
        }

        private void CreateHouse()
        {
            try
            {
                if (CheckFields())
                {
                    houseService.CreateHouseAsync(new House { Name = Name, Address = new Address { City = AddressCity, DoorNo = AddressDoorNo, FloorNo = short.Parse(AddressFloor), HouseNo = AddressHouseNo, Street = AddressStreet, ZipCode = int.Parse(AddressZip) } }, Account.GetInstace().Session).Wait();
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
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }
        }

        private bool CheckFields()
        {
            if (AddressStreet.Equals(string.Empty) || AddressCity.Equals(string.Empty) || AddressHouseNo.Equals(string.Empty))
            {
                throw new Exception("Please fill in the fields");
            }
            if (!FieldValidation.ValidateInt(AddressZip))
            {
                throw new Exception("Invalid Zip Code");
            }
            return true;
        }
    }
}
