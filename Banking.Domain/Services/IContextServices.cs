using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Domain.Services
{
    interface IContextServices
    {
        IAccountRepository AccountRepository { get; }
    }
}
