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
    public class UserPageController : Controller
    {
        private UserCategoriesDBcontext db = new UserCategoriesDBcontext();

        // GET: UserPage
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: UserPage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectedCategory userCategory = db.Categories.Find(id);
            if (userCategory == null)
            {
                return HttpNotFound();
            }
            return View(userCategory);
        }

        // GET: UserPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserPage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatUId,CatUName,CatUSelect")] SelectedCategory userCategory, string[] checkbox)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(userCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userCategory);
        }

        // GET: UserPage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectedCategory userCategory = db.Categories.Find(id);
            if (userCategory == null)
            {
                return HttpNotFound();
            }
            return View(userCategory);
        }

        // POST: UserPage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatUId,CatUName,CatUSelect")] SelectedCategory userCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userCategory);
        }

        // GET: UserPage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectedCategory userCategory = db.Categories.Find(id);
            if (userCategory == null)
            {
                return HttpNotFound();
            }
            return View(userCategory);
        }

        // POST: UserPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SelectedCategory userCategory = db.Categories.Find(id);
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
