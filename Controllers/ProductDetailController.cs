using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;

namespace WebsiteE_Shopper.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult Index(string MaSanPham)
        {
            BanHangOnlineConnect db = new BanHangOnlineConnect();
            sanPham sp = db.sanPhams.Where(x => x.maSP.Equals(MaSanPham)).First<sanPham>();
            ViewData["spcanxem"] = sp;
            return View();
        }


    }
}