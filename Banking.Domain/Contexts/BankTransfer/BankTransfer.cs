using Banking.Domain.Contexts.BankTransfer.Behaviors;
using Banking.Domain.Contexts.BankTransfer.Roles;
using Banking.Domain.Services;

using System;

namespace Banking.Domain.Contexts.BankTransfer
{
    public class BankTransfer : IBankTransfer
    {
        internal SourceAccount FromAccount { get; private set; }
        internal DestinationAccount ToAccount { get; private set; }
        internal IContextServices Services { get; private set; }
        internal BankTransfer(int sourceAccountNo, int destinationAccountNo, IContextServices services)
        {
            Services = services;
            FromAccount = Services.AccountRepository.GetAccount(sourceAccountNo);
            ToAccount = Services.AccountRepository.GetAccount(destinationAccountNo);
        }

        public void Transfer(decimal amount)
        {
            Console.WriteLine($"Initializing transfer #{FromAccount.Id}:{FromAccount.Balance} -{amount}-> #{ToAccount.Id}:{ToAccount.Balance}");
            using (var transaction = Services.AccountRepository.BeginTransaction())
            {
                FromAccount = FromAccount.Withdraw(amount, Services.AccountRepository.Persist);
                ToAccount = ToAccount.Deposit(amount, Services.AccountRepository.Persist);

                transaction.Commit();
                Console.WriteLine("End of transaction.");
            }
        }
    }
}

