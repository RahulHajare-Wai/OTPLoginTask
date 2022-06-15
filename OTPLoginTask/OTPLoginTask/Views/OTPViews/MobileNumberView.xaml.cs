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
    public partial class MobileNumberView : ContentPage
    {
        public MobileNumberView()
        {
            InitializeComponent();
        }

        private void MobNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(MobNo.Text.Length==10)
            {
                successImage.IsVisible = true;
            }
            else
            {
                successImage.IsVisible = false;
            }
        }
    }
}