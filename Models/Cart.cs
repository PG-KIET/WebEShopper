using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEShopper.Models
{
	public class Cart
	{
		public sanPham sanPham { get; set; }

		public int Soluong { get; set; }

		public Cart(sanPham sanPham, int soluong)
		{
			this.sanPham = sanPham;
			Soluong = soluong;
		}
	}
}