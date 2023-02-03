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

			sp = context.Set<sanPham>().OrderByDescending(z => z.ngayDang).ToList<sanPham>();

			return sp;
		}

		public static List<sanPham> GetSanPhamsbyId(int maLoai = 1)
		{
			List<sanPham> sp = new List<sanPham>();

			DbContext context = new DbContext("name=BanHangOnlineConnect");

			sp = context.Set<sanPham>().Include(cat => cat.loaiSP).Where(x => x.maLoai == maLoai).OrderByDescending(z => z.ngayDang).ToList<sanPham>();

			return sp;
		}

		public static List<loaiSP> GetCategories() {
			List<loaiSP> lsp = new List<loaiSP>();

			DbContext context = new DbContext("name=BanHangOnlineConnect");

			lsp = context.Set<loaiSP>().ToList<loaiSP>();

			return lsp;
		}

		public static List<sanPham> GetSanPhamsrandom()
		{
			List<sanPham> sp = new List<sanPham>();

			DbContext context = new DbContext("name=BanHangOnlineConnect");

			sp = context.Set<sanPham>().OrderBy(p => Guid.NewGuid()).Take(3).ToList<sanPham>();

			return sp;
		}
		public static sanPham GetProductbyId(string maSP)
		{
			DbContext context = new DbContext("name=BanHangOnlineConnect");
			return context.Set<sanPham>().Find(maSP);
		}
		public static string getNameOfProductbyId(string maSP)
		{
			DbContext context = new DbContext("name=BanHangOnlineConnect");
			return context.Set<sanPham>().Find(maSP).tenSP;
		}
		public static string getImageOfProductbyId(string maSP)
		{
			DbContext context = new DbContext("name=BanHangOnlineConnect");
			return context.Set<sanPham>().Find(maSP).hinhDD;
		}
	}
}