using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "vouchers");

            migrationBuilder.DropColumn(
                name: "IDHoaDon",
                table: "khuyenMais");

            migrationBuilder.AddColumn<Guid>(
                name: "IDVoucher",
                table: "sanPhams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDKhuyenMai",
                table: "hoaDons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDVoucher",
                table: "sanPhams");

            migrationBuilder.DropColumn(
                name: "IDKhuyenMai",
                table: "hoaDons");

            migrationBuilder.AddColumn<Guid>(
                name: "IDSanPham",
                table: "vouchers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDHoaDon",
                table: "khuyenMais",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
