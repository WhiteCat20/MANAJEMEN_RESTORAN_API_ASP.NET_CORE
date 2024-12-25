using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MANAJEMEN_RESTORAN_API.Migrations
{
    /// <inheritdoc />
    public partial class seed_mh_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "dbo");

            //migrationBuilder.CreateTable(
            //    name: "mh_cabang",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        kota = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        jumlah_lantai = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_mh_cabang", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "mh_customer",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        customer_phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_mh_customer", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "mh_table",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        id_mh_cabang = table.Column<int>(type: "int", nullable: false),
            //        nomor_meja = table.Column<int>(type: "int", nullable: false),
            //        lantai = table.Column<int>(type: "int", nullable: false),
            //        is_reserved = table.Column<bool>(type: "bit", nullable: false),
            //        capacity = table.Column<int>(type: "int", nullable: false),
            //        status = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_mh_table", x => x.id);
            //    });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mh_table",
                columns: new[] { "id", "capacity", "id_mh_cabang", "is_reserved", "lantai", "nomor_meja", "status" },
                values: new object[,]
                {
                    { 1, 4, 1, false, 1, 1, 0 },
                    { 2, 4, 1, false, 1, 2, 0 },
                    { 3, 3, 1, false, 1, 3, 0 },
                    { 4, 3, 2, false, 1, 8, 0 },
                    { 5, 3, 2, false, 1, 10, 0 },
                    { 6, 2, 2, false, 1, 9, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "mh_cabang",
            //    schema: "dbo");

            //migrationBuilder.DropTable(
            //    name: "mh_customer",
            //    schema: "dbo");

            migrationBuilder.DropTable(
                name: "mh_table",
                schema: "dbo");
        }
    }
}
