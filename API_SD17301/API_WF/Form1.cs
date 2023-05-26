using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_confirm_Click(object sender, EventArgs e)
        {
            // Lấy data từ form
            int money = Convert.ToInt32(tbt_money.Text);
            int day = Convert.ToInt32(tbt_day.Text);
            double percent = Convert.ToDouble(tbt_percent.Text);
            // Tạo URL request API
            string requestURL = $"https://localhost:7178/WeatherForecast/" + $"calculate-interest?day={day}&money={money}&percent={percent}";
            var httpCilent = new HttpClient(); // Tạo 1 httpCilent để call API
            var reponse = await httpCilent.GetAsync(requestURL); // Lấy kết quả 
            // Đọc ra string Json
            string apiData = await reponse.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            string result = JsonConvert.DeserializeObject<string>(apiData);
            btn_result.Text = result;
        }

        private void btn_result_Click(object sender, EventArgs e)
        {

        }
    }
}
