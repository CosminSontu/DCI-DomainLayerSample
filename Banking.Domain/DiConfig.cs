using Banking.Domain.Contexts.BankTransfer;
using Banking.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Banking.Domain
{
    public static class DiConfig
    {
        public static IServiceCollection AddContextServices(this IServiceCollection services, IAccountRepository accountRepository = null)
        {
            services.AddTransient<IAccountRepository>( svcProvider => accountRepository ?? new AccountRepository());
            services.AddTransient<IContextServices, ContextServices>();
            return services;
        }

        public static BankTransfer CreateBankTransferContext(this IServiceProvider serviceProvider, int sourceAccountNo, int destinationAccountNo)
         => new BankTransfer(sourceAccountNo, destinationAccountNo, serviceProvider.GetService<IContextServices>());
    }
}
