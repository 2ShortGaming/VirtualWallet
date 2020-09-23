using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualWallet.Enums;
using VirtualWallet.Models;

namespace VirtualWallet.Extentions
{
    public static class TransactionExtensions
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static void UpdateBalances(this Transaction transaction)
        {
            UpdateBankBalance(transaction);

            if (transaction.TransactionType == TransactionType.Withdrawl)
            {
                UpdateBudgetAmount(transaction);
                UpdateBudgetItemAmount(transaction);
            }
        }

        public static void EditTransaction(this Transaction newTransaction, Transaction oldTransaction)
        {
            if (oldTransaction.TransactionType == TransactionType.Deposit)
            {
                ReverseUpdateBankBalance(oldTransaction);
                UpdateBankBalance(newTransaction);
            }
            if (oldTransaction.TransactionType == TransactionType.Withdrawl)
            {
                ReverseUpdateBankBalance(oldTransaction);
                UpdateBankBalance(newTransaction);

                ReverseUpdateBudgetAmount(oldTransaction);
                UpdateBudgetAmount(newTransaction);

                ReverseUpdateBudgetItemAmount(oldTransaction);
                UpdateBudgetItemAmount(newTransaction);
            }

        }

        private static void UpdateBankBalance(Transaction transaction)
        {
            var bankAccount = db.BankAccounts.Find(transaction.AccountId);

            switch (transaction.TransactionType)
            {
                case TransactionType.Deposit:
                    bankAccount.CurrentBalance += transaction.Amount;
                    break;
                case TransactionType.Withdrawl:
                    bankAccount.CurrentBalance -= transaction.Amount;
                    break;
                case TransactionType.Transfer:
                    break;
                default:
                    return;
            }

            db.SaveChanges();
        }

        private static void ReverseUpdateBankBalance(Transaction transaction)
        {
            var bankAccount = db.BankAccounts.Find(transaction.AccountId);

            switch (transaction.TransactionType)
            {
                case TransactionType.Deposit:
                    bankAccount.CurrentBalance -= transaction.Amount;
                    break;
                case TransactionType.Withdrawl:
                    bankAccount.CurrentBalance += transaction.Amount;
                    break;
                default:
                    return;
            }

            db.SaveChanges();
        }

        private static void UpdateBudgetAmount(Transaction transaction)
        {
            var budgetItem = db.BudgetItems.Find(transaction.BudgetItemId);
            var budget = db.Budgets.Find(budgetItem.BudgetId);
            budget.CurrentAmount += transaction.Amount;
            db.SaveChanges();
        }

        private static void ReverseUpdateBudgetAmount(Transaction transaction)
        {
            var budgetItem = db.BudgetItems.Find(transaction.BudgetItemId);
            var budget = db.Budgets.Find(budgetItem.BudgetId);
            budget.CurrentAmount -= transaction.Amount;
            db.SaveChanges();
        }

        private static void UpdateBudgetItemAmount(Transaction transaction)
        {
            var budgetItem = db.BudgetItems.Find(transaction.BudgetItemId);
            budgetItem.CurrentAmount += transaction.Amount;
            db.SaveChanges();
        }

        private static void ReverseUpdateBudgetItemAmount(Transaction transaction)
        {
            var budgetItem = db.BudgetItems.Find(transaction.BudgetItemId);
            budgetItem.CurrentAmount -= transaction.Amount;
            db.SaveChanges();
        }


    }
}