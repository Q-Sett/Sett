using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
            InverseIdGuiBcNavigation = new HashSet<NhanVien>();
        }

        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public string? TenDem { get; set; }
        public string? Ho { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public string? MatKhau { get; set; }
        public Guid? IdCh { get; set; }
        public Guid? IdCv { get; set; }
        public Guid? IdGuiBc { get; set; }
        public int? TrangThai { get; set; }

        public virtual CuaHang? IdChNavigation { get; set; }
        public virtual ChucVu? IdCvNavigation { get; set; }
        public virtual NhanVien? IdGuiBcNavigation { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<NhanVien> InverseIdGuiBcNavigation { get; set; }
    }
}
