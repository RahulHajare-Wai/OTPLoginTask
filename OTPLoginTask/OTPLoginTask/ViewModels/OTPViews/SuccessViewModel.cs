using MvvmHelpers;
using MvvmHelpers.Commands;
using OTPLoginTask.Views.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OTPLoginTask.ViewModels.OTPViews
{
    public class SuccessViewModel : BaseViewModel
    {
        public string Success;
        public string SuccessMessage { get; set; }
        public string SuccessSubMessage { get; set; }
        public string ResponseImage { get; set; }
        public string ButtonText { get; set; }
        public bool ButtonVisibility { get; set; }

        public SuccessViewModel(String success)
        {
            Success = success;
            ShowTextInfo();
        }


        private void ShowTextInfo()
        {
            if (Success == "True")
            {
                SuccessMessage = "Verified Successfully";
                SuccessSubMessage = "Your OTP has been Verified";
                ResponseImage = "verified.png";
                ButtonVisibility = false;
            }
            else
            {
                SuccessMessage = "Not verified";
                SuccessSubMessage = "You have to enter OTP again.";
                ResponseImage = "failed.png";
            }
            
        }
    }
}
