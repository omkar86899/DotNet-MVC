using BankProjectAppLib.Data;
using System.Collections.Generic;

namespace BankMVCApp.Models.ViewModels
{
    public class ViewPassbookViewModel
    {
        public List<Transaction> Transactions
        {
            get;
            set;
        }
    }
}