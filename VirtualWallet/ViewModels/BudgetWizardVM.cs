using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualWallet.Models;

namespace VirtualWallet.ViewModels
{
    public class BudgetWizardVM
    {
        public Budget Budget { get; set; }

        public ICollection<BudgetItem> BudgetItems { get; set; }
    }
}