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
    class HouseListViewModel
    {
        private static ObservableCollection<HouseItem> houses_ = new ObservableCollection<HouseItem>();

        public static ObservableCollection<HouseItem> Houses
        {
            get
            {
                return houses_;
            }
        }

        public static void ClickHouse(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (HouseItem)e.ClickedItem;
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateHomePageTo(typeof(ViewHousePage), clickedItem);
        }
    }
}
