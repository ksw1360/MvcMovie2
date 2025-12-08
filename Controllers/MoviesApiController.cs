using MvcMovie2.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace MvcMovie2.Controllers
{
    public class MoviesApiController : Controller
    {
        private MovieListContext db = new MovieListContext();

        // 앱이 이 주소( /MoviesApi/GetMovies )로 접속하면 데이터를 줍니다.
        public ActionResult GetMovies()
        {
            db.Configuration.ProxyCreationEnabled = false; // JSON 변환 시 에러 방지용

            var list = db.Movies.OrderByDescending(m => m.ID).ToList();

            // View() 대신 Json()을 리턴합니다.
            // JsonRequestBehavior.AllowGet : 보안상 GET 요청을 허용한다는 뜻
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                // 1. 날짜가 비어있으면 오늘 날짜로
                if (movie.ReleaseDate == null) movie.ReleaseDate = DateTime.Now;

                // 2. DB에 저장
                db.Movies.Add(movie);
                db.SaveChanges();

                // 3. 성공했다는 신호(OK) 보내기
                return Json(new { success = true, message = "저장 완료!" });
            }

            // 실패하면 에러 메시지 보냄
            return Json(new { success = false, message = "데이터가 이상해요!" });
        }

        public ActionResult DeleteMovie(int? id)
        {
            var movie = db.Movies.Find(id);

            if (movie != null)
            {

                db.Movies.Remove(movie);
                db.SaveChanges();

                return Json(new { success = true, message = "삭제되었습니다." });
            }

            // 3. 없으면 실패
            return Json(new { success = false, message = "영화가 없는뎁쇼?" });
        }

        // ★ 4. 수정 (POST) - 여기를 이렇게 바꾸세요!
        [HttpPost]
        public ActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                // DB에 있는 기존 데이터를 가져옵니다.
                var existingMovie = db.Movies.Find(movie.ID);

                if (existingMovie != null)
                {
                    // 기존 데이터에 새 데이터를 덮어씌웁니다.
                    // (필요한 항목만 골라서 업데이트합니다)
                    existingMovie.Title = movie.Title;
                    existingMovie.Director = movie.Director;
                    existingMovie.LeadActor = movie.LeadActor;
                    existingMovie.Year = movie.Year;
                    existingMovie.PosterURL = movie.PosterURL;
                    existingMovie.Plot = movie.Plot;

                    // 변경사항 저장
                    db.SaveChanges();

                    return Json(new { success = true, message = "수정 완료!" });
                }
                else
                {
                    return Json(new { success = false, message = "수정할 영화를 못 찾았어요." });
                }
            }

            return Json(new { success = false, message = "입력 데이터가 이상해요." });
        }
    }
}
