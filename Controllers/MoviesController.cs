using MvcMovie.Models;
using MvcMovie2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie2.Controllers
{
    public class MoviesController : Controller   // ← 여기!!! Controller 상속 필수!!
    {
        private MovieListContext db = new MovieListContext();

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = db.Movies.Find(id);  // Find(id)도 잘 돼요! ID가 PK니까

            if (movie == null)
            {
                return HttpNotFound();  // 또는 View("NotFound") 해도 돼
            }

            return View(movie);
        }
    }
}