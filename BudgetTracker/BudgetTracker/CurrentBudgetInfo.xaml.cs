using BudgetTracker.Helpers;
using BudgetTracker.Models;
using Newtonsoft.Json;
using System;
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
            try
            {
                InitializeComponent();
                GetBudgetInformation();
            }
            catch(Exception e)
            {

            }
			
		}


        private Budget model;
        private async void GetBudgetInformation()
        {
            var info = await PCLHelper.ReadAllTextAsync("Budget.txt");
            var b = JsonConvert.DeserializeObject<Budget>(info.ToString());
           sBudget.Text = $"Budget: {b.TotalBudget}";
           currentBalance.Text = $"Balance: {b.CurrentBudget}";

            model.CurrentBudget = b.CurrentBudget;
            model.TotalBudget = b.TotalBudget;
            model.DateModified = DateTime.Now;
            model.DateCreated = b.DateCreated;
            model.SelectedMonth = b.SelectedMonth;
            model.Description = null;
            
        }

        public async void AddExpenditure(object sender, EventArgs e)
        {
            decimal expense = 0m;
            decimal.TryParse(expenditure.Text, out expense);
            var result = await BalanceAfterExpenditure(model.CurrentBudget, expense);
            currentBalance.Text = result.ToString();
            //now update file
            var newBudget = new Budget
            {
                TotalBudget = model.TotalBudget,
                CurrentBudget = result,
                DateCreated = model.DateCreated,
                DateModified = model.DateModified,
                SelectedMonth = model.SelectedMonth,
            };

            var json = JsonConvert.SerializeObject(newBudget);
           await PCLHelper.WriteTextAllAsync("Budget.txt", json.ToString());

        }
            
        public async Task<decimal> BalanceAfterExpenditure(decimal currentBalance, decimal expenditure)
        {
            decimal balanceResult =  currentBalance - expenditure;
            return balanceResult;
           
        }
	}
}