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
    public partial class Calc :ContentPage
    {
        public Calc ()
        {
            InitializeComponent();
        }

        private void SliderValueChange (object sender, ValueChangedEventArgs e)
        {
            SliderLabel.Text = $"{Slider.Value}%";
            try
            {
                if (LoanEntry.Text != "" && MonthEntry.Text != "")
                {
                    Calculation(LoanEntry.Text, MonthEntry.Text, PaymentTypePicker.SelectedIndex, Slider.Value);
                } else
                {
                    MonthlyPaymentLabel.Text = "Ежемесячный платеж: ...";
                    TotalLabel.Text = "Общая сумма: ...";
                    OverpaymentLabel.Text = "Переплата: ...";
                }
            } catch (Exception)
            {
                MonthlyPaymentLabel.Text = "Ежемесячный платеж:...";
                TotalLabel.Text = "Общая сумма:...";
                OverpaymentLabel.Text = "Переплата:...";
                this.DisplayToastAsync("Введи число");
            }
        }

        private void Calculation (string Summa, string Month, int TypePayment, double Slider)
        {
            if (Convert.ToDouble(Month) != 0 && Convert.ToDouble(Summa) != 0)
            {
                switch (TypePayment)
                {
                    case 0:
                    {
                        double EveryMonthPay = (Convert.ToDouble(Summa) + Convert.ToDouble(Summa) * Slider / 100) / Convert.ToDouble(Month);

                        MonthlyPaymentLabel.Text = $"Ежемесячный платеж: {Math.Round(((Convert.ToDouble(Summa) + Convert.ToDouble(Summa) * Slider / 100) / Convert.ToDouble(Month)), 2)}";
                        TotalLabel.Text = $"Общая сумма: {Math.Round(EveryMonthPay * Convert.ToDouble(Month), 2)}";
                        OverpaymentLabel.Text = $"Переплата: {Math.Round(EveryMonthPay * int.Parse(Month) - double.Parse(Summa), 2)}";
                    }
                    break;
                    default:
                    {
                        MonthlyPaymentLabel.Text = "Ежемесячный платеж:...";
                        TotalLabel.Text = "Общая сумма:...";
                        OverpaymentLabel.Text = "Переплата:...";
                    }
                    break;
                }
            } else
            {
                MonthlyPaymentLabel.Text = "Ежемесячный платеж:...";
                TotalLabel.Text = "Общая сумма:...";
                OverpaymentLabel.Text = "Переплата:...";
            }
        }
    }
}