using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebEShopper.Models;

namespace WebEShopper.Areas.PrivatePages.Models
{
	public class ThuongDung
	{
		public static taiKhoanTV GetTaiKhoanHH()
		{
			taiKhoanTV kq = new taiKhoanTV();
			kq = HttpContext.Current.Session["TtDangNhap"] as taiKhoanTV;
			return kq;
		}
		public static string getTenTaiKhoan()
		{
			return GetTaiKhoanHH().taiKhoan;
		}
	}
}