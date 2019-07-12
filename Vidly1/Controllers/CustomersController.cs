using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers(); 
                return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>()
        {
            new Customer() {CustomerId=1,CustomerName="Aly" },
            new Customer() {CustomerId=2,CustomerName="Aya" },
            new Customer() {CustomerId=3,CustomerName="hazem"}
        };

            return customers;
        }
        
    }
}
