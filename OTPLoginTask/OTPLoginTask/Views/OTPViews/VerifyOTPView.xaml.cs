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
    public partial class VerifyOTPView : ContentPage
    {
        public VerifyOTPView()
        {
            InitializeComponent();
        }

        









        private void FirstDigitEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstDigitEntry.Text.Length > 0)
            {
                SecondDigitEntry.Focus();
            }
        }

        private void SecondDigitEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SecondDigitEntry.Text.Length > 0)
            {
                ThirdDigitEntry.Focus();
            }
        }

        private void ThirdDigitEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ThirdDigitEntry.Text.Length > 0)
            {
                FourthDigitEntry.Focus();
            }
        }

        private void FourthDigitEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FourthDigitEntry.Text.Length > 0)
            {
                FifthDigitEntry.Focus();
            }
        }

        private void FifthDigitEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FifthDigitEntry.Text.Length > 0)
            {
                SixthDigitEntry.Focus();
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            FirstDigitEntry.Focus();
        }
    }
}