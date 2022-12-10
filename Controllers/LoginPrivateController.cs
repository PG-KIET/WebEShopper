using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEShopper.Controllers
{
    public class LoginPrivateController : Controller
    {
        // GET: LoginPrivate
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Account , string Password)
        {
            bool isAuthentic = (Account != null && Password != null && Account.Equals("giakietpham.2003@gmail.com") && Password.Equals("123456"));
            if (isAuthentic)
            {
                return RedirectToAction("Index" , "Dashboard" , new { Area = "PrivatePages"});
            }
            return View();
        }
    }
}