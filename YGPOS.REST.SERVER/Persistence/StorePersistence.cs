using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using YGPOS.REST.SERVER.Models;

namespace YGPOS.REST.SERVER.Persistence
{
    public class StorePersistence : BasePersistence
    {
        public StorePersistence()
        {
        }

        private void SetObject(SqlDataReader sqlDataReader, Store store)
        {
            try
            {
                store.store_id = Convert.ToInt32(sqlDataReader["store_id"]);
                store.store_code = Convert.ToString(sqlDataReader["store_code"]);
                store.store_name = Convert.ToString(sqlDataReader["store_name"]);
                store.store_biz_no = Convert.ToString(sqlDataReader["store_biz_no"]);
                store.store_biz_type = Convert.ToString(sqlDataReader["store_biz_type"]);
                store.store_region = Convert.ToString(sqlDataReader["store_region"]);
                store.contact_id = Convert.ToInt32(sqlDataReader["contact_id"]);
                store.company_id = Convert.ToInt32(sqlDataReader["company_id"]);
                store.manager_id = Convert.ToInt32(sqlDataReader["manager_id"]);
                store.login_user = Convert.ToString(sqlDataReader["login_user"]);
                store.login_pwd = Convert.ToString(sqlDataReader["login_pwd"]);
                store.created_at = Convert.ToDateTime(sqlDataReader["created_at"]);
                store.updated_at = Convert.ToDateTime(sqlDataReader["updated_at"]);
                store.deleted_at = Convert.ToDateTime(sqlDataReader["deleted_at"]);
                store.is_deleted = Convert.ToBoolean(sqlDataReader["is_deleted"]);
            }
            catch
            {

            }
            finally { }
        }

        public ArrayList GetListAll()
        {
            ArrayList storeList = new ArrayList();

            sqlCommand.CommandText = "SELECT * FROM store";

            Store store = null;
            SqlDataReader sqlDataReader;
            try
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    store = new Store();
                    SetObject(sqlDataReader, store);
                    storeList.Add(store);
                }
            }
            finally { }

            return storeList;
        }

        public Store Get(int id)
        {
            sqlCommand.CommandText = "SELECT * FROM store WHERE store_id = @store_id";
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@store_id", id);

            Store store = null;
            SqlDataReader sqlDataReader;
            try
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                if(sqlDataReader.Read())
                {
                    store = new Store();
                    SetObject(sqlDataReader, store);
                }
            } finally { }

            return store;
        }

        public int Append(Store store)
        {
            if (ReferenceEquals(store, null))
                return 0;

            sqlCommand.CommandText =
                "INSERT INTO store (" +
                " store_code," +
                " store_name," +
                " store_biz_no," +
                " store_biz_type," +
                " store_region," +
                " contact_id," +
                " company_id," +
                " manager_id," +
                " login_user," +
                " login_pwd," +
                " created_at," +
                " updated_at," +
                " is_deleted" +
                ") OUTPUT INSERTED.store_id VALUES (" +
                " @store_code," +
                " @store_name," +
                " @store_biz_no," +
                " @store_biz_type," +
                " @store_region," +
                " @contact_id," +
                " @company_id," +
                " @manager_id," +
                " @login_user," +
                " @login_pwd," +
                " CURRENT_TIMESTAMP," +
                " CURRENT_TIMESTAMP," +
                " 0" +
                ")";

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@store_code", store.store_code);
            sqlCommand.Parameters.AddWithValue("@store_name", store.store_name);
            sqlCommand.Parameters.AddWithValue("@store_biz_no", store.store_biz_no);
            sqlCommand.Parameters.AddWithValue("@store_biz_type", store.store_biz_type);
            sqlCommand.Parameters.AddWithValue("@store_region", store.store_region);
            sqlCommand.Parameters.AddWithValue("@contact_id", store.contact_id);
            sqlCommand.Parameters.AddWithValue("@company_id", store.company_id);
            sqlCommand.Parameters.AddWithValue("@manager_id", store.manager_id);
            sqlCommand.Parameters.AddWithValue("@login_user", store.login_user);
            sqlCommand.Parameters.AddWithValue("@login_pwd", store.login_pwd);

            if (sqlCommand.Connection.State.Equals(ConnectionState.Closed))
                sqlCommand.Connection.Open();
            sqlCommand.Transaction = sqlCommand.Connection.BeginTransaction();

            try
            {
                store.store_id = (int)sqlCommand.ExecuteScalar();
                store.store_code = store.store_id.ToString("000000");

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

            return store.store_id;
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