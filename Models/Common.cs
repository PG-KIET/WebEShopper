using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebEShopper.Models
{
	public class Common
	{
		public static List<sanPham> GetSanPhams()
		{
			List<sanPham> sp = new List<sanPham>();

			DbContext context = new DbContext("name=BanHangOnlineConnect");

			sp = context.Set<sanPham>().ToList<sanPham>();

			return sp;
		}

		public static List<loaiSP> GetCategories() {
			List<loaiSP> lsp = new List<loaiSP>();

			DbContext context = new DbContext("name=BanHangOnlineConnect");

			lsp = context.Set<loaiSP>().ToList<loaiSP>();

			return lsp;
		}
	}
}