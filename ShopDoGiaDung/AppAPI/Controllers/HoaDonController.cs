using AppData.IRepositories;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopDoGiaDung.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IAllRepositories<HoaDon> irepos;
        ShoppingDBContext context = new ShoppingDBContext();
        DbSet<HoaDon> hoaDons;
        public HoaDonController()
        {
            hoaDons = context.hoaDons;
            // irepos = new AllRepositories<HoaDon>(context, context.hoaDons);
            AllRepositories<HoaDon> all = new AllRepositories<HoaDon>(context, hoaDons);
            irepos = all;
        }
        // GET: api/<HoaDonController>
      
        [HttpGet]
        public List<HoaDon> GetAllHoaDon()
        {
            return irepos.GetAll().ToList();
        }
        [HttpGet("{id}")]
        public HoaDon? Get(Guid id)
        {
            return irepos.GetAll().FirstOrDefault(x => x.ID == id);
        }
        // POST api/<HoaDonController>
        [HttpPost("create-hoadon")]
        public bool CreateHoaDon(Guid idnguoidung,Guid idkhuyenmai , DateTime ngaytao, DateTime ngaythanhtoan, bool trangthai)
        {
            HoaDon hoaDon = new HoaDon();
            hoaDon.IDNguoiDung = idnguoidung;
            hoaDon.IDKhuyenMai = idkhuyenmai;
            hoaDon.NgayTao = ngaytao;
            hoaDon.NgayThanhToan = ngaythanhtoan;
            hoaDon.TrangThai = trangthai;
            hoaDon.ID = Guid.NewGuid();
            return irepos.CreateItem(hoaDon);
        }

        // PUT api/<HoaDonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HoaDonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
