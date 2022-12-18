using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;

namespace WebEShopper.Areas.PrivatePages.Controllers
{
    public class ListPostController : Controller
    {
        private static bool isUpdate = false;
        // GET: PrivatePages/ListPost
        [HttpGet]
        public ActionResult Index()
        {
            List<loaiSP> l = new BanHangOnlineConnect().loaiSPs.OrderBy(x => x.loaiSP1).ToList<loaiSP>();
            ViewData["dsloai"] = l;
            return View();
        }
        [HttpPost]
       public ActionResult Index(loaiSP x)
        {
            BanHangOnlineConnect db= new BanHangOnlineConnect();
            if(!isUpdate)
                db.loaiSPs.Add(x);
            else
            {
                loaiSP y = db.loaiSPs.Find(x.maLoai);
                y.loaiSP1 = x.loaiSP1;
                y.ghiChu = x.ghiChu;
                isUpdate = false;
            }
            db.SaveChanges();

            if(ModelState.IsValid)
                ModelState.Clear();
            ViewData["dsloai"] = db.loaiSPs.OrderBy(c=> c.maLoai).ToList<loaiSP>();
            return View();
        }
        [HttpPost]
        public ActionResult detele(string ml)
        {
            BanHangOnlineConnect db = new BanHangOnlineConnect();
            int ma = int.Parse(ml);
            loaiSP x = db.loaiSPs.Find(ma);
            db.loaiSPs.Remove(x);
            db.SaveChanges();

            ViewData["dsloai"] = db.loaiSPs.OrderBy(c => c.maLoai).ToList<loaiSP>();
            return View("index");
		}
        [HttpPost]
        public ActionResult update(string mlcs)
        {
			BanHangOnlineConnect db = new BanHangOnlineConnect();
			int ma = int.Parse(mlcs);
            loaiSP x = db.loaiSPs.Find(ma);
            isUpdate = true;
            ViewData["dsloai"] = db.loaiSPs.OrderBy(c => c.maLoai).ToList<loaiSP>();
            return View("index", x);
		}
    }
}