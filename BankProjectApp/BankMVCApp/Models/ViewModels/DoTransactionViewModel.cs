using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankMVCApp.Models.ViewModels
{
    public class DoTransactionViewModel
    {
        [Required(ErrorMessage = "Pleas enter Amount")]
        [Range(1,double.MaxValue, ErrorMessage = "Amount should be in Positive")]
        public double Amount
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please Select Transaction type")]
        public Char TransactionType
        {
            get;
            set;
        }

        public String TransactionSuccessfulMessage
        {
            get;
            set;
        }

        public String Error
        {
            get;
            set;
        }
    }
}