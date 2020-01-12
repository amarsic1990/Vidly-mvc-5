using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        // vracamo instancu od klase koja nasljeduje iz ACTIONRESULT...
        public ActionResult Random()
        {

            var movie = new Movie() { Name = "Shrek!" };
            //return View(movie);
            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();

            // katkad kada redirectamo na akciju moramo passati argumente target akciji.... to radimo s anonimus objektom kao 3 argumentom
            return RedirectToAction("Index", "Home", new { page = 1, sortby = "Name" });
        }

        // action parametri su inputi za akcije... mogu biti u URL, upitu ili u oblku podatka (id = 1)
        // https://localhost:44367/Movies/edit?id=1
        public ActionResult Edit(int id)
        {

            return Content("id: " + id);
        }

        // da bi parametar napravili opcionalnim moramo ga napraviti NULLABILNIM (za to stavljamo upitnik kraj data type-a)
        // STRING je sam po sebi NULLABILAN 
        // https://localhost:44367/Movies?pageindex=33&sortby=kkkkkkk
        public ActionResult Index(int? pageIndex, string sortBy)
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
    }
}

