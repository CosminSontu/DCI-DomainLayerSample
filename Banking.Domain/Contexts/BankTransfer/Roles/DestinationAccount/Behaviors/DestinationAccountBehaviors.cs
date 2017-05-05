using Banking.Domain.Contexts.BankTransfer.Roles;
using Banking.Domain.Model;
using System;

namespace Banking.Domain.Contexts.BankTransfer.Behaviors
{
    internal static class DestinationAccountBehaviors
    {
        internal static Account Deposit(this DestinationAccount toAccount, decimal amount, Action<IAccount> persist)
        {
            var newToAccount = new Account(toAccount.Id,  toAccount.Balance + amount);
            persist(newToAccount);
            Console.WriteLine($"Deposited {amount} to Account #{newToAccount.Id}. New Balance = {newToAccount.Balance}.");
            return newToAccount;
        }
    }
}
