﻿using AppData.IRepositories;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;
using ShopDoGiaDung.Models;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanHoiController : ControllerBase
    {
        private readonly IAllRepositories<PhanHoi> irepos;
        ShoppingDBContext context = new ShoppingDBContext();
        public PhanHoiController()
        {
            irepos = new AllRepositories<PhanHoi>(context, context.phanHois);
        }
        // GET: api/<PhanHoiController>
        [HttpGet]
        public IEnumerable<PhanHoi> GetAllPhanHoi()
        {
            return irepos.GetAll();
        }
        // POST api/<PhanHoiController>
        [HttpPost("create-phanhoi")]
        public bool CreatePhanHoi(Guid idnguoidung, Guid idsanpham, string noidungphanhoi, string loaiphanhoi, bool trangthai)
        {
            PhanHoi phanHoi = new PhanHoi();
            phanHoi.IDNguoiDung = idnguoidung;
            phanHoi.IDSanPham = idsanpham;
            phanHoi.NoiDungPhanHoi = noidungphanhoi;
            phanHoi.LoaiPhanHoi = loaiphanhoi;
            phanHoi.TrangThai = trangthai;
            phanHoi.ID = Guid.NewGuid();
            return irepos.CreateItem(phanHoi);
        }

        // PUT api/<PhanHoiController>/5
        [HttpPut]
        [Route("edit-phanhoi")]
        public bool Put(Guid id,Guid idnguoidung, Guid idsanpham, string noidungphanhoi, string loaiphanhoi, bool trangthai)
        {
            PhanHoi phanHoi = irepos.GetAll().First(p => p.ID == id);
            phanHoi.IDNguoiDung = idnguoidung;
            phanHoi.IDSanPham = idsanpham;
            phanHoi.NoiDungPhanHoi = noidungphanhoi;
            phanHoi.LoaiPhanHoi = loaiphanhoi;
            phanHoi.TrangThai = trangthai;
            return irepos.UpdateItem(phanHoi);
        }

        // DELETE api/<PhanHoiController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            PhanHoi phanHoi = irepos.GetAll().First(p => p.ID == id);
            return irepos.DeleteItem(phanHoi);
        }
    }
}
