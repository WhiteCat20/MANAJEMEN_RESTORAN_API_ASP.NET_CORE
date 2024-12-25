using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MANAJEMEN_RESTORAN_API.Migrations
{
    /// <inheritdoc />
    public partial class seed_mh_cabang_mh_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MHCabangs",
                columns: new[] { "Id", "JumlahLantai", "Kota", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Surabaya", "CABANG 1" },
                    { 2, 2, "Sidoarjo", "CABANG 2" },
                    { 3, 1, "Gresik", "CABANG 3" },
                    { 4, 2, "Surabaya", "CABANG 4" },
                    { 5, 1, "Sidoarjo", "CABANG 5" },
                    { 6, 2, "Gresik", "CABANG 6" },
                    { 7, 1, "Surabaya", "CABANG 7" },
                    { 8, 2, "Sidoarjo", "CABANG 8" },
                    { 9, 1, "Gresik", "CABANG 9" },
                    { 10, 2, "Surabaya", "CABANG 10" }
                });

            migrationBuilder.InsertData(
                table: "MHTables",
                columns: new[] { "Id", "Capacity", "Lantai", "NomorMeja", "Status", "isReserved", "mhCabangId" },
                values: new object[,]
                {
                    { 1, 4, 1, 1, 0, false, 1 },
                    { 2, 6, 1, 2, 1, false, 1 },
                    { 3, 2, 2, 3, 0, false, 2 },
                    { 4, 4, 2, 4, 1, false, 2 },
                    { 5, 8, 1, 5, 0, false, 3 },
                    { 6, 4, 1, 6, 1, false, 3 },
                    { 7, 6, 2, 7, 0, false, 4 },
                    { 8, 2, 2, 8, 1, false, 4 },
                    { 9, 4, 1, 9, 0, false, 5 },
                    { 10, 8, 1, 10, 1, false, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MHCabangs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MHCabangs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MHCabangs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MHCabangs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MHCabangs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MHTables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MHTables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MHTables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MHTables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MHTables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MHTables",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MHTables",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MHTables",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MHTables",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MHTables",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MHCabangs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MHCabangs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MHCabangs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MHCabangs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MHCabangs",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
