using System.Diagnostics;
using MvcMovie2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie2.Controllers
{
    public class BoardController : Controller
    {
        // ★★★ 가장 중요! ★★★
        // "new Board()"가 아니라 "new MovieListContext()"여야 
        // 진짜 DB(Web.config에 연결된 그놈)에 있는 데이터를 가져옵니다.
        private MovieListContext db = new MovieListContext();

        // 1. 게시판 메인 화면 (페이지 들어가자마자 실행됨)
        [HttpPost]
        public ActionResult Index()
        {
            // DB에 있는 모든 글을 가져와서 -> 번호 역순(최신글 위로)으로 정렬해서 -> 리스트로 만듦
            var list = db.Boards.OrderByDescending(b => b.BoardId).ToList();
            if (list == null || list.Count == 0)
            {
                TempData["Msg"] = "게시글이 없슈";
                Debug.WriteLine("게시글이 없슈");
            }
            // 뷰(화면)에 데이터를 던져줌 -> 이러면 들어가자마자 바로 뜸!
            return View(list);
        }

        // 2. 글쓰기 저장 (등록 버튼 눌렀을 때 실행됨)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Content,Writer")] Board board)
        {
            if (ModelState.IsValid)
            {
                board.RegDate = DateTime.Now;
                board.ViewCount = 0;

                db.Boards.Add(board);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // 3. 상세 보기 (제목 클릭했을 때 실행됨)
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Board board = db.Boards.Find(id);
            if (board == null) return HttpNotFound();

            // 조회수 1 증가
            board.ViewCount++;
            db.Entry(board).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return View(board);
        }

        // 4. 수정 화면 (수정 버튼 눌렀을 때)
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Board board = db.Boards.Find(id);
            if (board == null) return HttpNotFound();
            return View(board);
        }

        // 5. 수정 저장 (수정 완료 눌렀을 때)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardId,Title,Content,Writer,ViewCount,RegDate")] Board board)
        {
            if (ModelState.IsValid)
            {
                db.Entry(board).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = board.BoardId });
            }
            return View(board);
        }

        // 6. 삭제 (삭제 버튼 눌렀을 때)
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Board board = db.Boards.Find(id);
            if (board == null) return HttpNotFound();

            db.Boards.Remove(board);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}