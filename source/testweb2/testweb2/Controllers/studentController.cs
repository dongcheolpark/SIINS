using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testweb2.Func;
using testweb2.Models;

namespace testweb2.Controllers
{
    public class studentController : Controller
    {
        private UserCategoriesDBcontext db = new UserCategoriesDBcontext();
        private CategoryDBcontext db2 = new CategoryDBcontext();
        private ClassNotiDBcontext db3 = new ClassNotiDBcontext();
        private UserDBContext db4 = new UserDBContext();

        // GET: student
        public ActionResult Settings()
        {
            return View();
        }
        public ActionResult ChangeCat()
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Student))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }
                string text1 = System.IO.File.ReadAllText(Server.MapPath("~/ClassData.json"));
                JObject text = JObject.Parse(text1);

                Grade b = new Grade(
                    (int)text["Class1"],
                    (int)text["Class2"],
                    (int)text["Class3"]
                );

                StudentsModel model = new StudentsModel()
                {
                    category = db2.Category.ToList(),
                    userCategory = from a in db.Categories.ToList()
                                   where a.CatUNo == int.Parse(Session["UserNo"].ToString())
                                   select a,
                    grade = b
                };
                return View(model);
            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
            }
        }

        [HttpPost]
        public ActionResult ChangeCat(string[] checkbox,string radio)
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Student))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }

                var ab = from a in db.Categories.ToList()
                         where a.CatUNo == int.Parse(Session["UserNo"].ToString())
                         select a;
                foreach (var item in ab)
                {
                    db.Categories.Remove(item);
                    db.SaveChanges();
                }
                SelectedCategory abc = new SelectedCategory()
                {
                    CatUNo = int.Parse(Session["UserNo"].ToString()),

                };
                for (int i = 0; i < checkbox.Length; i++)
                {
                    abc.CatUSelect = int.Parse(checkbox[i]);
                    db.Categories.Add(abc);
                    db.SaveChanges();
                }
                int d = int.Parse(Session["UserNo"].ToString());
                var b = db4.Users.First(c => c.UserNo == d);
                b.UserGroup = int.Parse(radio);
                db4.SaveChanges();
                db.SaveChanges();
                Session["UserGr"] = radio;
                return RedirectToAction("Settings");
            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
            }
        }
        public ActionResult ClassNotiList()
        {
            return View(db3.ClassNotis.ToList());
        }
        [HttpPost]
        public ActionResult ClassNotiList(string Grade,string Class)
        {
            string str = Grade + "0" + Class;
            var a = from b in db3.ClassNotis.ToList()
                    where b.ClassNoticlass == str
                    select b;
            return View(a);
        }


        /*[HttpPost]
        public ActionResult ChangeCat()
        {
            return View();
        }*/

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
