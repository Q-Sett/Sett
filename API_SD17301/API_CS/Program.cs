using Newtonsoft.Json;

Console.OutputEncoding = System.Text.Encoding.UTF8; 
// Lấy data từ form
Console.WriteLine("Số tiền bạn vay:");
int money = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Số ngày nợ:");
int day = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Lãi suất (%):");
double percent = Convert.ToDouble(Console.ReadLine());
// Tạo URL request API
string requestURL =
$"https://localhost:7178/WeatherForecast/" +
$"calculate-interest?day={day}&money={money}&percent={percent}";
var httpClient = new HttpClient(); // Tại 1 httpClient để call API
var response = await httpClient.GetAsync(requestURL); // Lấy kết quả
                                                      // Đọc ra string Json
string apiData = await response.Content.ReadAsStringAsync();
// Lấy kết quả thu được bằng cách bóc dữ liệu Json
string result = JsonConvert.DeserializeObject<string>(apiData);
Console.WriteLine("Số tiền phải trả: " + result);
Console.ReadKey();