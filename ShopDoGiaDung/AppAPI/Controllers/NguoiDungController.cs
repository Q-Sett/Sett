using AppData.IRepositories;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;
using ShopDoGiaDung.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly IAllRepositories<NguoiDung> irepos;
        ShoppingDBContext context = new ShoppingDBContext();
        public NguoiDungController()
        {
            irepos = new AllRepositories<NguoiDung>(context, context.nguoiDungs);
        }
        // GET: api/<NguoiDungController>
        [HttpGet]
        public IEnumerable<NguoiDung> GetAllNguoiDung()
        {
            return irepos.GetAll();
        }
        // POST api/<NguoiDungController>
        [HttpPost("create-nguoidung")]
        public bool CreateNguoiDung(Guid idchucvu, string ten, DateTime ngaysinh, string diachi, string dienthoai, string taikhoan, string matkhau, bool trangthai)
        {
            NguoiDung nguoiDung = new NguoiDung();
            nguoiDung.IDChucVu = idchucvu;
            nguoiDung.Ten = ten;
            nguoiDung.NgaySinh = ngaysinh;
            nguoiDung.DiaChi = diachi;
            nguoiDung.DienThoai = dienthoai;
            nguoiDung.TaiKhoan = taikhoan;
            nguoiDung.MatKhau = matkhau;
            nguoiDung.TrangThai = trangthai;
            return irepos.CreateItem(nguoiDung);
        }

        // PUT api/<NguoiDungController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NguoiDungController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
