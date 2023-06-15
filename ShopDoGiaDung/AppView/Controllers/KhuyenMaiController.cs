using AppData.IRepositories;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopDoGiaDung.Models;

namespace AppView.Controllers
{
    public class KhuyenMaiController : Controller
    {
        private readonly IAllRepositories<KhuyenMai> _repos;
        ShoppingDBContext _dbContext = new ShoppingDBContext();
        DbSet<KhuyenMai> _khuyenmai;
        public KhuyenMaiController()
        {
            _khuyenmai = _dbContext.khuyenMais;
            AllRepositories<KhuyenMai> all = new AllRepositories<KhuyenMai>(_dbContext, _khuyenmai);
            _repos = all;
        }
        // GET: KhuyenMaiController
        public async Task<IActionResult> GetAllKhuyenMai()
        {
            string apiUrl = "https://localhost:7026/api/KhuyenMai";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var khuyenmai = JsonConvert.DeserializeObject<List<KhuyenMai>>(apiData);
            return View(khuyenmai);
        }

        // GET: KhuyenMaiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KhuyenMaiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhuyenMaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KhuyenMaiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KhuyenMaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KhuyenMaiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KhuyenMaiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
