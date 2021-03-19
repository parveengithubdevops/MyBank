﻿namespace MyBank.Domain.Repositories
{
    public interface IAccountRepository
    {
        Account FindByNumber(AccountNumber number);
        void Save();
        void Add(Account account);
    }
}
