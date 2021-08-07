using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Employees.Model;

namespace EmployeesRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private SqlConnection _sqlConnection;
        public EmployeeRepository()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.AppSettings.Get("ConnectionString"));
        }

        public List<Employee> GetEmployees(int deptId)
        {
            List<Employee> employees = new List<Employee>();
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader;

            _sqlConnection.Open();

            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT EMP.ENAME ";
            sqlCommand.CommandText += "FROM DEPT ";
            sqlCommand.CommandText += "LEFT JOIN EMP ON EMP.DEPTNO = DEPT.DEPTNO ";
            sqlCommand.CommandText += "WHERE DEPT.DEPTNO = @DEPTNO;";
            sqlCommand.Parameters.Add(new SqlParameter("@DEPTNO", deptId));
            sqlCommand.Connection = _sqlConnection;

            sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                String empName = sqlDataReader.GetString(0);

                employees.Add(new Employee { EmpName = empName });
            }

            sqlDataReader.Close();
            _sqlConnection.Close();
            return employees;
        }
    }
}
