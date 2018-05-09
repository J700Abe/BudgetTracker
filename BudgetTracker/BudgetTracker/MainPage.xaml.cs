
using System;
using Xamarin.Forms;

namespace BudgetTracker
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        private async void GoToBudgetPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BudgetInfo());
        }

        public async void CurrentBudget(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CurrentBudgetInfo());
        }
    }
}
