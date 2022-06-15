using MvvmHelpers;
using OTPLoginTask.Databases;
using OTPLoginTask.Models;
using OTPLoginTask.Views.Notifications;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace OTPLoginTask.ViewModels.Notifications
{
    public class AddNotificationViewViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public string PageTitle { get; set; }
        private NotificationModel _notifications { get; set; }

        public NotificationModel notification
        {
            get { return _notifications; }
            set
            {
                _notifications = value;
                OnPropertyChanged();
            }
        }

        public Command CommandSaveNotifications { get; set; }
        public AddNotificationViewViewModel()
        {
            PageTitle = "Add Notification";
            notification = new NotificationModel();
            notification.ID = 1;
            notification.NotificationTitle = "";
            notification.NotificationDescription = "";
            notification.NotificationTime = DateTime.Now.ToShortTimeString();
            CommandSaveNotifications = new Command(SaveNotifications);
        }

        public void SaveNotifications()
        {
            try
            {
                NotificationDatabase notificationDatabase = new NotificationDatabase();
                int i = notificationDatabase.SaveNotifications(notification).Result;

                if (i == 1)
                {
                    Application.Current.MainPage.Navigation.PushAsync(new NotificationsView());
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("", "Cannot save Notification Information", "ok");
                }

            }

            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("", ex.ToString(), "ok");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

