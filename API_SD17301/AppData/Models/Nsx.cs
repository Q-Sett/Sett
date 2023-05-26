using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class Nsx
    {
        public Nsx()
        {
            ChiTietSps = new HashSet<ChiTietSp>();
        }

        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public string? Ten { get; set; }

        public virtual ICollection<ChiTietSp> ChiTietSps { get; set; }
    }
}
