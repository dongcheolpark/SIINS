using MvcMovie.Models;
using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using testweb2.Models;
using System.IO;
using System.Text;

namespace testweb2.Controllers
{
    public class UsersController : Controller
    {
        private UserDBContext db = new UserDBContext();//유저 DB
        private UserCategoriesDBcontext db2 = new UserCategoriesDBcontext();// 유저 카테고리 DB
        private CategoryDBcontext db3 = new CategoryDBcontext();//카테고리 DB

        // GET: Users/Create
        public ActionResult Create()
        {
            string text1 = System.IO.File.ReadAllText(Server.MapPath("~/ClassData.json"));
            JObject text = JObject.Parse(text1);

            Grade a = new Grade(
                (int)text["Class1"],
                (int)text["Class2"],
                (int)text["Class3"]
            );
            return View(new GradeData(a, db3.Category.ToList()));
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "UserId,UserPassword,UserName")] User user, string[] checkbox, string radio)
        {
            try
            {
                User result;
                if (ModelState.IsValid)
                {
                    user.UserClass = "Student";
                    user.UserPassword = Encryption.Encode(user.UserPassword);
                    user.UserGroup = int.Parse(radio);

                    db.Users.Add(user);
                    db.SaveChanges();
                    result = db.Users.Where(a => a.UserName == user.UserName).FirstOrDefault();
                    for (int i = 0; i < checkbox.Length; i++)
                    {
                        var cuser = new SelectedCategory() { CatUSelect = int.Parse(checkbox[i]), CatUNo = result.UserNo };
                        db2.Categories.Add(cuser);
                    }
                    db2.SaveChanges();
                }
                else return Redirect("~/home");

                Session["UserClass"] = result.UserClass;
                Session["UserId"] = result.UserId;
                Session["UserName"] = result.UserName;
                Session["UserNo"] = result.UserNo;
                Session["UserPw"] = result.UserPassword;
                Session["UserGr"] = result.UserGroup;
                return Redirect("~/home");

            }
            catch (Exception E)
            {
                return RedirectPermanent("~/Error/loginEr");
            }
        }

        public ActionResult Login()
        {
            if (Session["UserName"] != null)
            {
                return Redirect("~/home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "UserId,UserPassword")] User user, string btnSubmit)
        {
            try
            {
                switch (btnSubmit)
                {
                    case "login":

                        User result = null;
                        if (ModelState.IsValid)
                        {
                            var pw = user.UserPassword;
                            pw = Encryption.Encode(pw);
                            var iscorrect = from a in db.Users.ToList()
                                            where a.UserId == user.UserId
                                            where a.UserPassword == pw
                                            select a;
                            foreach (var i in iscorrect)
                            {
                                result = i;
                            }
                            if (result == null)
                            {
                                return View();
                            }


                        }
                        Session["UserClass"] = result.UserClass;
                        Session["UserName"] = result.UserName;
                        Session["UserId"] = result.UserId;
                        Session["UserNo"] = result.UserNo;
                        Session["UserPw"] = result.UserPassword;
                        Session["UserGr"] = result.UserGroup;
                        return Redirect("~/home");

                    case "logout":
                        Session["UserClass"] = null;
                        Session["UserName"] = null;
                        Session["UserNo"] = null;
                        Session["UserId"] = null;
                        Session["UserPw"] = null;
                        Session["UserGr"] = null;
                        return Redirect("~/home");

                    default:
                        return View();
                }
            }
            catch (Exception E)
            {
                return Redirect("~/Error/CustomEr?text=오류가 발생했습니다. 다시 입력해 주세요.");
            }
        }

        [HttpGet]
        public int Overlap(string userid)
        {
            var a = from b in db.Users.ToList()
                    where b.UserId == userid
                    select b;
            if (a.Count() == 0) return 1;
            else return 0;
        }


        public ActionResult Delete()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("LoginEr", "Error");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var a = from item in db.Users.ToList()
                        where item.UserNo == id
                        select item;
                var b = from item in db2.Categories.ToList()
                        where item.CatUNo == id
                        select item;
                foreach(var item in a)
                {
                    db.Users.Remove(item);
                }
                foreach (var item in b)
                {
                    db2.Categories.Remove(item);
                }
                db.SaveChanges();
                db2.SaveChanges();
                Session["UserClass"] = null;
                Session["UserName"] = null;
                Session["UserNo"] = null;
                Session["UserId"] = null;
                Session["UserPw"] = null;
                Session["UserGr"] = null;
            }
            return Redirect("~/home");
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

