using OTPLoginTask.ViewModels.OTPViews;
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
        String Success;
        public SuccessView(string Success)
        {
            this.Success = Success;
            InitializeComponent();
            BindingContext = new SuccessViewModel(Success);
        }

        
    }
}