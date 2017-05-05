using Banking.Domain.Model;
using System;

namespace Banking.Domain.Services
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
    public interface ITransactionable
    {
        ITransaction BeginTransaction();
    }

    public interface IAccountRepository : ITransactionable
    {
        void Persist(IAccount account);

        Account GetAccount(int sourceAccountNo);
    }
}
