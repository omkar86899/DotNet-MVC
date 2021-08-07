using System;
using System.Collections.Generic;
using BankProjectAppLib.Data;

namespace BankProjectAppLib.Service
{
    public interface IBankingService
    {
        void CreateAccount(Account account);

        Account GetAccountDetails(String name);

        void Deposit(String name, double amount);

        void Withdraw(String name, double amount);

        List<Transaction> GetAccountTransactions(String name);
    }
}
