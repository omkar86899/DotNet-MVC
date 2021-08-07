using System;
using System.Collections.Generic;

namespace BankProjectAppLib.Data
{
    public class Account
    {
        private String _name;
        private double _balance;
        private String _password;
        private List<Transaction> _transactions;

        public Account(String name, double balance, String password)
        {
            _transactions = new List<Transaction>();
            _name = name;
            _balance = balance;
            _password = password;
        }
        
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public double Balance
        {
            get
            {
                return _balance;
            }
        }

        public String Password
        {
            get
            {
                return _password;
            }
        }

        public List<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
        }

        public void AddTransactionDetails(Transaction transaction)
        {
            _transactions.Add(transaction);
        }
    }
}
