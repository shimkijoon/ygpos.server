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
    public class StoreController : ApiController
    {
        // GET: api/Store
        public ArrayList Get()
        {
            StorePersistence storePersistence = new StorePersistence();
            return storePersistence.GetListAll();
        }

        // GET: api/Store/5
        public Store Get(int id)
        {
            StorePersistence storePersistence = new StorePersistence();
            return storePersistence.Get(id);
        }

        // POST: api/Store
        public HttpResponseMessage Post([FromBody]Store store)
        {
            if (ReferenceEquals(store, null).Equals(false))
            {
                Contact contact = new Contact();
                contact.zipcode = store.contact_store_zipcode;
                contact.country_name = store.contact_store_country;
                contact.state_name = store.contact_store_state;
                contact.city_name = store.contact_store_city;
                contact.street_name = store.contact_store_street;
                contact.street_no = store.contact_store_street_no;
                contact.address1 = store.contact_store_address1;
                contact.address2 = store.contact_store_address2;

                ContactPersistence contactPersistence = new ContactPersistence();
                try
                {
                    contactPersistence.Append(contact);
                }
                catch
                {
                }
                finally { }

                StorePersistence storePersistence = new StorePersistence();

                store.contact_id = contact.contact_id;
                storePersistence.Append(store);

                var response = Request.CreateResponse<Store>(HttpStatusCode.Created, store);

                string uri = Url.Link("DefaultApi", new { id = store.store_id });
                response.Headers.Location = new Uri(uri);
                return response;
            } else
            {
                var response = Request.CreateResponse<Store>(HttpStatusCode.BadRequest, store);
                return response;
            }
        }

        // PUT: api/Store/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Store/5
        public void Delete(int id)
        {
        }
    }
}
