using client_desktop.Models;
using client_desktop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace client_desktop.ViewModels
{
    class EditlistViewModel : ViewModelBase
    {
        private static readonly ListServiceReference.IListService listService = new ListServiceReference.ListServiceClient();

        private string title_ = string.Empty;
        private string list_ = string.Empty;
        private int id_ = -1;

        public string Title
        {
            get
            {
                return title_;
            }
            set
            {
                title_ = value;
                OnPropertyChanged("Title");
            }
        }

        public string List
        {
            get
            {
                return list_;
            }
            set
            {
                list_ = value;
                OnPropertyChanged("List");
            }
        }

        public string Id
        {
            get
            {
                return id_.ToString();
            }
            set
            {
                id_ = int.Parse(value);
                OnPropertyChanged("Id");
            }
        }

        public ICommand EditListItemCommand
        {
            get
            {
                return new DelegateCommand(EditListItem);
            }
        }

        private void EditListItem()
        {
            foreach (var item in ListsViewModel.Lists)
            {
                if (item.Id == id_)
                {
                    listService.UpdateListAsync(new ListServiceReference.MemoList { Id = item.Id, Title = Title, Description = List }, Account.GetInstace().Session).Wait();
                    item.Title = title_;
                    item.List = list_;
                    break;
                }
            }
            Cancel();
        }

        public ICommand DeleteListItemCommand
        {
            get
            {
                return new DelegateCommand(DeleteListItem);
            }
        }

        private void DeleteListItem()
        {
            foreach (var item in ListsViewModel.Lists)
            {
                if (item.Id == id_)
                {
                    listService.DeleteListAsync(new ListServiceReference.MemoList { Id = item.Id }, Account.GetInstace().Session);
                    ListsViewModel.Lists.Remove(item);
                    break;
                }
            }
            Cancel();
        }

        public ICommand CancelCommand
        {
            get
            {
                return new DelegateCommand(Cancel);
            }
        }

        private void Cancel()
        {
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHomePageTo(typeof(ListsPage));
        }
    }
}
