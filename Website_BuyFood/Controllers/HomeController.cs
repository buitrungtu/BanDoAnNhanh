﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BuyFood.Common;
using Website_BuyFood.Models;
using Website_BuyFood.ViewModel;

namespace Website_BuyFood.Controllers
{
    public class HomeController : Controller
    {
        private MyDBContext context = new MyDBContext();
        public ActionResult Index()
        {
            return View();
        }
       
        public JsonResult DangNhap(TaiKhoan tk)
        {
            TaiKhoanDao tkd = new TaiKhoanDao();
            if(tkd.KiemTraDangNhap(tk) == true && ModelState.IsValid)
            {
                var userSesstion = new UserLogin();
                userSesstion.TenDangNhap = tk.TenDangNhap;
                Session.Add(CommonConstants.USER_SESSION, userSesstion);
                return Json(new {
                    status = true
                });
            }
            return Json(new {
                status = false
            });
        }
        public JsonResult DangKy(ThongTinDangKyTaiKhoan tk)
        {
            TaiKhoanDao tkd = new TaiKhoanDao();           
            if (tkd.DangKyTaiKhoan(tk.TenDangNhap,tk.MatKhau) == true && ModelState.IsValid)
            {
                KhachHangDao khd = new KhachHangDao();
                if(khd.ThemKhachHang(tk) == true)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản đã tồn tại");
            }
            return Json(new
            {
                status = false
            });
        }
        public ActionResult Menu()
        {
           
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }
    }
}