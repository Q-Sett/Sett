using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Configurations
{
    public class SinhVienConfigurations : IEntityTypeConfiguration<SinhVien>
    {
        public void Configure(EntityTypeBuilder<SinhVien> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Ten).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.Tuoi).HasColumnType("int").IsRequired();
            builder.Property(p => p.Lop).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.SDT).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(p => p.DiemTB).HasColumnType("float").IsRequired();
        }
    }
}
