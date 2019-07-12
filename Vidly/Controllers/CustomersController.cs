using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel()
            {   Customer=new Customer(),
                MembershipTypes = membershiptypes
            };
            ViewBag.customer = "new";
            return View("CustomerForm", viewmodel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewmodel);
            }
            if (customer.CustomerId==0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.CustomerId == customer.CustomerId);
                customerInDb.CustomerName = customer.CustomerName;
                customerInDb.CustomerBirthGate = customer.CustomerBirthGate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=> c.MemershipType).ToList();
            return View(customers);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MemershipType).SingleOrDefault(c => c.CustomerId == id);
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel()
            {
                MembershipTypes = membershiptypes,

              Customer= customer
            };
            ViewBag.customer = "edit";
            return View("CustomerForm", viewmodel);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MemershipType).SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    var customers = new List<Customer>()
        //{
        //    new Customer() {CustomerId=1,CustomerName="Aly" },
        //    new Customer() {CustomerId=2,CustomerName="Aya" },
        //    new Customer() {CustomerId=3,CustomerName="hazem"}
        //};

        //    return customers;
        //}

    }
}
