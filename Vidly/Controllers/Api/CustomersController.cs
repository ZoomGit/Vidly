﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        
        private ApplicationDbContext _context;
        public CustomersController()
        {
           
            _context = new ApplicationDbContext();
           
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
           
        }
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        

    }
}
