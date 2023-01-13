using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;

namespace WebEShopper.Areas.PrivatePages.Controllers
{
    public class ListProductController : Controller
    {
		// GET: PrivatePages/AllProduct
		private static BanHangOnlineConnect db = new BanHangOnlineConnect();
		
		// GET: PrivatePages/ListPost
		[HttpGet]
		public ActionResult Index()
		{
			List<sanPham> l = db.sanPhams.ToList<sanPham>();
			ViewData["dssanpham"] = l;
			return View();
		}
		[HttpPost]
		public ActionResult Active(string maSP)
		{
			sanPham x = db.sanPhams.Find(maSP);

			db.SaveChanges();
			List<sanPham> l = db.sanPhams.ToList<sanPham>();
			ViewData["dssanpham"] = l;
			return View("index");
		}
		[HttpPost]
		public ActionResult Delete(string maSP)
		{
			sanPham x = db.sanPhams.Find(maSP);
			
			db.sanPhams.Remove(x);

			db.SaveChanges(); 
			List<sanPham> l = db.sanPhams.ToList<sanPham>();
			ViewData["dssanpham"] = l;
			return View("index");
		}
	}
}