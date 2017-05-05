using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Domain.Services
{
    internal class ContextServices : IContextServices
    {
        public ContextServices(IAccountRepository accountRepository)
        {
            this.AccountRepository = accountRepository;
        }
        public IAccountRepository AccountRepository { get; private set; }
    }
}
