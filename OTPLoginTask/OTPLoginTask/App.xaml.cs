using OTPLoginTask.Views;
using OTPLoginTask.Views.Flyouts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OTPLoginTask
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FlyoutView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
