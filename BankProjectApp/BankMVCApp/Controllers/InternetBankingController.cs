using BankMVCApp.Models;
using BankMVCApp.Models.ViewModels;
using BankProjectAppLib.Data;
using BankProjectAppLib.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace BankMVCApp.Controllers
{
    [LogFilter]
    public class InternetBankingController : Controller
    {
        private IBankingService _bankingService;
        public InternetBankingController(IBankingService bankingService)
        {
            _bankingService = bankingService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            DoTransactionViewModel vm = new DoTransactionViewModel();
            return View(vm) ;
        }

        [HttpPost]
        public ActionResult Index(DoTransactionViewModel vm)
        {
            if (!this.ModelState.IsValid)
            {
                return View(vm);
            }
            try
            {
                if (vm.TransactionType.Equals('D'))
                {
                    _bankingService.Deposit(Session["Name"].ToString(), vm.Amount);
                }
                if (vm.TransactionType.Equals('W'))
                {
                    _bankingService.Withdraw(Session["Name"].ToString(), vm.Amount);
                }
            }
            catch (Exception exception)
            {
                vm.Error = exception.Message;
                return View(vm);
            }
            vm.TransactionSuccessfulMessage = "Transaction Successful";
            return View(vm);
        }

        public ActionResult ViewPassbook()
        {
            ViewPassbookViewModel vm = new ViewPassbookViewModel();
            vm.Transactions = _bankingService.GetAccountTransactions(Session["Name"].ToString());
            return View(vm);
        }

        public void Export()
        {
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"Amount\",\"TransactionType\",\"Time\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Exported_Users.csv");
            Response.ContentType = "text/csv";

            foreach (Transaction transaction in _bankingService.GetAccountTransactions(Session["Name"].ToString()))
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\"",
                                           transaction.Amount,
                                           transaction.Type,
                                           transaction.DateTime));
            }

            Response.Write(sw.ToString());

            Response.End();
        }

        public ActionResult Logout()
        {
            Session["Name"] = null;
            return RedirectToAction("index");
        }
    }
}