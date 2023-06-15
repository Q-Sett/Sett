using AppData.IRepositories;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;
using ShopDoGiaDung.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuyenMaiController : ControllerBase
    {
        private readonly IAllRepositories<KhuyenMai> irepos;
        ShoppingDBContext context = new ShoppingDBContext();
        public KhuyenMaiController()
        {
            irepos = new AllRepositories<KhuyenMai>(context, context.khuyenMais);
        }
        // GET: api/<KhuyenMaiController>
        [HttpGet]
        public IEnumerable<KhuyenMai> GetAllKhuyenMai()
        {
            return irepos.GetAll();
        }
        // POST api/<KhuyenMaiController>
        [HttpPost("create-khuyenmai")]
        public bool CreateKhuyenMai( int phantramduocgiam, bool trangthai)
        {
            KhuyenMai khuyenMai = new KhuyenMai();
            khuyenMai.PhanTramDuocGiam = phantramduocgiam;
            khuyenMai.TrangThai = trangthai;
            khuyenMai.ID = Guid.NewGuid();
            return irepos.CreateItem(khuyenMai);
        }

        [HttpPut]
        [Route("edit-khuyenmai")]
        public bool UpdateKhuyenMai(Guid id ,int phantramduocgiam, bool trangthai)
        {
            KhuyenMai khuyenmai = irepos.GetAll().First(p => p.ID == id );
            khuyenmai.PhanTramDuocGiam = phantramduocgiam;
            khuyenmai.TrangThai = trangthai;
            return irepos.UpdateItem(khuyenmai);
        }

        // DELETE api/<PhanHoiController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            KhuyenMai khuyenmai = irepos.GetAll().First(x=> x.ID == id);
            return irepos.DeleteItem(khuyenmai);
        }
    }
}
