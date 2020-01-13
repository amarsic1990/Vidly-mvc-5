using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        private List<Movie> movies = new List<Movie>()
        {
            new Movie {Id = 1, Name ="Shrek!"},
            new Movie {Id = 2, Name ="LOTR"}
        };

        public ActionResult Index()
        {
            return View(_context.Movies.Include(m => m.Genre).ToList());
        }
        // GET: Movies/Random
        // vracamo instancu od klase koja nasljeduje iz ACTIONRESULT...

        public ActionResult Details(int? id)
        {
            return View(_context.Movies.SingleOrDefault(c => id == c.Id));
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };



            var customers = new List<Customer>()
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);


            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();

            // katkad kada redirectamo na akciju moramo passati argumente target akciji.... to radimo s anonimus objektom kao 3 argumentom
            // return RedirectToAction("Index", "Home", new { page = 1, sortby = "Name" });
        }

        // action parametri su inputi za akcije... mogu biti u URL, upitu ili u oblku podatka (id = 1)
        // https://localhost:44367/Movies/edit?id=1
        public ActionResult Edit(int id)
        {

            return Content("id: " + id);
        }

        // da bi parametar napravili opcionalnim moramo ga napraviti NULLABILNIM (za to stavljamo upitnik kraj data type-a)
        // STRING je sam po sebi NULLABILAN 
        // kada vracamo iz controllera koristiti view model to jest vratiti objekt ili view dictionary da vratimo key value parove
        // https://localhost:44367/Movies?pageindex=33&sortby=kkkkkkk
        public ActionResult Indexx(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        // kreiranje akcije za custom route
        // https://localhost:44367/Movies/Released/2015/12
        // sada smo enablali attribute routing pa mozemo dodati [Route]
        // bacit oko na attribute routing constraints
        // googleat: ASP.NET MVC Attribute Route Constraints

            [Route("Movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}

