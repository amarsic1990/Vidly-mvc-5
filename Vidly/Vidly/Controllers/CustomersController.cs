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

        private List<Customer> customers = new List<Customer>()
            {
                new Customer {Name = "Ante Maršić", Id = 1},
                new Customer {Name = "Danica Maršić", Id = 2}
            };

        // GET: Customers
        public ActionResult Index()
        {
            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            var customer = customers.SingleOrDefault(c => c.Id == id);

            return View(customer);
        }
    }
}