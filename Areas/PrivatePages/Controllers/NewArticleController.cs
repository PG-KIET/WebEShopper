using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Areas.PrivatePages.Models;
using WebEShopper.Models;

namespace WebEShopper.Areas.PrivatePages.Controllers
{
    public class NewArticleController : Controller
    {
        // GET: PrivatePages/NewArticle
        [HttpGet]
        public ActionResult Index()
        {
            baiViet x = new baiViet();
            x.ngayDang = DateTime.Now;
            x.taiKhoan = ThuongDung.getTenTaiKhoan();   
            return View(x);
        }
        [HttpPost]
        public ActionResult Index(baiViet x, HttpPostedFileBase HinhDaiDien)
        {
            x.maBV = string.Format("{0:yyMMddhhmm}", DateTime.Now);
            x.daDuyet = false;
            x.ngayDang = DateTime.Now;
            x.taiKhoan = ThuongDung.getTenTaiKhoan();
            x.loaiTin = "QC";
            if (HinhDaiDien != null)
            {
                string virPath = "/images/blog";
                string phyPath = Server.MapPath(virPath);
                string ext = Path.GetExtension(HinhDaiDien.FileName);
                string tenF = "HDD" + x.maBV + ext;
                HinhDaiDien.SaveAs(phyPath + tenF);

                x.hinhDD = virPath + tenF;

                ViewBag.hinhDD = x.hinhDD;

            }
            else
                x.hinhDD = " ";
            BanHangOnlineConnect db = new BanHangOnlineConnect();
            db.baiViets.Add(x);
            db.SaveChanges();
            return View(x);
         
        }
    }
}