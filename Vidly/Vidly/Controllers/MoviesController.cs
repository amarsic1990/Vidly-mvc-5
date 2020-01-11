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

            // katkad kada redirectamo moramo passati argumente target akciji.... to radimo s anonimus objektom kao 3 argumentom
            return RedirectToAction("Index", "Home", new { page = 1, sortby = "Name" });
        }
    }
}