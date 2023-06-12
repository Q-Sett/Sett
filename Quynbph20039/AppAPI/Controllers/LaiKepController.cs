using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaiKepController : ControllerBase
    {
        [HttpGet("LaiKep")]
        // Viết API tính Tiền lãi kép với các tham số là money (tiền) và n(số tháng) và p(Tỉ lệ lãi) với công thức là: Tiền lãi = money * (1 + p / 100) ^ n - money
        public double GetInterest(int n, int money, double p)
        {
            return money * Math.Pow((1 + p / 100), n) - money;
        }
    }
}
