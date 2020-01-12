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
        private ApplicationDbContext _context;

        // ovo moramo inicijalizirati u konstruktoru
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // DbContext je disposable objekt pa ga moramo dispose-ati to jest osloboditi memoriju...
        // OSLOBAĐA UNMANAGED RESURSE
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        //private List<Customer> customers = new List<Customer>()
        //    {
        //        new Customer {Name = "Ante Maršić", Id = 1},
        //        new Customer {Name = "Danica Maršić", Id = 2}
        //    };



        // GET: Customers
        // to list I singe or default metode odmag izvrsavaju upit...
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList(); ;
            return View(customers);
        }


        // to list I singe or default metode odmag izvrsavaju upit...
        public ActionResult Details(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Name = "Ante Maršić", Id = 1},
                new Customer {Name = "Danica Maršić", Id = 2}
            };
        }
    }
}