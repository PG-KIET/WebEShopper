using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;

namespace WebEShopper.Areas.PrivatePages.Controllers
{
    public class ListProductInactiveController : Controller
    {
		// GET: PrivatePages/ListProductInacvive
		[HttpGet]
		public ActionResult Index()
		{
			List<sanPham> l = new BanHangOnlineConnect().sanPhams.Where(x => x.daDuyet == false).OrderBy(x => x.tenSP).ToList<sanPham>();
			ViewData["dssanpham"] = l;
			return View();
		}

	
	}
}