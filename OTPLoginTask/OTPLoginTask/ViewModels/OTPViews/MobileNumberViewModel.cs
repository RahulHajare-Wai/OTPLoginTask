using MvvmHelpers;
using OTPLoginTask.Views.OTPViews;
using OTPLoginTask.Views.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OTPLoginTask.ViewModels.OTPViews
{
    public class MobileNumberViewModel : BaseViewModel,INotifyPropertyChanged
    {
        public Command CommandValidate { get; set; }
        public bool SuccessImage { get; set; }
        public string MobilePageTitle { get; set; }
        public string verifyImage { get; set; }
        public string VerifyImage
        {
            get { return verifyImage; }
            set
            {
                verifyImage = value;
                OnPropertyChanged();
            }
        }
        public string MobilePageSubTitle { get; set; }
        public string MobilePageThirdSubTitle { get; set; }
        public string MobilePageCountryCode { get; set; }
        public ICommand SendOTP { get; set; }
        public string MobileNumber { get; set; }
        public MobileNumberViewModel()
        {
            SendOTP = new Command(() => { SendOTPToUser(); });
            MobilePageTitle = "Login With Mobile Number";
            MobilePageSubTitle = "Enter your mobile number we will sent";
            MobilePageThirdSubTitle = "Enter your mobile number we will sent";
            MobilePageCountryCode = "+91";
            CommandValidate = new Command(() => { VerifyMobileNumber(); });
        }

        private void VerifyMobileNumber()
        {
            if (MobileNumber==null)
            {
                VerifyImage = "fail.png";
            }
            else if (MobileNumber.Length == 10)
            {
                VerifyImage = "success.png";
            }
            else
            {
                VerifyImage = "fail.png";
            }
           
        }

        public void SendOTPToUser()
        {
            if (MobileNumber == null)
            {
                PopupNavigation.Instance.PushAsync(new PopUp("Please enter mobile number !"));
            }
            else
            {
                try
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
                catch (Exception ex)
                {
                    Application.Current.MainPage.DisplayAlert("Error", ex.ToString(), "ok");
                }
            }
        }
    }
}
