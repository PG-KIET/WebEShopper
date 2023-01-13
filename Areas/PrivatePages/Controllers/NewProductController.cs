using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;
using WebEShopper.Areas.PrivatePages.Models;
using System.IO;
using System.Drawing;
using System.Data.Entity;

namespace WebEShopper.Areas.PrivatePages.Controllers
{
    public class NewProductController : Controller
    {
        // GET: PrivatePages/NewProduct
        [HttpGet]
        public ActionResult Index()
        {
            sanPham x = new sanPham();
            x.ngayDang = DateTime.Now;
            x.taiKhoan = ThuongDung.getTenTaiKhoan();
            return View(x);
        }
        [HttpPost]
        public ActionResult Index(sanPham x, HttpPostedFileBase HinhDaiDien)
        {
            x.maSP = string.Format("{0:yyMMdd}", DateTime.Now);
            x.daDuyet = false;
            x.ngayDang = DateTime.Now;
            x.taiKhoan = ThuongDung.getTenTaiKhoan();

            if (HinhDaiDien != null)
            {
                string virPath = "/images/shop/";
                string phyPath = Server.MapPath("~/" + virPath);
                string ext = Path.GetExtension(HinhDaiDien.FileName);
                string tenF = "HDD" + x.maSP + ext;
                HinhDaiDien.SaveAs(phyPath + tenF);

                x.hinhDD = virPath + tenF;

                ViewBag.ddHinh = x.hinhDD;
            }
            else
                x.hinhDD = " ";
            BanHangOnlineConnect db = new BanHangOnlineConnect();
            db.sanPhams.Add(x);
            db.SaveChanges();
            return View(x);
        }
	}
}