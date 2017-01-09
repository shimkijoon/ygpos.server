using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace YGPOS.REST.SERVER.Persistence
{
    public class BasePersistence
    {
        public SqlConnection sqlConnection;
        public SqlCommand sqlCommand;

        public BasePersistence()
        {
            sqlConnection = new SqlConnection("user id=ygserver;" +
                                              "password=yg@97!3;" +
                                              "server=localhost\\SQLEXPRESS;" +
                                              "Trusted_Connection=yes;" +
                                              "database=ygserver; " +
                                              "connection timeout=30");
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            try
            {
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}