using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private MyDBContext mdb = new MyDBContext();

        //GET /api/customers

        public IEnumerable<Customer> GetCustomers()
        {
            return mdb.Customers.ToList();
        }

        //GET /api/customers/1

        public Customer GetCustomer(int id)
        {
            var customer = mdb.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }

        // POST /api/customers

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            mdb.Customers.Add(customer);
            mdb.SaveChanges();

            return customer;

        }

        // PUT /api/customers/1

            [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerindb = mdb.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            customerindb.Birthdate = customer.Birthdate;
            customerindb.Name = customer.Name;
            customerindb.MembershipTypeId = customer.MembershipTypeId;
            customerindb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            mdb.SaveChanges();
        }

        // DELETE /api/customers/1

        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerindb = mdb.Customers.SingleOrDefault(c => c.Id == id);

            if (customerindb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            mdb.Customers.Remove(customerindb);
            mdb.SaveChanges();
        }
    }


}
