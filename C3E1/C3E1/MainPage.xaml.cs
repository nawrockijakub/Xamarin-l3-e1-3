using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Core;

namespace C3E1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Translation(object sender, EventArgs e)
        {
            var result = PhonewordTranslator.ToNumber(InputNumber.Text);
            InputNumber.Text = result;
        }
        async void Calling(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputNumber.Text))
            {
                await DisplayAlert("No target for call", String.Format("You need a number to dial"), "OK");
            }
            else
            {
                Translation(sender, e);
                await DisplayAlert("You are about to call", String.Format("Would you like to call {0}", InputNumber.Text), "Yes", "No");
                var task = DependencyService.Get<IDialer>();
                if (task != null) { await task.DialAsync(InputNumber.Text); }
                
            }
        }
    }

}

