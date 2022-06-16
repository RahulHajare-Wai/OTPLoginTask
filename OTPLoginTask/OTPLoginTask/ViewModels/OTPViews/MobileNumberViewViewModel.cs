using MvvmHelpers;
using OTPLoginTask.Views.OTPViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OTPLoginTask.ViewModels.OTPViews
{
    public class MobileNumberViewViewModel : BaseViewModel
    {
        public string SuccessImage { get; set; }
        public string MobilePageTitle { get; set; }
        public string MobilePageSubTitle { get; set; }
        public string MobilePageThirdSubTitle { get; set; }
        public string MobilePageCountryCode { get; set; }
        public ICommand SendOTP { get; set; }
        public Command MobileNumberChanged { get; set; }
        public string MobileNumber { get; set; }
        public MobileNumberViewViewModel()
        {
            VerifyMobileNumber();
            SendOTP = new Command(() => { SendOTPToUser(); });
            MobilePageTitle = "Login With Mobile Number";
            MobilePageSubTitle = "Enter your mobile number we will sent";
            MobilePageThirdSubTitle = "Enter your mobile number we will sent";
            MobilePageCountryCode = "+91";
            
        }

        private void VerifyMobileNumber()
        {
            MobileNumberChanged=new Command(() =>{
                Application.Current.MainPage.DisplayAlert("", "Hi", "");
            });
        }

        public void SendOTPToUser()
        {
            if (MobileNumber == null)
            {
                Application.Current.MainPage.DisplayAlert("Alert", "Please enter mobile number", "ok");
            }
            else
            {
                string accountSid = "AC7c128be919621bb56440ddaa1c83eeb6";
                string authToken = "e8c59c56a2bbf7061f65ce41644ac9dc";
                Random OtpGenerator = new Random();
                string randomOTP = OtpGenerator.Next(0, 999999).ToString("D6");
                Preferences.Set("NewOTP", randomOTP.ToString());
                Preferences.Set("MobileNumber", MobileNumber.ToString());
                TwilioClient.Init(accountSid, authToken);
                var message = MessageResource.Create(
                    body: $"Hello User Your new OTP Is :  {randomOTP}",
                    from: new Twilio.Types.PhoneNumber("+18123890406"),
                    to: new Twilio.Types.PhoneNumber($"+91{MobileNumber}")
                );
                Application.Current.MainPage.Navigation.PushAsync(new VerifyOTPView());
            }
        }
    }
}
