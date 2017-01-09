using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YGPOS.REST.SERVER.Models
{
    public class Contact : BaseModel
    {
        public int contact_id { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string zipcode { get; set; }
        public string state_code { get; set; }
        public string state_name { get; set; }
        public string city_code { get; set; }
        public string city_name { get; set; }
        public string street_code { get; set; }
        public string street_name { get; set; }
        public string street_no { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string phone_number1 { get; set; }
        public string phone_number2 { get; set; }
        public string fax_number { get; set; }
        public string email_address { get; set; }

        public Contact()
        {
            InitValue();
        }

        private void InitValue()
        {
            contact_id = 0;
            country_code = "";
            country_name = "";
            zipcode = "";
            state_code = "";
            state_name = "";
            city_code = "";
            city_name = "";
            street_code = "";
            street_name = "";
            street_no = "";
            address1 = "";
            address2 = "";
            phone_number1 = "";
            phone_number2 = "";
            fax_number = "";
            email_address = "";
        }
    }
}