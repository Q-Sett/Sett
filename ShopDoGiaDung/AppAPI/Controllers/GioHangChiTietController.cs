﻿using AppData.IRepositories;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;
using ShopDoGiaDung.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangChiTietController : ControllerBase
    {
        private readonly IAllRepositories<GioHangChiTIet> irepos;
        ShoppingDBContext context = new ShoppingDBContext();
        public GioHangChiTietController()
        {
            irepos = new AllRepositories<GioHangChiTIet>(context, context.gioHangChiTIets);
        }
        // GET: api/<GioHangChiTietController>
        [HttpGet]
        public IEnumerable<GioHangChiTIet> GetAllGioHangChiTiet()
        {
            return irepos.GetAll();
        }
        // POST api/<GioHangChiTietController>
        [HttpPost("create-gihangchitiet")]
        public bool CreateGioHangChiTiet(Guid idsanpham, Guid idnguoidung, Guid idgiohang, int soluong, double thanhtien)
        {
            GioHangChiTIet gioHangChiTIet = new GioHangChiTIet();
            gioHangChiTIet.IDSanPham = idsanpham;
            gioHangChiTIet.IDNguoiDung = idnguoidung;
            gioHangChiTIet.IDGioHang = idgiohang;
            gioHangChiTIet.SoLuong = soluong;
            gioHangChiTIet.ThanhTien = thanhtien;
            return irepos.CreateItem(gioHangChiTIet);
        }

        // PUT api/<GioHangChiTietController>/5
        [HttpPut("update-gioHangChiTIet")]
        public bool Put(Guid idsanpham, Guid idnguoidung, Guid idgiohang, int soluong, double thanhtien)
        {

            var gioHangChiTIet = irepos.GetAll().First(p => p.IDSanPham == idsanpham);
            gioHangChiTIet.IDNguoiDung = idnguoidung;
            gioHangChiTIet.IDGioHang = idgiohang;
            gioHangChiTIet.SoLuong = soluong;
            gioHangChiTIet.ThanhTien = thanhtien;
            return irepos.UpdateItem(gioHangChiTIet);

        }

        // DELETE api/<GioHangChiTietController>/5
        [HttpDelete("delete-gioHangChiTIet")]
        public bool Delete(Guid idsanpham)
        {

            var gioHangChiTIet = irepos.GetAll().First(p => p.IDSanPham == idsanpham);
            return irepos.DeleteItem(gioHangChiTIet);


        }
    }
}
