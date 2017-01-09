using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YGPOS.REST.SERVER.Models
{
    public class Employee : BaseModel
    {
        public int employee_id { get; set; }
        public int store_id { get; set; }
        public string employee_name { get; set; }
        public string employee_position { get; set; }
        public string login_user { get; set; }
        public string login_pwd { get; set; }
    }
}