using MvcMovie.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testweb2.Func;
using testweb2.Models;

namespace testweb2.Controllers
{
    public class AdminController : Controller
    {
        private UserDBContext db = new UserDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Admin))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }

                return View();
            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
            }
        }
        public ActionResult upgrade()
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Admin))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }
                return View();
            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
            }
        }
        public ActionResult ViewDB()
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Admin))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }
                return View();
            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
            }
        }
        [HttpPost]
        public ActionResult ViewDB(string DbContext)
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Admin))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }
                HomeworkDBContext homeworkDB = new HomeworkDBContext();
                CommentDBContext commentDB = new CommentDBContext();
                UserDBContext userDB = new UserDBContext();
                CategoryDBContext categoryDB = new CategoryDBContext();
                UserCategoriesDBcontext userCategoriesDB = new UserCategoriesDBcontext();
                NoteCatDBContext noteCatDB = new NoteCatDBContext();
                ClassNotiDBcontext classNotiDB = new ClassNotiDBcontext();



                return View();
            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
            }
        }

        [HttpPost]
        public ActionResult upgrade(string UserId, string UserClass)
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Admin))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }

                var result = from a in db.Users.ToList()
                             where a.UserId == UserId
                             select a;
                foreach (var item in result)
                {
                    item.UserClass = UserClass;
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return Redirect("/home/");

            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
            }
        }

        public ActionResult Class()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Class(string class1,string class2,string class3)
        {
            JObject classd = new JObject(
                new JProperty("Class1", class1),
                new JProperty("Class2", class2),
                new JProperty("Class3", class3)
            );

            System.IO.File.WriteAllText(Server.MapPath("~/ClassData.json"), classd.ToString());
            return View();
        }
    }
}