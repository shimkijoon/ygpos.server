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
    public class ContactPersistence : BasePersistence
    {
        private void SetObject(SqlDataReader sqlDataReader, Contact contact)
        {
            try
            {
                contact.contact_id = Convert.ToInt32(sqlDataReader["contact_id"]);
                contact.country_code = Convert.ToString(sqlDataReader["country_code"]);
                contact.country_name = Convert.ToString(sqlDataReader["country_name"]);
                contact.zipcode = Convert.ToString(sqlDataReader["zipcode"]);
                contact.state_code = Convert.ToString(sqlDataReader["state_code"]);
                contact.state_name = Convert.ToString(sqlDataReader["state_name"]);
                contact.city_code = Convert.ToString(sqlDataReader["city_code"]);
                contact.city_name = Convert.ToString(sqlDataReader["city_name"]);
                contact.street_code = Convert.ToString(sqlDataReader["street_code"]);
                contact.street_name = Convert.ToString(sqlDataReader["street_name"]);
                contact.street_no = Convert.ToString(sqlDataReader["street_no"]);
                contact.address1 = Convert.ToString(sqlDataReader["address1"]);
                contact.address2 = Convert.ToString(sqlDataReader["address2"]);
                contact.phone_number1 = Convert.ToString(sqlDataReader["phone_number1"]);
                contact.phone_number2 = Convert.ToString(sqlDataReader["phone_number2"]);
                contact.fax_number = Convert.ToString(sqlDataReader["fax_number"]);
                contact.email_address = Convert.ToString(sqlDataReader["email_address"]);
                contact.created_at = Convert.ToDateTime(sqlDataReader["created_at"]);
                contact.updated_at = Convert.ToDateTime(sqlDataReader["updated_at"]);
                contact.deleted_at = Convert.ToDateTime(sqlDataReader["deleted_at"]);
                contact.is_deleted = Convert.ToBoolean(sqlDataReader["is_deleted"]);
            }
            catch
            {

            }
            finally { }
        }

        public ArrayList GetListAll()
        {
            ArrayList storeList = new ArrayList();

            sqlCommand.CommandText = "SELECT * FROM contact";

            Contact contact = null;
            SqlDataReader sqlDataReader;
            try
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    contact = new Contact();
                    SetObject(sqlDataReader, contact);
                    storeList.Add(contact);
                }
            }
            finally { }

            return storeList;
        }

        public Contact Get(int id)
        {
            sqlCommand.CommandText = "SELECT * FROM contact WHERE contact_id = @contact_id";
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@contact_id", id);

            Contact contact = null;
            SqlDataReader sqlDataReader;
            try
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    contact = new Contact();
                    SetObject(sqlDataReader, contact);
                }
            }
            finally { }

            return contact;
        }

        public int Append(Contact contact)
        {
            if (ReferenceEquals(contact, null))
                return 0;

            sqlCommand.CommandText =
                "INSERT INTO contact (" +
                "  country_code, " +
                "  country_name, " +
                "  zipcode, " +
                "  state_code, " +
                "  state_name, " +
                "  city_code, " +
                "  city_name, " +
                "  street_code, " +
                "  street_name, " +
                "  street_no, " +
                "  address1, " +
                "  address2, " +
                "  phone_number1, " +
                "  phone_number2, " +
                "  fax_number, " +
                "  email_address, " +
                "  created_at, " +
                "  updated_at, " +
                "  is_deleted " +
                ") OUTPUT INSERTED.contact_id VALUES (" +
                "  @country_code, " +
                "  @country_name, " +
                "  @zipcode, " +
                "  @state_code, " +
                "  @state_name, " +
                "  @city_code, " +
                "  @city_name, " +
                "  @street_code, " +
                "  @street_name, " +
                "  @street_no, " +
                "  @address1, " +
                "  @address2, " +
                "  @phone_number1, " +
                "  @phone_number2, " +
                "  @fax_number, " +
                "  @email_address, " +
                " CURRENT_TIMESTAMP," +
                " CURRENT_TIMESTAMP," +
                " 0" +
                ")";

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@country_code", contact.country_code);
            sqlCommand.Parameters.AddWithValue("@country_name", contact.country_name);
            sqlCommand.Parameters.AddWithValue("@zipcode", contact.zipcode);
            sqlCommand.Parameters.AddWithValue("@state_code", contact.state_code);
            sqlCommand.Parameters.AddWithValue("@state_name", contact.state_name);
            sqlCommand.Parameters.AddWithValue("@city_code", contact.city_code);
            sqlCommand.Parameters.AddWithValue("@city_name", contact.city_name);
            sqlCommand.Parameters.AddWithValue("@street_code", contact.street_code);
            sqlCommand.Parameters.AddWithValue("@street_name", contact.street_name);
            sqlCommand.Parameters.AddWithValue("@street_no", contact.street_no);
            sqlCommand.Parameters.AddWithValue("@address1", contact.address1);
            sqlCommand.Parameters.AddWithValue("@address2", contact.address2);
            sqlCommand.Parameters.AddWithValue("@phone_number1", contact.phone_number1);
            sqlCommand.Parameters.AddWithValue("@phone_number2", contact.phone_number2);
            sqlCommand.Parameters.AddWithValue("@fax_number", contact.fax_number);
            sqlCommand.Parameters.AddWithValue("@email_address", contact.email_address);

            if (sqlCommand.Connection.State.Equals(ConnectionState.Closed))
                sqlCommand.Connection.Open();
            sqlCommand.Transaction = sqlCommand.Connection.BeginTransaction();

            try
            {
                contact.contact_id = (int)sqlCommand.ExecuteScalar();

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

            return contact.contact_id;
        }

        public int Update(Contact contact)
        {
            return 0;
        }

        public int Delete(int store_id)
        {
            return 0;
        }
    }
}