using AppData.IRepositories;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopDoGiaDung.Models;

namespace AppView.Controllers
{
    public class VoucherController : Controller
    {
        private readonly IAllRepositories<Voucher> _repos;
        ShoppingDBContext _dbContext = new ShoppingDBContext();
        DbSet<Voucher> _voucher;
        public VoucherController()
        {
            _voucher = _dbContext.vouchers;
            AllRepositories<Voucher> all = new AllRepositories<Voucher>(_dbContext, _voucher);
            _repos = all;
        }
        // GET: VoucherController
        public async Task<IActionResult> GetAllVoucher()
        {
            string apiUrl = "https://localhost:7026/api/Voucher";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var voucher = JsonConvert.DeserializeObject<List<Voucher>>(apiData);
            return View(voucher);
        }

        // GET: VoucherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VoucherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoucherController/Create
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

        // GET: VoucherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VoucherController/Edit/5
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

        // GET: VoucherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VoucherController/Delete/5
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
