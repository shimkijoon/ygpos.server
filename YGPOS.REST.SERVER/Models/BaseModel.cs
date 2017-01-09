using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YGPOS.REST.SERVER.Models
{
    public class BaseModel
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime deleted_at { get; set; }
        public bool is_deleted { get; set; }
    }
}