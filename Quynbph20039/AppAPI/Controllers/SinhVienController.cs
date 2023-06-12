using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly IAllRepositories<SinhVien> irepos;
        SinhVienDBContext context = new SinhVienDBContext();
        public SinhVienController()
        {
            irepos = new AllRepositories<SinhVien>(context, context.sinhViens);   
        }
        // GET: api/<SinhVienController>
        [HttpGet]
        public IEnumerable<SinhVien> GetAllSinhVien()
        {
            return irepos.GetAll();
        }
        // POST api/<SinhVienController>
        [HttpPost("Create-SinhVien")]
        public bool CreateSinhVien(string ten, int tuoi, string lop, string email, string sdt, double diemtb)
        {
            SinhVien sinhVien = new SinhVien();
            sinhVien.Ten = ten;
            sinhVien.Tuoi = tuoi;
            sinhVien.Lop = lop;
            sinhVien.Email = email;
            sinhVien.SDT = sdt;
            sinhVien.DiemTB = diemtb;
            return irepos.CreateItem(sinhVien);
        }

        // PUT api/<SinhVienController>/5
        [HttpPut("Update-SinhVien")]
        public bool UpdateSinhVien(Guid id, string ten, int tuoi, string lop, string email, string sdt, double diemtb)
        {
            SinhVien sinhVien = irepos.GetAll().SingleOrDefault(p => p.ID == id);
            sinhVien.Ten = ten;
            sinhVien.Tuoi = tuoi;
            sinhVien.Lop = lop;
            sinhVien.Email = email;
            sinhVien.SDT = sdt;
            sinhVien.DiemTB = diemtb;
            return irepos.UpdateItem(sinhVien);
        }

        // DELETE api/<SinhVienController>/5
        [HttpDelete("Delete-SinhVien")]
        public bool Delete(Guid id)
        {
            SinhVien sinhVien = irepos.GetAll().SingleOrDefault(p => p.ID == id);
            return irepos.DeleteItem(sinhVien);
        }
    }
}
