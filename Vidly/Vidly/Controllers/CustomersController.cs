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
        // to list metoda I singe or default metoda odmah izvrsavaju upit...
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); ;
            return View(customers);
        }


        // to list I singe or default metode odmag izvrsavaju upit...
        public ActionResult Details(int? id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }


        //za kreiranje forme za dodavanje kupaca prvo trebamo akciju...
        //ta akcija mora ukljicivati VIEW koji sadrzi tu formu...
        public ActionResult New()
        {
            // ovde cemo morati kreirati view model
            var membershipTypes = _context.MembershipTypes.ToList();

            // samo typove vracamo u viewu a odabrani type i customerove podatke cemo valjda priko ovog viewa spremit u bazu...
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        // ako su akcije modificiranje podataka ne bi trebale biti dostupne HTTPGETu
        // mvc automatski mapira REQUEST PODATKE objektu viewModel-u ili kako smo vec dali ime parametru
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            // da bi dodali kupca u bazu prvo ga moramo dodati u DbContext
            // ovo u DbContextu je samo u memoriji
            _context.Customers.Add(customer);

            // da bi spremili promjene zovemo save changes
            // ovo je u transakciji ili će sve proć ili će puknit
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            // view new vraca model: "NewCustomerViewModel"
            var viewmodel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            // prije smo vracali view new sada moramo overwriteati taj view
            return View("CustomerForm", viewmodel);
            
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