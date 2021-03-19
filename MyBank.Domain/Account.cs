﻿using MyBank.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyBank.Domain
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public string Id { get; private set; }
        [DataMember]
        public AccountNumber Number { get; private set; }
        [DataMember]
        public AccountBalance Balance { get; private set; }

        public Account()
        {
            this.Number = new AccountNumber();
            this.Balance = new AccountBalance();
            
            this.Id = this.Number.Number;
        }

        private Account(AccountNumber number, AccountBalance balance)
        {
            this.Number = number;
            this.Balance = balance;

            this.Id = this.Number.Number;
        }
        
        public static Account Create()
        {
            var instance = new Account();
            instance.Number = new AccountNumber();
            instance.Balance = new AccountBalance();

            instance.Id = instance.Number.Number;

            return instance;
        }

        public static Account FromExistingData(AccountNumber number, AccountBalance balance)
        {
            return new Account(number, balance);
        }

        public float GetBalance()
        {
            return (float)this.Balance;
        }

        public void Deposit(float amount)
        {
            if (amount <= 0)
                throw new InvalidDepositAmountException("Amount to deposit must be greater than zero");

            this.Balance.Increase(amount);
        }

        public void Withdraw(float amount)
        {
            if (amount <= 0)
                throw new InvalidWithdrawAmountException("Amount to withdraw must be grater than zero");

            if ((float)this.Balance < amount)
                throw new InsufficientFundsException("You do not have balance to this operation");

            this.Balance.Decrease(amount);
        }

        public string GetNumber()
        {
            return Number.Number;
        }
    }
}
