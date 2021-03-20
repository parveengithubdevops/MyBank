﻿using MyBank.Domain.Repositories;

namespace MyBank.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void Deposit(AccountNumber accountNumber, float amount)
        {
            var account = accountRepository.FindByNumber(accountNumber);
            
            account.Deposit(amount);

            accountRepository.Save();
        }

        public void Transfer(AccountNumber fromNumber, AccountNumber toNumber, float amount)
        {
            var from = accountRepository.FindByNumber(fromNumber);
            var to = accountRepository.FindByNumber(toNumber);

            from.Withdraw(amount);
            to.Deposit(amount);

            accountRepository.Save();
        }

        public void Withdraw(AccountNumber accountNumber, float amount)
        {
            var account = accountRepository.FindByNumber(accountNumber);

            account.Withdraw(amount);

            accountRepository.Save();
        }
    }
}
