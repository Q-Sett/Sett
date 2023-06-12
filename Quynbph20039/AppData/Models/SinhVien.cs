using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class SinhVien
    {
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public string Lop { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public double DiemTB { get; set; }
    }
}
