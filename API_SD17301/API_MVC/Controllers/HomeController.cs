using API_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace API_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Privacy(int money, int day, double percent)
        {
            // Tạo URL request API
            string requestURL = $"https://localhost:7178/WeatherForecast/" + $"calculate-interest?day={day}&money={money}&percent={percent}";
            var httpCilent = new HttpClient(); // Tạo 1 httpCilent để call API
            var reponse = await httpCilent.GetAsync(requestURL); // Lấy kết quả 
            // Đọc ra string Json
            string apiData = await reponse.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            string result = JsonConvert.DeserializeObject<string>(apiData);
            ViewData["result"] = result;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}