using System;

namespace BankProjectAppLib.Data
{
    public class Transaction
    {
        private TransactionType _transactionType;
        private DateTime _dateTime;
        private double _amount;
        public Transaction(double amount,TransactionType type, DateTime dateTime)
        {
            _amount = amount;
            _transactionType = type;
            _dateTime = dateTime;
        }

        public double Amount
        {
            get
            {
                return _amount;
            }
        }

        public TransactionType Type
        {
            get
            {
                return _transactionType;
            }
        }

        public DateTime DateTime
        {
            get
            {
                return _dateTime;
            }
        }
    }
}
