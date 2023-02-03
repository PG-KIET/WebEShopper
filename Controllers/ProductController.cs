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
		BanHangOnlineConnect DbContext = new BanHangOnlineConnect();

		public ActionResult Index(int categoryId = 1)
		{

			List<sanPham> Listproducts = DbContext.sanPhams
							.Include(cat => cat.loaiSP)
							.Where(pro => pro.maLoai == categoryId).ToList();
			return View(Listproducts);
		}
	}
}