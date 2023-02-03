using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShopper.Models;
using System.Data.Entity;   

namespace WebEShopper.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        [HttpGet]
        public ActionResult Index()
        {
            khachHang x = new khachHang();
            Cart gh = Session["GioHang"] as Cart;
            ViewData["Cart"] = gh;
            return View(x);
        }
        [HttpPost]
        public ActionResult saveToDataBase(khachHang x)
        {
            //--- sử dụng transaction để lưu đồng thời dữ liệu trên 3 table khác nhau
            using(var context = new BanHangOnlineConnect())
            {
                using(DbContextTransaction trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        //--- table KhachHang
                        x.maKH = x.soDT;
                        context.khachHangs.Add(x);
                        context.SaveChanges();
                        //--- table DonHang
                        donHang d = new donHang();
                        d.maKH = x.maKH;
                        d.soDH = string.Format("{0:yyMMdd}", DateTime.Now);
                        d.ngayDat = DateTime.Now;
                        d.ngayGH = DateTime.Now.AddDays(2);
                        d.taiKhoan = "admin";
                        d.diaChiGH= x.diaChi;   
                        context.donHangs.Add(d);
						context.SaveChanges();
                        //--- table CtDonHang
                        Cart gh = Session["GioHang"] as Cart;
                        foreach(ctDonHang i in gh.SanPhamDC.Values)
                        {
                            i.soDH = d.soDH;
                            context.ctDonHangs.Add(i);
                        }
                        context.SaveChanges();
                        //--- finish
						trans.Commit();
                        //--- Chuyển đến trang Home khi đặt hàng thành công
                        return RedirectToAction("Index", "Home");
                    }
                    catch(Exception e) 
                    {
                        trans.Rollback();
                    }
                }
            }
            return RedirectToAction("Index", "Checkout");
        }
    }
}