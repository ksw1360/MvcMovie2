using MvcMovie2;
using MvcMovie2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MvcMovie2.Controllers
{
    public class MoviesController : Controller   // ← 여기!!! Controller 상속 필수!!
    {
        private MovieListContext db = new MovieListContext();


        /// <summary>
        /// Movie List
        /// </summary>
        /// <returns></returns>
        // GET: /Movies/Index
        public ActionResult Index()
        {
            // 로그인 체크
            if (Session["IsLogin"] == null || (bool)Session["IsLogin"] == false)
            {
                // RedirectToAction 대신 이걸로 바꿈!
                return Redirect("/Account/Login");  // 직접 URL로 리다이렉트
            }

            // 기존 코드: 영화 목록
            return View(db.Movies.ToList());
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

        /// <summary>
        /// Movie Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = "Movie ID is required.";
                return HttpNotFound();
            }

            Movie movie = db.Movies.Find(id);  // Find(id)도 잘 돼요! ID가 PK니까

            if (movie == null)
            {
                return HttpNotFound();  // 또는 View("NotFound") 해도 돼
            }

            return View(movie);
        }

        /// <summary>
        /// Movie Insert
        /// </summary>
        /// <returns></returns>
        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Genre,Director,LeadActor,Size,Year,ReleaseDate,Runtime,Plot,Country,Language,PosterURL,Budget,Revenue")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.CreatedAt = DateTime.Now;
                movie.UpdatedAt = DateTime.Now;

                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        /// <summary>
        /// <Movie Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Movies/Edit/5  → 수정 폼 띄우기
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Movie movie = db.Movies.Find(id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);   // Views/Movies/Edit.cshtml 로 감
        }

        /// <summary>
        /// Movie Edit Post
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        // POST: Movies/Edit/5  → 수정 내용 저장
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Genre,Director,LeadActor,Size,Year,ReleaseDate,Runtime,Plot,Country,Language,PosterURL,Budget,Revenue")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.UpdatedAt = DateTime.Now;   // 수정 시간만 갱신

                db.Entry(movie).State = EntityState.Modified;  // ← 여기서 "이건 수정할 거야"라고 알려줌
                db.SaveChanges();                               // ← 여기서 UPDATE 쿼리 자동 실행!

                return RedirectToAction("Index");
            }
            return View(movie);   // 유효성 검사 실패하면 다시 폼 보여줌
        }

        /// <summary>
        /// Movie Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: /Movies/Delete/5  → 삭제 확인용 (지금 404 나는 이유)
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Movie movie = db.Movies.Find(id);
            if (movie == null) return HttpNotFound();

            db.Movies.Remove(movie);
            db.SaveChanges();

            //return View(movie);   // ← Views/Movies/Delete.cshtml 필요 없으면 아래 방식 추천!
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            var about = new About();
            return View(about);
        }

        public ActionResult Board()
        {
            return View();
        }
    }
}

