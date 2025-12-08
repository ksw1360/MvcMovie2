using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DownloadApp()
        {
            // 1. 파일이 저장된 실제 경로 (프로젝트 내 App_Data 폴더나 별도 폴더 권장)
            // 예: 웹 루트의 'Downloads' 폴더 안에 파일이 있다고 가정
            string filePath = Server.MapPath("~/Downloads/app-debug.apk");
            string fileName = "app-debug.apk";

            // 2. 파일이 존재하는지 확인
            if (!System.IO.File.Exists(filePath))
            {
                return Content("파일을 찾을 수 없습니다.");
            }

            // 3. 파일 다운로드 실행 (MIME type: application/vnd.android.package-archive)
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/vnd.android.package-archive", fileName);
        }
    }
}