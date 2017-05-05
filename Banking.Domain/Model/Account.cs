using Banking.Domain.Contexts.BankTransfer.Roles;

namespace Banking.Domain.Model
{
    public interface IAccount
    {
        int Id { get; }
        decimal Balance { get; }
    }
    public class Account : SourceAccount, DestinationAccount
    {
        public Account(int id, decimal balance)
        {
            this.Id = id;
            this.Balance = balance;
        }
        public int Id { get; }
        public decimal Balance { get; }
    }
}
