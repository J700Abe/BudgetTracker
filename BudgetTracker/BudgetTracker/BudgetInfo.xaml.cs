using BudgetTracker.Helpers;
using BudgetTracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BudgetInfo : ContentPage
	{
       
       
        public BudgetInfo ()
		{

            InitializeComponent();
            RunApp();
		}

        public void RunApp()
        {
            var monthList = new List<string>();
             for(int i = 0; i < 12; i++)
            {
                monthList.Add(CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[i]);
            }
            monthPicker.ItemsSource = monthList;
        }

        private  async void SetBudget(object sender, EventArgs e)
        {

            var _setBudget = new Budget
            {
                TotalBudget = decimal.Parse(budgetAmount.Text),
                CurrentBudget = decimal.Parse(budgetAmount.Text),
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Spent = 0,
                Description = null,
                SelectedMonth = monthPicker.SelectedItem.ToString()
            };

             var _writeToFile = JsonConvert.SerializeObject(_setBudget);
            //check if folder exists
            if (await PCLHelper.IsFolderExistAsync("AppContent"))
            {
                //now check if file exist
                if(await PCLHelper.IsFileExistAsync("Budget.txt"))
                {
                    //write
                    await PCLHelper.WriteTextAllAsync("Budget.txt", _writeToFile);
                }
                else
                {
                    //create  file and write
                  await  PCLHelper.CreateFile("Budget.txt");
                  await  PCLHelper.WriteTextAllAsync("Budget.txt", _writeToFile);
                 
                }
            }
            else
            {
                //create folder
               await PCLHelper.CreateFolder("AppContent");
               await PCLHelper.CreateFile("Budget.txt");
               await PCLHelper.WriteTextAllAsync("Budget.txt", _writeToFile);
            }

            await Navigation.PushAsync(new CurrentBudgetInfo());
        

        }

        
  

    }

}