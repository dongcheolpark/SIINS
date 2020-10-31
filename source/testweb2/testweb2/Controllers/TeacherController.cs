using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SiinsWeb.Func;
using SiinsWeb.Models;


namespace SiinsWeb.Controllers
{
    public class TeacherController : Controller
    {
        private CategoryDBcontext db = new CategoryDBcontext();
        private UserCategoriesDBcontext db2 = new UserCategoriesDBcontext();
        private ClassNotiDBcontext db3 = new ClassNotiDBcontext();

        // GET: Teacher
        public ActionResult AddCat()
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Teacher))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }

                return View(db.Category.ToList());
            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
            }
        }

        [HttpPost]
        public ActionResult AddCat([Bind(Include ="CatId,CatName,CatAttribute")]Category category)
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Teacher))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }
                if (ModelState.IsValid)
                {
                    db.Category.Add(category);
                    db.SaveChanges();
                    return View(db.Category.ToList());
                }
                return View(db.Category.ToList());
            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
            }
        }

        public ActionResult ClassNoti()
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Teacher))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }

                return View("ClassNoti");
            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
            }
        }

       /* [HttpPost]
        public ActionResult ClassNoti(string ClassNotiText,string ClassNotiAttribute, string[] checkbox)
        {
            string strConn = "Data Source = icpu.club,14330; Initial Catalog = AfterSchool2019 - 1; Persist Security Info = True; User ID = inchang_s; Password = inchang_s ?";

            using (SqlConnection conn = new SqlConnection(strConn)) {
                string sql = @"INSERT INTO [dbo].[NotifyDB]([NotifyTime],[Type],[Content],[NotifyClass])VALUES(CONVERT(varchar(20), getDate(), 20),@type,@content,@classN)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                for (int i = 0; i < checkbox.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@type", ClassNotiText);
                    cmd.Parameters.AddWithValue("@content", ClassNotiAttribute);
                    cmd.Parameters.AddWithValue("@classN", int.Parse(checkbox[i]));
                    conn.Open();
                    cmd.ExecuteReader();
                    conn.Close();
                }
            }
            return View();
        }*/

        [HttpPost]
        public ActionResult ClassNoti(string ClassNotiText, string ClassNotiAttribute, string[] checkbox, string Emergency)
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Teacher))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }
                bool emr = false;
                if(Emergency == "true"){
                    emr = true;
                }
                string str = null;
                for (int i = 0; i < checkbox.Length; i++)
                {
                    ClassNoti a = new ClassNoti()
                    {
                        ClassNotiAttribute = ClassNotiAttribute,
                        ClassNoticlass = checkbox[i],
                        ClassNotiText = ClassNotiText,
                        ClassNotiTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        ClassNotiEmergency = emr
                    };
                    db3.ClassNotis.Add(a);
                }
                db3.SaveChanges();
                return View();
            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
            }
        }


        public ActionResult DeleteCat(int id)
        {
            try
            {
                if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Teacher))
                {
                    return RedirectToAction("PermitionEr", "Error");

                }
                var item = from a in db.Category.ToList()
                           where a.CatId == id
                           select a;
                var item2 = from a in db2.Categories.ToList()
                            where a.CatUSelect == id
                            select a;
                foreach (var a in item2)//사용자 카테고리 삭제
                {
                    db2.Categories.Remove(a);
                    db2.SaveChanges();
                }
                db.Category.Remove(item.First());//카테고리 삭제
                db.SaveChanges();
                return Redirect("~/Teacher/AddCat");
            }
            catch
            {
                return RedirectToAction("LoginEr", "Error");
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
