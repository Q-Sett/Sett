﻿using AppData.IRepositories;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;
using ShopDoGiaDung.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private readonly IAllRepositories<Giohang> irepos;
        ShoppingDBContext context = new ShoppingDBContext();
        public GioHangController()
        {
            irepos = new AllRepositories<Giohang>(context, context.giohangs);
        }
        // GET: api/<GioHangController>
        [HttpGet]
        public IEnumerable<Giohang> GetAllGioHang()
        {
            return irepos.GetAll();
        }
        // POST api/<GioHangController>
        [HttpPost("create-giohang")]
        public bool CreateGioHang(Guid idnguoidung, bool trangthai)
        {
            Giohang giohang = new Giohang();
            giohang.IDNguoiDung = idnguoidung;
            giohang.TrangThai = trangthai;
            
            return irepos.CreateItem(giohang);
        }

        // PUT api/<GioHangController>/5
        [HttpPut("update-giohang")]
        public bool Put(Guid idnguoidung, bool trangthai)
        {
            var giohang = irepos.GetAll().First(p => p.IDNguoiDung == idnguoidung);
            giohang.TrangThai = trangthai;
            return irepos.UpdateItem(giohang);
        }

        // DELETE api/<GioHangController>/5
        [HttpDelete("delete-giohang")]
        public bool
            Delete(Guid idnguoidung)
        {
            var giohang = irepos.GetAll().First(p => p.IDNguoiDung == idnguoidung);
            return irepos.DeleteItem(giohang);
        }
    }
}
