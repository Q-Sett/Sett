using AppData.IRespositories;
using AppData.Models;
using AppData.Respositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DongSPController : ControllerBase
    {
        private readonly IALLRepositories<DongSp> irepos;
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        public DongSPController()
        {
            irepos = new ALLRepositories<DongSp>(context, context.DongSps); 
        }
        // GET: api/<DongSPController>
        [HttpGet("get-all-dongsp")]
        public IEnumerable<DongSp> GetAllDongSP()
        {
            return irepos.GetAll();
        }
        // POST api/<DongSPController>
        [HttpPost("create-dongsp")]
        public bool CreateDongSP(string ma, string ten)
        {
            DongSp dongSp = new DongSp();
            dongSp.Ma = ma;
            dongSp.Ten = ten;
            return irepos.CreateItem(dongSp);
        }

        // PUT api/<DongSPController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DongSPController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
