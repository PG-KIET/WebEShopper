using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEShopper.Areas.PrivatePages.Controllers
{
    public class ListProductController : Controller
    {
        // GET: PrivatePages/AllProduct
        public ActionResult Index()
        {
            return View();
        }
    }
}