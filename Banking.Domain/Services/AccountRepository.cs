using System;
using System.Collections.Generic;
using System.Text;
using Banking.Domain.Contexts.BankTransfer.Roles;
using Banking.Domain.Model;

namespace Banking.Domain.Services
{
    internal class AccountRepository : IAccountRepository
    {
        public void Persist(IAccount account) => throw new Exception("Not Implemented!");

        public Account GetAccount(int sourceAccountNo) => throw new Exception("Not Implemented!");

        public ITransaction BeginTransaction() => throw new Exception("Not Implemented!");
    }
    
}
