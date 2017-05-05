using System;
using Banking.Domain.Contexts.BankTransfer.Roles;
using Banking.Domain.Model;

namespace Banking.Domain.Contexts.BankTransfer.Behaviors
{
    internal static class SourceAccountBehaviors
    {
        internal static Account Withdraw(this SourceAccount fromAccount, decimal amount, Action<IAccount> persist)
        {
            if (fromAccount.Balance < amount)
            {
                throw new Exception("Insufficient funds");
            }

            var newFromAccount = new Account(fromAccount.Id, fromAccount.Balance - amount);
            persist(newFromAccount);
            Console.WriteLine($"Withrew {amount} from Account #{newFromAccount.Id}. New Balance = {newFromAccount.Balance}.");

            return newFromAccount;
        }
    }
}
