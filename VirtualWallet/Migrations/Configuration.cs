namespace VirtualWallet.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Configuration;
    using VirtualWallet.Enums;
    using VirtualWallet.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VirtualWallet.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VirtualWallet.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var roleManager = new RoleManager<IdentityRole>(
              new RoleStore<IdentityRole>(context));

            #region Role Creation
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Head"))
            {
                roleManager.Create(new IdentityRole { Name = "Head" });
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                roleManager.Create(new IdentityRole { Name = "Member" });
            }

            if (!context.Roles.Any(r => r.Name == "New User"))
            {
                roleManager.Create(new IdentityRole { Name = "New User" });
            }
            #endregion

            //#region Seed household
            //Household newHouse = null;
            //if (!context.Households.Any())
            //{
            //    newHouse = new Household
            //    {
            //        Created = DateTime.Now,
            //        Greeting = "Hello from Seeded House",
            //        IsDeleted = false,
            //        HouseholdName = "Seeded House"
            //    };
            //    context.Households.Add(newHouse);
            //    context.SaveChanges();
            //}
            //#endregion

            //#region User Creation
            //var userManager = new UserManager<ApplicationUser>(
            //   new UserStore<ApplicationUser>(context));
            //var myEmail = WebConfigurationManager.AppSettings["myEmail"];
            //var myPassword = WebConfigurationManager.AppSettings["myPassword"];
            //var defaultAvatarPath = WebConfigurationManager.AppSettings["DefaultAvatarPath"];


            //if (!context.Users.Any(u => u.Email == myEmail))
            //{
            //    userManager.Create(new ApplicationUser
            //    {
            //        FirstName = "Wade",
            //        LastName = "Cranford",
            //        Email = myEmail,
            //        UserName = myEmail,
            //        AvatarPath = defaultAvatarPath,
            //        HouseholdId = newHouse.Id


            //    }, myPassword);
            //    var userId = userManager.FindByEmail(myEmail).Id;
            //    userManager.AddToRoles(userId, "Admin");

            //}
            //#endregion

            //#region Seed Bank Account
            //var ownerId = context.Users.FirstOrDefault(u => u.Email == myEmail).Id;
            //if (!context.BankAccounts.Any())
            //{
            //    context.BankAccounts.Add(new BankAccount
            //    {
            //        AccountName = "Regions Checking",
            //        AccountType = AccountType.Checking,
            //        Created = DateTime.Now,
            //        CurrentBalance = 5000,
            //        HouseholdId = newHouse.Id,
            //        IsDeleted = false,
            //        OwnerId = ownerId,
            //        StartingBalance = 5000,
            //        WarningBalance = 500,

            //    });
            //    context.SaveChanges();
            //}

            //#endregion

            //#region Seed Budget
            //Budget budget = null;
            //if (!context.Budgets.Any())
            //{
            //    budget = new Budget(true);
            //    budget.BudgetName = "Utilities";
            //    budget.Created = DateTime.Now;
            //    budget.HouseholdId = newHouse.Id;
            //    budget.OwnerId = ownerId;
            //    budget.CurrentAmount = 0;

            //    context.Budgets.Add(budget);
            //    context.SaveChanges();
            //}

            //#endregion

            //#region Seed Budget Item
            //if (!context.BudgetItems.Any())
            //{
            //    context.BudgetItems.Add(new BudgetItem
            //    {
            //        CurrentAmount = 0,
            //        TargetAmount = 250,
            //        Created = DateTime.Now,
            //        IsDeleted = false,
            //        ItemName = "Power",
            //        BudgetId = budget.Id,
            //    });
            //    context.SaveChanges();
            //}

            //#endregion

            //#region Seed Transaction
            //#endregion
        }
    }
}
