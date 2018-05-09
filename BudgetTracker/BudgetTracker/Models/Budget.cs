using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Models
{
    public class Budget
    {
        public decimal TotalBudget { get; set; }
        public decimal CurrentBudget { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public decimal Spent { get; set; }
        public string Description { get; set; }
        public string SelectedMonth { get; set; }
    }
}
