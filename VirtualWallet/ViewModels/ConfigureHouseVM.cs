using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualWallet.Models;

namespace VirtualWallet.ViewModels
{
    public class ConfigureHouseVM
    {
        public int? HouseholdId { get; set; }

        #region One of Everything
        public BankAccount BankAccount { get; set; }

        public decimal StartingBalance { get; set; }

        public Budget Budget { get; set; }

        public BudgetItem BudgetItem { get; set; }
        #endregion
        #region Multiple Options
        //public ICollection<BankAccount> BankAccounts { get; set; }

        //public ICollection<Budget> Budgets { get; set; }

        //public ICollection<BudgetItem> BudgetItems { get; set; }
        #endregion
        //public ICollection<BankAccountWizardVM> BankAccounts { get; set; }

        //public ICollection<Budget> Budgets { get; set; }



    }
}