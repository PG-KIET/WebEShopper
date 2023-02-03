using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEShopper.Models
{
	public class Cart
	{
		public string MaKH { get; set; }
		public string TaiKhoan { get; set; }
		public DateTime NgayDat { get; set; }
		public DateTime NgayGiao { get; set; }
		public String DiaChi { get; set; }
		public SortedList<string, ctDonHang> SanPhamDC { get; set; }

		public Cart()
		{
			this.MaKH = "";
			this.TaiKhoan = "";
			this.NgayDat = DateTime.Now;
			this.NgayGiao = DateTime.Now.AddDays(2);
			this.DiaChi = "";
			this.SanPhamDC = new SortedList<string, ctDonHang>();
		}
		public bool IsEmpty()
		{
			return SanPhamDC.Keys.Count == 0;
		}
		public void addItem(string maSP)
		{
			if (SanPhamDC.Keys.Contains(maSP))
			{
				ctDonHang x = SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)];
				x.soLuong++;
			}
			else
			{
				ctDonHang y = new ctDonHang();
				y.maSP= maSP;
				y.soLuong = 1;
				sanPham z = Common.GetProductbyId(maSP);
				y.giaBan = z.giaBan;
				y.giamGia= z.giamGia; 
				SanPhamDC.Add(maSP, y);
			}
		}

		public void deleteItem(string maSP)
		{
			if (SanPhamDC.Keys.Contains(maSP))
			{
				SanPhamDC.Remove(maSP);
			}

		}
		public void decrease(string maSP)
		{
			if (SanPhamDC.Keys.Contains(maSP))
			{
				ctDonHang x = SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)];
				if(x.soLuong > 1)
				{
					x.soLuong--;
				
				}
				else
				{
					deleteItem(maSP);
				}
			}
		}
		public long moneyOfOneItem(ctDonHang x)
		{
			return (long)(x.giaBan * x.soLuong - (x.giaBan * x.soLuong * (x.giamGia/100)));
		}
		public long totalOfCart()
		{
			long kq = 0;
			foreach(ctDonHang i  in SanPhamDC.Values)
			{
				kq += moneyOfOneItem(i);
			}
			return kq;
		}
		
	}
}