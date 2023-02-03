using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;

namespace WebsiteE_Shopper.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [HttpGet]
        public ActionResult Index()
        {
            //---- Lấy giỏ hàng từ Session
            Cart gh = Session["GioHang"] as Cart;
            //--- Truyền ra ngoài view
            ViewData["Cart"] = gh;
            return View();
        }
        public ActionResult Increase(string maSP)
        {
            Cart gh = Session["GioHang"] as Cart;
            gh.addItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
		public ActionResult Decrease(string maSP)
		{
			Cart gh = Session["GioHang"] as Cart;
			gh.decrease(maSP);
			Session["GioHang"] = gh;
			return RedirectToAction("Index");

		}
		public ActionResult RemoveItem(string maSP)
		{
			Cart gh = Session["GioHang"] as Cart;
			gh.deleteItem(maSP);
			Session["GioHang"] = gh;
			return RedirectToAction("Index");
		}
	}
}