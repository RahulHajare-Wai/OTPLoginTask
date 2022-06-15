using MvvmHelpers;
using MvvmHelpers.Commands;
using OTPLoginTask.Views.Flyouts;
using OTPLoginTask.Views.OTPViews;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OTPLoginTask.ViewModels.OTPViews
{
    public class VerifyOTPViewViewModel : BaseViewModel
    {
        public string success = "False";
        public MvvmHelpers.Commands.Command SubmitOTP { get; set; }
        public string firstDigit { get; set; }
        public string secondDigit { get; set; }
        public string thirdDigit { get; set; }
        public string fourthDigit { get; set; }
        public string fifthDigit { get; set; }
        public string sixthDigit { get; set; }
        public string MobileNumber { get; set; }
        public VerifyOTPViewViewModel()
        {
            SubmitOTP = new MvvmHelpers.Commands.Command(() => { VerifyAndSubmitOTP(); });
            MobileNumber = $"+91 {Preferences.Get("MobileNumber", string.Empty)}";
        }

        private void VerifyAndSubmitOTP()
        {
            string[] NewOTP = { firstDigit.ToString(), secondDigit.ToString(), thirdDigit.ToString(), fourthDigit.ToString(), fifthDigit.ToString(), sixthDigit.ToString() };
            var generatedOTP = Preferences.Get("NewOTP", string.Empty);
            var currentOTP = string.Concat(NewOTP);
            if (currentOTP.ToString() == generatedOTP.ToString())
            {
                success = "True";
                Application.Current.MainPage.Navigation.PushAsync(new SuccessView(success));
                Application.Current.MainPage.Navigation.PushAsync(new FlyoutView());
            }
            else
            {
                success = "False";
                Application.Current.MainPage.Navigation.PushAsync(new SuccessView(success));
            }
        }
    }
}
