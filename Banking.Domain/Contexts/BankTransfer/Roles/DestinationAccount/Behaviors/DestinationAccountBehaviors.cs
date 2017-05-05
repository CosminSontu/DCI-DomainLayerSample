using Banking.Domain.Contexts.BankTransfer.Roles;
using Banking.Domain.Model;
using System;

namespace Banking.Domain.Contexts.BankTransfer.Behaviors
{
    internal static class DestinationAccountBehaviors
    {
        internal static Account Deposit(this DestinationAccount toAccount, decimal amount, Action<IAccount> persist)
        {
            var newDestinationAccount = new Account(toAccount.Id,  toAccount.Balance + amount);
            persist(newDestinationAccount);
            Console.WriteLine($"Deposited {amount} to Account #{toAccount.Id}. New Balance = {toAccount.Balance}.");
            return newDestinationAccount;
        }
    }
}
