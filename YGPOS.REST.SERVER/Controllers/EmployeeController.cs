using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;
using YGPOS.REST.SERVER.Models;
using YGPOS.REST.SERVER.Persistence;

namespace YGPOS.REST.SERVER.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        public ArrayList Get()
        {
            EmployeePersistence employeePersistence = new EmployeePersistence();
            return employeePersistence.GetListAll();
        }

        // GET: api/Employee/5
        public Employee Get(int id)
        {
            EmployeePersistence employeePersistence = new EmployeePersistence();
            return employeePersistence.Get(id);
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
