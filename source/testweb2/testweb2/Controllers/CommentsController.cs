using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace testweb2.Controllers
{
    public class CommentsController : Controller
    {
        private CommentDBContext db = new CommentDBContext();

        [ChildActionOnly]
        public ActionResult comment(int NoteNo)
        {
            var item = from a in db.Comment.ToList()
                       where a.ParentNo == NoteNo
                       select a;
            ViewBag.NoteNo = NoteNo;
            ViewBag.CommentsCount = item.Count();
            return View(item);
        }
        [HttpPost]
        public ActionResult Delete(int CommentNo)
        {
            var comment = from a in db.Comment.ToList()
                          where a.CommentNo == CommentNo
                          select a;
            int No = comment.First().ParentNo;
            db.Comment.Remove(comment.First());
            db.SaveChanges();
            return Redirect("~/Homework/details/" + No);
        }

        [HttpPost]
        public ActionResult Create(string contents, int NoteNo)
        {
            try
            {
                var com = new Comment() { ParentNo = NoteNo, CommentContents = contents, UserName = Session["UserName"].ToString() };
                db.Comment.Add(com);
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }

            catch (Exception E)
            {
                return Redirect("~/users/error");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
