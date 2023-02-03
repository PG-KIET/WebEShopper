using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;

namespace WebsiteE_Shopper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart(string maSP)
        {
            Cart gh = Session["GioHang"] as Cart;
            gh.addItem(maSP);
            Session["GioHang"] = gh;
            return View("index");
        }
    }
}