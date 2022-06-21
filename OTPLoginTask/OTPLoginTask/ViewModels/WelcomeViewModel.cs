using MvvmHelpers;
using OTPLoginTask.Views.OTPViews;
using Xamarin.Forms;

namespace OTPLoginTask.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public string Greet { get; set; }
        public string LogoImage { get; set; }
        public string ButtonText { get; set; }
        public MvvmHelpers.Commands.Command CommandLogin { get; set; }
        public WelcomeViewModel()
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
