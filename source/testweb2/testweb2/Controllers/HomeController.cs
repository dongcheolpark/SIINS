using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiinsWeb.Func;

namespace SiinsWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //홈화면 get
        {
            return View();
        }

        public ActionResult ClassError()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DownloadFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Files/";
            string fileName = "INCAL.apk";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + fileName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}