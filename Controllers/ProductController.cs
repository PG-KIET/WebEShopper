using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;
using System.Data.Entity;

namespace WebsiteE_Shopper.Controllers
{
    public class ProductController : Controller
	{
		public ActionResult Index(int loaisp = 1)
		{
			BanHangOnlineConnect dbcontext = new BanHangOnlineConnect();
			List<sanPham> ListSanPhams = dbcontext.sanPhams
										 .Include(cat => cat.loaiSP)
										 .Where(pro => pro.maLoai == loaisp).ToList();
			return View(ListSanPhams);
		}
	}
}