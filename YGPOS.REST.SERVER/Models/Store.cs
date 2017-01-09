using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YGPOS.REST.SERVER.Models
{
    public class Store : BaseModel
    {
        public int store_id { get; set; }
        public string store_code { get; set; }
        public string store_name { get; set; }
        public string store_biz_no { get; set; }
        public string store_biz_type { get; set; }
        public string store_region { get; set; }
        public int contact_id { get; set; }
        public int company_id { get; set; }
        public int manager_id { get; set; }
        public string login_user { get; set; }
        public string login_pwd { get; set; }

        public string contact_store_zipcode { get; set; }
        public string contact_store_country { get; set; }
        public string contact_store_state { get; set; }
        public string contact_store_city { get; set; }
        public string contact_store_street { get; set; }
        public string contact_store_street_no { get; set; }
        public string contact_store_address1 { get; set; }
        public string contact_store_address2 { get; set; }
    }
}