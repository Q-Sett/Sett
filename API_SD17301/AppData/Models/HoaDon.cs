using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public Guid Id { get; set; }
        public Guid? IdKh { get; set; }
        public Guid? IdNv { get; set; }
        public string? Ma { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public DateTime? NgayShip { get; set; }
        public DateTime? NgayNhan { get; set; }
        public int? TinhTrang { get; set; }
        public string? TenNguoiNhan { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }

        public virtual KhachHang? IdKhNavigation { get; set; }
        public virtual NhanVien? IdNvNavigation { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
