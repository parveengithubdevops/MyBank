﻿using MyBank.Domain;
using MyBank.Domain.Repositories;
using System.Linq;

namespace MyBank.Infrastructure.EntityFrameworkCore.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext context;

        public AccountRepository(AccountContext context)
        {
            this.context = context;
        }

        public Account FindByNumber(AccountNumber number)
        {
            return this.context.Clients.First(a => a.Account != null && a.Account.Number.Number == number.Number).Account;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
