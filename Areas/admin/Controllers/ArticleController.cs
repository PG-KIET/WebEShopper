﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEShopper.Areas.admin.Controllers
{
    public class ArticleController : Controller
    {
        // GET: admin/Article
        public ActionResult Index()
        {
            return View();
        }
    }
}