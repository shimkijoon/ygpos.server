using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using YGPOS.REST.SERVER.Models;

namespace YGPOS.REST.SERVER.Persistence
{
    public class EmployeePersistence : BasePersistence
    {
        private void SetObject(SqlDataReader sqlDataReader, Employee employee)
        {
            try
            {
                employee.employee_id = Convert.ToInt32(sqlDataReader["employee_id"]);
                employee.employee_name = Convert.ToString(sqlDataReader["employee_name"]);
                employee.employee_position = Convert.ToString(sqlDataReader["employee_position"]);
                employee.store_id = Convert.ToInt32(sqlDataReader["store_id"]);
                employee.login_user = Convert.ToString(sqlDataReader["login_user"]);
                employee.login_pwd = Convert.ToString(sqlDataReader["login_pwd"]);
                employee.created_at = Convert.ToDateTime(sqlDataReader["created_at"]);
                employee.updated_at = Convert.ToDateTime(sqlDataReader["updated_at"]);
                employee.deleted_at = Convert.ToDateTime(sqlDataReader["deleted_at"]);
                employee.is_deleted = Convert.ToBoolean(sqlDataReader["is_deleted"]);
            }
            catch
            {

            }
            finally { }
        }

    public ArrayList GetListAll()
        {
            ArrayList employeeList = new ArrayList();

            sqlCommand.CommandText =
                "SELECT " +
                "  employee_id, " +
                "  employee_name, " +
                "  employee_position, " +
                "  store_id, " +
                "  login_user, " +
                "  login_pwd, " +
                "  created_at, " +
                "  updated_at, " +
                "  deleted_at, " +
                "  is_deleted " +
                "FROM Employee";

            Employee employee = null;
            SqlDataReader sqlDataReader;
            try
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    employee = new Employee();
                    SetObject(sqlDataReader, employee);
                    employeeList.Add(employee);
                }
            }
            finally { }

            return employeeList;
        }

        public Employee Get(int id)
        {
            sqlCommand.CommandText = 
                "SELECT " +
                "  employee_id, " +
                "  employee_name, " +
                "  employee_position, " +
                "  store_id, " +
                "  login_user, " +
                "  login_pwd, " +
                "  created_at, " +
                "  updated_at, " +
                "  deleted_at, " +
                "  is_deleted " +
                "FROM Employee  " + 
                "WHERE employee_id = @employee_id";

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@employee_id", id);

            Employee employee = null;
            SqlDataReader sqlDataReader;
            try
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    employee = new Employee();
                    SetObject(sqlDataReader, employee);
                }
            }
            finally { }

            return employee;
        }

        public int Append(Employee employee)
        {
            if (ReferenceEquals(employee, null))
                return 0;

            sqlCommand.CommandText =
                "INSERT INTO employee (" +
                " employee_name," +
                " employee_position," +
                " store_id," +
                " login_user, " +
                " login_pwd, " +
                " created_at," +
                " updated_at," +
                " is_deleted" +
                ") OUTPUT INSERTED.employee_id VALUES (" +
                " @employee_name," +
                " @employee_position," +
                " @store_id," +
                " @login_user, " +
                " @login_pwd, " +
                " CURRENT_TIMESTAMP," +
                " CURRENT_TIMESTAMP," +
                " 0" +
                ")";

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@employee_name", employee.employee_name);
            sqlCommand.Parameters.AddWithValue("@employee_position", employee.employee_position);
            sqlCommand.Parameters.AddWithValue("@store_id", employee.store_id);
            sqlCommand.Parameters.AddWithValue("@login_user", employee.login_user);
            sqlCommand.Parameters.AddWithValue("@login_pwd", employee.login_pwd);

            if (sqlCommand.Connection.State.Equals(ConnectionState.Closed))
                sqlCommand.Connection.Open();
            sqlCommand.Transaction = sqlCommand.Connection.BeginTransaction();

            try
            {
                employee.employee_id = (int)sqlCommand.ExecuteScalar();

                sqlCommand.Transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught exception: " + ex.Message);
                sqlCommand.Transaction.Rollback();
            }
            finally
            {
                if (!sqlCommand.Connection.State.Equals(ConnectionState.Closed))
                    sqlCommand.Connection.Close();
            }

            return employee.employee_id;
        }

        public int Update(Store store)
        {
            return 0;
        }

        public int Delete(int store_id)
        {
            return 0;
        }
    }
}