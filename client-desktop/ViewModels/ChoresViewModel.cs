using client_desktop.Models;
using client_desktop.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace client_desktop.ViewModels
{
    class ChoresViewModel : ViewModelBase
    {
        private static readonly ChoreServiceReference.IChoreService choreService = new ChoreServiceReference.ChoreServiceClient();

        public static ChoreItem SelectedChore { get; set; }

        private string createChoreName_ = string.Empty;
        private string errorMsg_ = string.Empty;
        private DateTimeOffset createChoreEndDate_ = DateTimeOffset.Now;

        public DateTimeOffset CreateChoreEndDate
        {
            get
            {
                return createChoreEndDate_;
            }
            set
            {
                createChoreEndDate_ = value;
                OnPropertyChanged("CreateChoreEndDate");
            }
        }

        public string CreateChoreName
        {
            get
            {
                return createChoreName_;
            }
            set
            {
                createChoreName_ = value;
                OnPropertyChanged("CreateChoreName");
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

        public ICommand CreateChoreCommand
        {
            get
            {
                return new DelegateCommand(CreateChore);
            }
        }
        private void CreateChore()
        {
            ErrorMsg = string.Empty;
            CreateChoreName = string.Empty;
            NavigationService navigation = new NavigationService();
            navigation.NavigateHousePageTo(typeof(CreateChorePage));
        }

        public ICommand ConfirmCreateChoreCommand
        {
            get
            {
                return new DelegateCommand(ConfirmCreateChore);
            }
        }
        private void ConfirmCreateChore()
        {
            try
            {
                if (CheckField())
                {
                    choreService.CreateChoreAsync(new ChoreServiceReference.Chore { Description = CreateChoreName, DueDate = CreateChoreEndDate.DateTime, Status = (byte)ChoreItem.StatusEnum.To_Be_Done }, ViewHouseViewModel.House.Id).Wait();
                    ChoreServiceReference.Chore[] serverList = choreService.GetChoresForHouseAsync(ViewHouseViewModel.House.Id).Result;
                    ViewHouseViewModel.House.Chores.Clear();
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
                        ViewHouseViewModel.House.Chores.Add(new ChoreItem { Id = item.Id, EndDate = item.DueDate, Name = item.Description, Status = (ChoreItem.StatusEnum)item.Status, Person = person });
                    }
                    NavigationService navigation = new NavigationService();
                    navigation.NavigateHousePageTo(typeof(ChoresPage));
                }
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }
        }

        public ICommand CancelCreateChoreCommand
        {
            get
            {
                return new DelegateCommand(CancelCreateChore);
            }
        }
        private void CancelCreateChore()
        {
            CreateChoreName = string.Empty;
            NavigationService navigation = new NavigationService();
            navigation.NavigateHousePageTo(typeof(ChoresPage));
        }

        private bool CheckField()
        {
            if (CreateChoreName.Equals(string.Empty) || CreateChoreEndDate == null)
            {
                throw new Exception("Please fill in the fields");
            }
            return true;
        }

        public ICommand JoinChoreCommand
        {
            get
            {
                return new DelegateCommand(JoinChore);
            }
        }

        private void JoinChore()
        {
            choreService.JoinChoreAsync(new ChoreServiceReference.Chore { Id = SelectedChore.Id }, Account.GetInstace().Session).Wait();
            ChoreServiceReference.Chore[] serverList = choreService.GetChoresForHouseAsync(ViewHouseViewModel.House.Id).Result;
            ViewHouseViewModel.House.Chores.Clear();
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
                ViewHouseViewModel.House.Chores.Add(new ChoreItem { Id = item.Id, EndDate = item.DueDate, Name = item.Description, Status = (ChoreItem.StatusEnum)item.Status, Person = person });
            }
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHomePageTo(typeof(ChoresPage));
        }

        public static void UpdateStatus(object sender, SelectionChangedEventArgs e)
        {
            ChoreItem.StatusEnum status = (ChoreItem.StatusEnum)(sender as ComboBox).SelectedIndex;
            choreService.UpdateStatusAsync(new ChoreServiceReference.Chore { Id = SelectedChore.Id, Status = (byte)status }, Account.GetInstace().Session).Wait();
        }

        public static void ClickChore(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (ChoreItem)e.ClickedItem;
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHomePageTo(typeof(EditChorePage), clickedItem);
        }
    }
}