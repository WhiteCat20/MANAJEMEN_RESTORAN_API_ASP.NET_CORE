using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MANAJEMEN_RESTORAN_API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MHCabangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JumlahLantai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHCabangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MHCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MHTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomorMeja = table.Column<int>(type: "int", nullable: false),
                    Lantai = table.Column<int>(type: "int", nullable: false),
                    isReserved = table.Column<bool>(type: "bit", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    mhCabangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MHTables_MHCabangs_mhCabangId",
                        column: x => x.mhCabangId,
                        principalTable: "MHCabangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MHTables_mhCabangId",
                table: "MHTables",
                column: "mhCabangId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MHCustomers");

            migrationBuilder.DropTable(
                name: "MHTables");

            migrationBuilder.DropTable(
                name: "MHCabangs");
        }
    }
}
