using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualWallet.ViewModels;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VirtualWallet.Models;
using VirtualWallet.Extentions;

namespace VirtualWallet.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [AuthorizeHouseholdRequired]
        public ActionResult Dashboard()
        {
            var userHouse = db.Households.Find(User.Identity.GetHouseholdId());
            var houseAccounts = userHouse.Accounts.ToList();
            var recentTransactions = houseAccounts.SelectMany(a => a.Transactions).Where(t => !t.IsDeleted).OrderByDescending(t => t.Created).Take(5).ToList();
            var userAccounts = houseAccounts.Where(a => a.OwnerId == User.Identity.GetUserId()).ToList();

            var userView = new HomeDashboardVM() { 
            UserHouse = userHouse,
            RecentTransactions = recentTransactions,
            HouseAccounts = houseAccounts,
            UserAccounts = userAccounts
            };
            if (userHouse.Budgets.Count < 1 && userAccounts.Count < 1 )
            {
                return RedirectToAction("ConfigureHouse", "Households");
            }
            return View(userView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}