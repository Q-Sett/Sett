﻿using AppData.IRepositories;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;
using ShopDoGiaDung.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly IAllRepositories<SanPham> irepos;
        ShoppingDBContext context = new ShoppingDBContext();
        public SanPhamController()
        {
            irepos = new AllRepositories<SanPham>(context, context.sanPhams);
        }
        // GET: api/<SanPhamController>
        [HttpGet]
        public IEnumerable<SanPham> GetAllSanPham()
        {
            return irepos.GetAll();
        }
        // POST api/<SanPhamController>
        [HttpPost("create-sanpham")]
        public bool CreateSanPham(Guid iddanhmucsanpham,Guid idvoucher ,string ten, string anh, string nhacungcap, DateTime nsx, double giaban, long soluongton, string mota, string danhmuc, bool trangthai)
        {
            SanPham sanPham = new SanPham();
            sanPham.IDDanhMucSanPham = iddanhmucsanpham; 
            sanPham.IDVoucher = idvoucher;
            sanPham.Ten = ten;
            sanPham.Anh = anh;
            sanPham.NhaCungCap = nhacungcap;
            sanPham.NSX = nsx;
            sanPham.GiaBan = giaban;
            sanPham.SoLuongTon = soluongton;
            sanPham.MoTa = mota;
            sanPham.DanhMuc = danhmuc;
            sanPham.TrangThai = trangthai;
            sanPham.ID = Guid.NewGuid();
            return irepos.CreateItem(sanPham);
        }

        // PUT api/<SanPhamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SanPhamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
