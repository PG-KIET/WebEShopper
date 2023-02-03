using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;

namespace WebsiteE_Shopper.Controllers
{
    public class BlogDetailController : Controller
    {
        // GET: BlogDetail
        public ActionResult Index(string maBV)
        {
            BanHangOnlineConnect db = new BanHangOnlineConnect();
            baiViet x = db.baiViets.Where(z => z.maBV== maBV).First<baiViet>();
            ViewData["BaiViet"] = x;
            return View();
        }
    }
}