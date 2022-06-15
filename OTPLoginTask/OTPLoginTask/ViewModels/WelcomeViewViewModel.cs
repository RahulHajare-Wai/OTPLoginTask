using MvvmHelpers;
using OTPLoginTask.Views.OTPViews;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OTPLoginTask.ViewModels
{
    public class WelcomeViewViewModel : BaseViewModel
    {
        public string Greet { get; set; }
        public string LogoImage { get; set; }
        public string ButtonText { get; set; }
        public MvvmHelpers.Commands.Command CommandLogin { get; set; }
        public WelcomeViewViewModel()
        {
            LogoImage = "xamarinlogo.png";
            Greet = "Base file is working.";
            ButtonText = "Login With Mobile Number";
            CommandLogin = new MvvmHelpers.Commands.Command(() => { goToLoginView(); });
        }

        private void goToLoginView()
        {
            Application.Current.MainPage.Navigation.PushAsync(new MobileNumberView());
        }
    }
}
