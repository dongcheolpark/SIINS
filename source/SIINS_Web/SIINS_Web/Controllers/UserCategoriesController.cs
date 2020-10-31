using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testweb2.Models;

namespace testweb2.Controllers
{
    public class UserCategoriesController : Controller
    {
        private UserCategoriesDBcontext db = new UserCategoriesDBcontext();

        // GET: UserCategories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: UserCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCategory userCategory = db.Categories.Find(id);
            if (userCategory == null)
            {
                return HttpNotFound();
            }
            return View(userCategory);
        }

        // GET: UserCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCategories/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatUId,CatUName,CatUSelect")] UserCategory userCategory)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(userCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userCategory);
        }

        // GET: UserCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCategory userCategory = db.Categories.Find(id);
            if (userCategory == null)
            {
                return HttpNotFound();
            }
            return View(userCategory);
        }

        // POST: UserCategories/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatUId,CatUName,CatUSelect")] UserCategory userCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userCategory);
        }

        // GET: UserCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCategory userCategory = db.Categories.Find(id);
            if (userCategory == null)
            {
                return HttpNotFound();
            }
            return View(userCategory);
        }

        // POST: UserCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserCategory userCategory = db.Categories.Find(id);
            db.Categories.Remove(userCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
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
