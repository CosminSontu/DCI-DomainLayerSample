using Microsoft.Extensions.DependencyInjection;
using Banking.Domain.Contexts.BankTransfer;
using Banking.Domain;
using Banking.Domain.Services;
using Banking.Domain.Model;

namespace Banking.Presentation
{
    public class Program
    {
        public class DummyAccountRepository : IAccountRepository
        {
            public class DummyTransaction : ITransaction
            {
                public void Commit() { }
                public void Dispose() { }
                public void Rollback() { }
            }
            public ITransaction BeginTransaction() => new DummyTransaction();

            public Account GetAccount(int sourceAccountNo)
                => new Account(id: sourceAccountNo, balance: 2000);

            public void Persist(IAccount account) { }
        }
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddContextServices(new DummyAccountRepository())
                .BuildServiceProvider();

            IBankTransfer bankTrasferContext = services.CreateBankTransferContext(sourceAccountNo: 123,destinationAccountNo: 124);
            bankTrasferContext.Transfer(100m);
        }
    }
}