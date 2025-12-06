using System.Linq;
using System.Web.Mvc;
using MvcMovie2.Models;

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
    }
}
