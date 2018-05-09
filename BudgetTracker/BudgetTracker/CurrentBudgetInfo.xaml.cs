using BudgetTracker.Helpers;
using BudgetTracker.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CurrentBudgetInfo : ContentPage
	{
       
        public  CurrentBudgetInfo ()
		{
			InitializeComponent();
            GetBudgetInformation();
		}

        private async void GetBudgetInformation()
        {
            var info = await PCLHelper.ReadAllTextAsync("Budget.txt");
            var b = JsonConvert.DeserializeObject<Budget>(info.ToString());
           sBudget.Text = $"Budget: {b.TotalBudget}";
            currentBalance.Text = $"Balance: {b.CurrentBudget}";
            
        }
        
	}
}