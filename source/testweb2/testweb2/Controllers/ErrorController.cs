﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testweb2.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [Route("Error/CustomEr/{text}")]
        public ActionResult CustomEr(string text)
        {
            return View(text);
        }
        public ActionResult PermitionEr()
        {
            return View();
        }
        public ActionResult LoginEr()
        {
            return View();
        }
    }
}