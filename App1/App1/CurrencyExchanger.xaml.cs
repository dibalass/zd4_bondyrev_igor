using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrencyExchanger : ContentPage
    {
        public CurrencyExchanger()
        {
            InitializeComponent();
        }

        private void USDChanged (object sender, TextChangedEventArgs e)
        {
            if (usdEntry.Text != "")
            {
                try
                {
                    eurLabel.Text = (double.Parse(usdEntry.Text) * 1.075).ToString();
                } catch (Exception)
                {
                    this.DisplayToastAsync("Введи число");
                    usdEntry.Text = "";
                }
            }
        }
    }
}