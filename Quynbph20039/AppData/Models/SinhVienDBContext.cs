using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class SinhVienDBContext : DbContext
    {
        public SinhVienDBContext() {}
        public SinhVienDBContext(DbContextOptions options) : base(options) {}
        public DbSet<SinhVien> sinhViens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=OH\\SQLEXPRESS;Initial Catalog=Quynbph20039;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
