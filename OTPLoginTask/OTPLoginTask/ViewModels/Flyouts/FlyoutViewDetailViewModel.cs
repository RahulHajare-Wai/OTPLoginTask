using MvvmHelpers;
using OTPLoginTask.Views.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OTPLoginTask.ViewModels.Flyouts
{
    public class FlyoutViewDetailViewModel:BaseViewModel
    {
        public ICommand CommandNotificationPage { get; set; }
        public string TotalNotifications { get; set; }

        public FlyoutViewDetailViewModel()
        {
            CommandNotificationPage = new Command(() => { NavigateToNotificationPage(); });
            TotalNotifications = Preferences.Get("TotalNotifications", string.Empty);
        }

        private void NavigateToNotificationPage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NotificationsView());
        }
    }
}
