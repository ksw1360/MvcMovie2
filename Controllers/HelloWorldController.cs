using MvcMovie.Models;
using MvcMovie2.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;   // 이게 핵심!

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        private MovieListContext db = new MovieListContext();

        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }
        
        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}