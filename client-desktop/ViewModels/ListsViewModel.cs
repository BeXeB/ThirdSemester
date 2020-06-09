using client_desktop.Models;
using client_desktop.Pages;
using System;
using RestSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;

namespace client_desktop.ViewModels
{
    class ListsViewModel : ViewModelBase
    {
        private static readonly ListServiceReference.IListService listService = new ListServiceReference.ListServiceClient();

        private bool isList_ = true;
        private bool isCreateList_ = false;
        private string createListTitle_ = string.Empty;
        private string createListList_ = string.Empty;
        private string errorMsg_ = string.Empty;
        private static ObservableCollection<ListItem> lists_ = new ObservableCollection<ListItem>();

        public bool IsList
        {
            get
            {
                return isList_;
            }
            set
            {
                isList_ = value;
                OnPropertyChanged("IsList");
            }
        }

        public bool IsCreateList
        {
            get
            {
                return isCreateList_;
            }
            set
            {
                isCreateList_ = value;
                OnPropertyChanged("IsCreateList");
            }
        }

        public string CreateListTitle
        {
            get
            {
                return createListTitle_;
            }
            set
            {
                createListTitle_ = value;
                OnPropertyChanged("CreateListTitle");
            }
        }
        public string CreateListList
        {
            get
            {
                return createListList_;
            }
            set
            {
                createListList_ = value;
                OnPropertyChanged("CreateListList");
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

        public static ObservableCollection<ListItem> Lists
        {
            get
            {
                return lists_;
            }
        }

        public ICommand GoToCreateCommand
        {
            get
            {
                return new DelegateCommand(GoToCreate);
            }
        }

        private void GoToCreate()
        {
            IsCreateList = true;
            IsList = false;
        }

        public ICommand CreateListCancelCommand
        {
            get
            {
                return new DelegateCommand(CreateListCancel);
            }
        }

        private void CreateListCancel()
        {
            ErrorMsg = string.Empty;
            CreateListTitle = string.Empty;
            CreateListList = string.Empty;
            IsCreateList = false;
            IsList = true;
        }

        public ICommand CreateListCreateCommand
        {
            get
            {
                return new DelegateCommand(CreateListCreate);
            }
        }

        private void CreateListCreate()
        {
            try
            {
                if (CheckFields())
                {
                    int id = listService.CreateListAsync(new ListServiceReference.MemoList{ Description = CreateListList, Title = CreateListTitle }, Account.GetInstace().Session).Result;
                    Lists.Add(new ListItem { Id = id, List = CreateListList, Title = CreateListTitle });
                    CreateListTitle = string.Empty;
                    CreateListList = string.Empty;
                    IsCreateList = false;
                    IsList = true;
                }
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }
        }

        private bool CheckFields()
        {
            if (createListList_.Equals(string.Empty) || createListTitle_.Equals(string.Empty))
            {
                throw new Exception("Please fill in the fields");
            }
            return true;
        }

        public static void ClickList(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (ListItem)e.ClickedItem;
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHomePageTo(typeof(EditListPage), clickedItem);
        }
    }
}
