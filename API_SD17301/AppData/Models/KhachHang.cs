using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            GioHangs = new HashSet<GioHang>();
            HoaDons = new HashSet<HoaDon>();
        }

        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public string? TenDem { get; set; }
        public string? Ho { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? Sdt { get; set; }
        public string? DiaChi { get; set; }
        public string? ThanhPho { get; set; }
        public string? QuocGia { get; set; }
        public string? MatKhau { get; set; }

        public virtual ICollection<GioHang> GioHangs { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
