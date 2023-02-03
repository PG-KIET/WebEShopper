using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;

namespace WebEShopper.Areas.PrivatePages.Controllers
{
    public class ArticleController : Controller
    {
        private static BanHangOnlineConnect db = new BanHangOnlineConnect();
        private static bool daDuyet;
        [HttpGet]
        public ActionResult Index(string IsActive)
        {
            daDuyet = (IsActive.Equals("1"));
            CapNhatDuLieu(daDuyet);
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string maBaiViet)
        {
            baiViet x = db.baiViets.Find(maBaiViet);
            db.baiViets.Remove(x);
            db.SaveChanges();
            CapNhatDuLieu(daDuyet);

			return View("Index");
        }
        [HttpPost]
        public ActionResult Active(string maBaiViet)
        {
			baiViet x = db.baiViets.Find(maBaiViet);
            x.daDuyet = !daDuyet;
			db.SaveChanges();
			CapNhatDuLieu(daDuyet);
			return View("Index");
        }
        private void CapNhatDuLieu(bool IsActive)
        {
			List<baiViet> l = db.baiViets.Where(x => x.daDuyet == IsActive).ToList<baiViet>();
			ViewData["DanhSachBV"] = l;
            ViewBag.tdcuanut = daDuyet ? "Cấm hiển thị" : "Kích hoạt";
		}
    }
}