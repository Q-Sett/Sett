using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using AppView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace AppView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllRepositories<SinhVien> irepos;
        SinhVienDBContext context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            irepos = new AllRepositories<SinhVien>(context, context.sinhViens);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SinhVien()
        {
            IEnumerable<SinhVien> sinhViens = irepos.GetAll();
            return View("Sinhvien", sinhViens);
        }
        public IActionResult CreateSinhVien()
        {
            return View();
        }

        //public async Task<IActionResult> SinhVien(Guid id, string ten, int tuoi, string lop, string email, string sdt, double diemtb)
        //{
        //    string requestURL = $"https://localhost:7275/api/LaiKep/LaiKep";
        //}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}