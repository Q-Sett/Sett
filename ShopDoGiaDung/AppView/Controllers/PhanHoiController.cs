using AppData.IRepositories;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopDoGiaDung.Models;

namespace AppView.Controllers
{
    public class PhanHoiController : Controller
    {
        private readonly IAllRepositories<PhanHoi> _repos;
        ShoppingDBContext _dbContext = new ShoppingDBContext();
        DbSet<PhanHoi> _phanhoi;
        public PhanHoiController()
        {
            _phanhoi = _dbContext.phanHois;
            AllRepositories<PhanHoi> all = new AllRepositories<PhanHoi>(_dbContext, _phanhoi);
            _repos = all;
        }
        // GET: PhanHoiController
        public async Task<IActionResult> GetAllPhanHoi()
        {
            string apiUrl = "https://localhost:7026/api/PhanHoi";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var phanhoi = JsonConvert.DeserializeObject<List<PhanHoi>>(apiData);
            return View(phanhoi);
        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PhanHoi ph)
        {
            if (ModelState.IsValid)
            {

                if (_repos.CreateItem(ph))
                {
                    return RedirectToAction("GetAllSinhVien");
                }
                else return BadRequest();
            }
            else return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            PhanHoi ph = _repos.GetAll().FirstOrDefault(c => c.ID == id);
            return View(ph);
        }

        public async Task<IActionResult> Edit(PhanHoi ph)
        {
            if (ModelState.IsValid)
            {

                if (_repos.UpdateItem(ph))
                {
                    return RedirectToAction("GetAllPhanHoi");
                }
                else return BadRequest();
            }
            else return BadRequest(ModelState);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var ph = _repos.GetAll().FirstOrDefault(c => c.ID == id);
            if (_repos.DeleteItem(ph))
            {
                return RedirectToAction("GetAllPhanHoi");
            }
            else return BadRequest();

        }

        public async Task<IActionResult> Details(Guid id)
        {
            var sv = _repos.GetAll().FirstOrDefault(c => c.ID == id);
            return View(sv);
        }
    }
}
