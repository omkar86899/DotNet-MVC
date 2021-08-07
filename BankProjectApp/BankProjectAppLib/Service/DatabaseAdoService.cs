using BankProjectAppLib.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BankProjectAppLib.Service
{
    public class DatabaseAdoService : IBankingService
    {
        private SqlConnection _sqlConnection;
        public DatabaseAdoService()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
        }

        public void CreateAccount(Account account)
        {
            SqlTransaction sqlTransaction;
            SqlCommand bankMasterCommand, transactionCommand;

            _sqlConnection.Open();
            sqlTransaction = _sqlConnection.BeginTransaction();

            bankMasterCommand = new SqlCommand("INSERT INTO BANK_MASTER VALUES(@Name, @Balance, @Password);",_sqlConnection);
            bankMasterCommand.Parameters.Add(new SqlParameter("@Name", account.Name));
            bankMasterCommand.Parameters.Add(new SqlParameter("@Balance", account.Balance));
            bankMasterCommand.Parameters.Add(new SqlParameter("@Password", account.Password));
            bankMasterCommand.Transaction = sqlTransaction;

            transactionCommand = new SqlCommand("INSERT INTO BANK_TRANSACTION VALUES(@Name, @Balance, 'D', GETDATE());",_sqlConnection);
            transactionCommand.Parameters.Add(new SqlParameter("@Name", account.Name));
            transactionCommand.Parameters.Add(new SqlParameter("@Balance", account.Balance));
            transactionCommand.Transaction = sqlTransaction;

            try
            {
                int noOfRowsAffectedInBankMaster, noOfRowsAffectedInBankTransaction;
                noOfRowsAffectedInBankMaster = bankMasterCommand.ExecuteNonQuery();
                noOfRowsAffectedInBankTransaction = transactionCommand.ExecuteNonQuery();

                if(noOfRowsAffectedInBankMaster < 1 || noOfRowsAffectedInBankTransaction < 1)
                {
                    throw new Exception("All Commands not Excecuted Properly");
                }
                sqlTransaction.Commit();
            }
            catch (SqlException exception)
            {
                sqlTransaction.Rollback();
                _sqlConnection.Close();
                if (exception.Number == 2627)
                {
                    throw new Exception("Name Already Exist");
                }
            }catch(Exception exception)
            {
                sqlTransaction.Rollback();
                _sqlConnection.Close();
            }
            _sqlConnection.Close();
        }

        public void Deposit(string name, double amount)
        {
            SqlTransaction sqlTransaction;
            SqlCommand bankMasterCommand, transactionCommand;

            _sqlConnection.Open();
            sqlTransaction = _sqlConnection.BeginTransaction();

            bankMasterCommand = new SqlCommand("UPDATE BANK_MASTER SET BALANCE = BALANCE + @Amount WHERE NAME=@Name;", _sqlConnection);
            bankMasterCommand.Parameters.Add(new SqlParameter("@Name", name));
            bankMasterCommand.Parameters.Add(new SqlParameter("@Amount", amount));
            bankMasterCommand.Transaction = sqlTransaction;

            transactionCommand = new SqlCommand("INSERT INTO BANK_TRANSACTION VALUES(@Name, @Amount, 'D', GETDATE());", _sqlConnection);
            transactionCommand.Parameters.Add(new SqlParameter("@Name", name));
            transactionCommand.Parameters.Add(new SqlParameter("@Amount", amount));
            transactionCommand.Transaction = sqlTransaction;

            try
            {
                int noOfRowsAffectedInBankMaster, noOfRowsAffectedInBankTransaction;
                noOfRowsAffectedInBankMaster = bankMasterCommand.ExecuteNonQuery();
                noOfRowsAffectedInBankTransaction = transactionCommand.ExecuteNonQuery();

                if (noOfRowsAffectedInBankMaster < 1 || noOfRowsAffectedInBankTransaction < 1)
                {
                    throw new Exception("All Commands not Excecuted Properly");
                }
                sqlTransaction.Commit();
            }
            catch(Exception exception)
            {
                sqlTransaction.Rollback();
                _sqlConnection.Close();
                throw new Exception("Transaction Unsuccessful");
            }
            _sqlConnection.Close();
        }

        public void Withdraw(string name, double amount)
        {
            SqlTransaction sqlTransaction;
            SqlCommand bankMasterCommand, transactionCommand;

            _sqlConnection.Open();
            sqlTransaction = _sqlConnection.BeginTransaction();

            bankMasterCommand = new SqlCommand("UPDATE BANK_MASTER SET BALANCE = BALANCE - @Amount WHERE NAME=@Name;", _sqlConnection);
            bankMasterCommand.Parameters.Add(new SqlParameter("@Name", name));
            bankMasterCommand.Parameters.Add(new SqlParameter("@Amount", amount));
            bankMasterCommand.Transaction = sqlTransaction;

            transactionCommand = new SqlCommand("INSERT INTO BANK_TRANSACTION VALUES(@Name, @Amount, 'W', GETDATE());", _sqlConnection);
            transactionCommand.Parameters.Add(new SqlParameter("@Name", name));
            transactionCommand.Parameters.Add(new SqlParameter("@Amount", amount));
            transactionCommand.Transaction = sqlTransaction;

            try
            {
                int noOfRowsAffectedInBankMaster, noOfRowsAffectedInBankTransaction;
                noOfRowsAffectedInBankMaster = bankMasterCommand.ExecuteNonQuery();
                noOfRowsAffectedInBankTransaction = transactionCommand.ExecuteNonQuery();

                if (noOfRowsAffectedInBankMaster < 1 || noOfRowsAffectedInBankTransaction < 1)
                {
                    throw new Exception("All Commands not Excecuted Properly");
                }
                sqlTransaction.Commit();
            }
            catch (Exception exception)
            {
                sqlTransaction.Rollback();
                _sqlConnection.Close();
                throw new Exception("Transaction Unsuccessful");
            }
            _sqlConnection.Close();
        }

        public Account GetAccountDetails(string name)
        {
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader;

            _sqlConnection.Open();
            sqlCommand = new SqlCommand("SELECT * FROM BANK_MASTER WHERE NAME = @Name; ",_sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("@Name", name));

            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                String accountname = sqlDataReader.GetString(0);
                double accountBalance = Convert.ToDouble(sqlDataReader.GetValue(1));
                String accountPassword = sqlDataReader.GetString(2);
                _sqlConnection.Close();
                return new Account(accountname, accountBalance, accountPassword);
            }
            _sqlConnection.Close();
            return new Account("", 0, "");
        }

        public List<Transaction> GetAccountTransactions(string name)
        {
            List<Transaction> transactions = new List<Transaction>();
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader;

            _sqlConnection.Open();

            sqlCommand = new SqlCommand("SELECT AMOUNT, TYPE, DATE FROM BANK_TRANSACTION WHERE NAME = @Name; ", _sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("@Name", name));

            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                TransactionType type = TransactionType.D;
                if (sqlDataReader.GetValue(1).ToString().Equals("W"))
                {
                    type = TransactionType.W;
                }
                Transaction transaction = new Transaction(Convert.ToDouble(sqlDataReader.GetValue(0)), type, sqlDataReader.GetDateTime(2));
                transactions.Add(transaction);
            }
            sqlDataReader.Close();
            _sqlConnection.Close();
            return transactions;
        }
    }
}
