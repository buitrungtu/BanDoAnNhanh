﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_BuyFood.Models
{
    public class TaiKhoanDao
    {
        MyDBContext db = null;
        public TaiKhoanDao()
        {
            db = new MyDBContext();
        }
        public bool KiemTraDangNhap(TaiKhoan tk)
        {
            int kq = db.TaiKhoans.Count(x => x.TenDangNhap == tk.TenDangNhap && x.MatKhau == tk.MatKhau);
            if (kq > 0) return true;
            return false;
        }
        public bool DangKyTaiKhoan(string TenDangNhap, string MatKhau)
        {
            var TaiKhoan = new TaiKhoan()
            {
                TenDangNhap = TenDangNhap,
                MatKhau = MatKhau,
                LoaiTaiKhoan = "khachhang"
            };

            if (db.TaiKhoans.Where(x => x.TenDangNhap == TaiKhoan.TenDangNhap).FirstOrDefault() != null)
            {
                return false;
            }
            db.TaiKhoans.Add(TaiKhoan);
            int kq = db.SaveChanges();
            if (kq > 0) return true;
            return false;
        }
    }
}