using MvcMovie2.Models;
using System.Data.Entity;
using System.Linq;   // FirstOrDefault 쓰려고 추가
using System.Web.Mvc;

namespace MvcMovie2.Controllers
{
    public class AccountController : Controller
    {
        private MovieListContext db = new MovieListContext();

        // GET: Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: Account/Login - 진짜 DB로 로그인
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            Database.SetInitializer<MovieListContext>(null);

            if (ModelState.IsValid)
            {
                var allUsers = db.LogIn.ToList();

                if (allUsers.Count > 0)
                {
                    // DB에서 사용자 찾기                
                    var user = db.LogIn.FirstOrDefault(u => u.Id.Trim() == model.UserId.Trim() && u.Password.Trim() == model.Password.Trim());

                    if (user != null)
                    {
                        // 로그인 성공!
                        Session["IsLogin"] = true;
                        Session["UserId"] = user.Id;
                        Session["NickName"] = user.NickName ?? "사용자";

                        if (Url.IsLocalUrl(returnUrl))
                            return Redirect(returnUrl);
                        else
                            return RedirectToAction("Index", "Movies");
                    }
                    else
                    {
                        ModelState.AddModelError("", "아이디 또는 비밀번호가 틀렸습니다.");
                    }
                }
                else
                {
                    ModelState.AddModelError("로그인 유저 없음", "로그인 유저가 없습니다.");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}