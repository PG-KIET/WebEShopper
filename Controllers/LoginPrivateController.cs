using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;

namespace WebEShopper.Controllers
{
    public class LoginPrivateController : Controller
    {
        // GET: LoginPrivate
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Index(string Account, string Password)
		{
			taiKhoanTV ttdn = new BanHangOnlineConnect()
							.taiKhoanTVs.Where(x => x.taiKhoan.Equals(Account.ToLower().Trim()) && x.matKhau.Equals(Password)).First<taiKhoanTV>();
			bool isAuthentic = ttdn != null;
			if (isAuthentic)
			{
				Session["TtDangNhap"] = ttdn;
				return RedirectToAction("Index", "Dashboard", new { Area = "PrivatePages" });
			}
			return View();
		}
	}
}