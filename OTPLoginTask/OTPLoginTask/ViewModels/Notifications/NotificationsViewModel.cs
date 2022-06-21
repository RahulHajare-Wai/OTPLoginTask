using MvvmHelpers;
using OTPLoginTask.Databases;
using OTPLoginTask.Models.Notifications;
using OTPLoginTask.Views.Flyouts;
using OTPLoginTask.Views.Notifications;
using OTPLoginTask.Views.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OTPLoginTask.ViewModels.Notifications
{
    public class NotificationsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public string BackIcon { get; set; }
        public bool Hide { get; set; }
        public string PageTitle { get; set; }
        public Command commandAddNotification { get; set; }
        public Command CommandBackPage { get; set; }
        public Command CommandLoadScroll { get; set; }
        private ObservableCollection<NotificationModel> _notificationList { get; set; }
        public ObservableCollection<NotificationModel> NotificationList
        {
            get { return _notificationList; }
            set
            {
                _notificationList = value;
                OnPropertyChanged();
            }
        }

        public Command btnAddNotifications { get; set; }
        public NotificationsViewModel()
        {
            NotificationList = new ObservableCollection<NotificationModel>();
            PageLoad();
            GetNotifications();
        }

        private void PageLoad()
        {
            Hide = true;
            BackIcon = "backpagearrow.png";
            PageTitle = "Notifications";
            commandAddNotification = new Command(() => { NavigateToNotificationPage(); });
            CommandBackPage = new Command(() => { NavigateBackPage(); });
            CommandLoadScroll = new Command(() => { LoadDataForScroll(); });
        }

        private void LoadDataForScroll()
        {
            NotificationDatabase notificationDatabase = new NotificationDatabase();
            var notifications = notificationDatabase.getNotifications().Result;

            if (notifications != null && notifications.Count > 0)
            {
                NotificationList = new ObservableCollection<NotificationModel>();
                foreach (var notification in notifications)
                {
                    NotificationList.Add(new NotificationModel
                    {
                        ID = notification.ID,
                        NotificationTitle = notification.NotificationTitle,
                        NotificationDescription = notification.NotificationDescription,
                        NotificationTime = notification.NotificationTime,
                    });
                }
            }

        }

        private void NavigateBackPage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new FlyoutView());
        }

        private void NavigateToNotificationPage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddNotificationView());
        }

        public void GetNotifications()
        {
            try
            {
                NotificationDatabase notificationDatabase = new NotificationDatabase();
                var notification = notificationDatabase.getNotifications().Result;

                if (notification != null && notification.Count > 0)
                {
                    NotificationList = new ObservableCollection<NotificationModel>();
                    int count = 0;
                    foreach (var notifications in notification)
                    {
                        count++;
                        if (count <= 4)
                        {
                            NotificationList.Add(new NotificationModel
                            {
                                ID = notifications.ID,
                                NotificationTitle = notifications.NotificationTitle,
                                NotificationDescription = notifications.NotificationDescription,
                                NotificationTime = notifications.NotificationTime,
                            });
                        }
                        else
                        {
                            break;
                        }
                    }
                    Preferences.Set("TotalNotifications", notification.Count.ToString());


                }
                else
                    PopupNavigation.Instance.PushAsync(new PopUp("No available Notifications !"));
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Alert", ex.ToString(), "OK");
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

        public string NotificationTitle
        {
            get => NotificationTitle;
            set
            {
                NotificationTitle = value;
                OnPropertyChanged();
            }
        }

        public string NotificationDescription
        {
            get => NotificationDescription;
            set
            {
                NotificationDescription = value;
                OnPropertyChanged();
            }
        }

        public string NotificationTime
        {
            get => NotificationTime;
            set
            {
                NotificationTime = value;
                OnPropertyChanged();
            }
        }

    }
}
