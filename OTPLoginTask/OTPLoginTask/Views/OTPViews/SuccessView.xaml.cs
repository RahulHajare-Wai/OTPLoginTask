using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OTPLoginTask.Views.OTPViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessView : ContentPage
    {
        public string success = "false";
        public SuccessView(string success)
        {
            InitializeComponent();
            this.success = success;
            if (success == "True")
            {
                SuccessMessage.Text = "Verified Successfully";
                successSubmessage.Text = "Your OTP has been Verified";
                responseImage.Source = "verified.png";
                ButtonContinue.IsVisible = false;
            }
            else
            {
                SuccessMessage.Text = "Not verified";
                successSubmessage.Text = "You have to enter OTP again.";
                responseImage.Source = "failed.png";
                ButtonContinue.Text = "Enter OTP again";
            }
        }
        private void NumberPageIndicatorTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void ButtonContinue_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VerifyOTPView());
        }
    }
}