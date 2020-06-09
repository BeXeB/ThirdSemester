using client_desktop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace client_desktop
{
    public class NavigationService
    {
        public void NavigateTo(Type viewType)
        {
            var mainPage = Window.Current.Content as MainPage;
            mainPage.NavigationFrame.Navigate(viewType,null, new SuppressNavigationTransitionInfo());
        }

        public void NavigateBack()
        {
            var mainPage = Window.Current.Content as MainPage;
            mainPage.NavigationFrame.GoBack();
        }

        public void NavigateHomePageTo(Type viewType)
        {
            var mainPage = Window.Current.Content as MainPage;
            var homePage = mainPage.NavigationFrame.Content as HomePage;
            homePage.NavigationFrame.Navigate(viewType,null, new SuppressNavigationTransitionInfo());
        }
        public void NavigateHomePageTo(Type viewType, object param)
        {
            var mainPage = Window.Current.Content as MainPage;
            var homePage = mainPage.NavigationFrame.Content as HomePage;
            homePage.NavigationFrame.Navigate(viewType, param,  new SuppressNavigationTransitionInfo());
        }
        public void NavigateHousePageTo(Type viewType)
        {
            var mainPage = Window.Current.Content as MainPage; 
            var homePage = mainPage.NavigationFrame.Content as HomePage;
            var housePage = homePage.NavigationFrame.Content as ViewHousePage;
            housePage.NavigationFrame.Navigate(viewType, null, new SuppressNavigationTransitionInfo());
        }
        public void NavigateHousePageTo(Type viewType, object param)
        {
            var mainPage = Window.Current.Content as MainPage;
            var homePage = mainPage.NavigationFrame.Content as HomePage;
            var housePage = homePage.NavigationFrame.Content as ViewHousePage;
            housePage.NavigationFrame.Navigate(viewType, param, new SuppressNavigationTransitionInfo());
        }
    }
}
