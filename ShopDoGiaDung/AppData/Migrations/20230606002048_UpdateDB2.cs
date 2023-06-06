using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class UpdateDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_khuyenMais_ID",
                table: "hoaDons");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_IDKhuyenMai",
                table: "hoaDons",
                column: "IDKhuyenMai");

            migrationBuilder.AddForeignKey(
                name: "FK_hoaDons_khuyenMais_IDKhuyenMai",
                table: "hoaDons",
                column: "IDKhuyenMai",
                principalTable: "khuyenMais",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_khuyenMais_IDKhuyenMai",
                table: "hoaDons");

            migrationBuilder.DropIndex(
                name: "IX_hoaDons_IDKhuyenMai",
                table: "hoaDons");

            migrationBuilder.AddForeignKey(
                name: "FK_hoaDons_khuyenMais_ID",
                table: "hoaDons",
                column: "ID",
                principalTable: "khuyenMais",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
