using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitRestoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "MHCabangs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Kota = table.Column<string>(type: "text", nullable: false),
                    JumlahLantai = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHCabangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MHCustomers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerPhone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MHFnbs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    ColdHotAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHFnbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MHServices",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MHTables",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomorMeja = table.Column<int>(type: "integer", nullable: false),
                    Lantai = table.Column<int>(type: "integer", nullable: false),
                    isReserved = table.Column<bool>(type: "boolean", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    mhCabangId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MHTables_MHCabangs_mhCabangId",
                        column: x => x.mhCabangId,
                        principalSchema: "dbo",
                        principalTable: "MHCabangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "THCheckins",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MHCabangId = table.Column<int>(type: "integer", nullable: false),
                    MHTableId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerPhone = table.Column<string>(type: "text", nullable: true),
                    CustomerTotal = table.Column<int>(type: "integer", nullable: false),
                    Tax = table.Column<int>(type: "integer", nullable: false),
                    TotalPayment = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THCheckins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_THCheckins_MHCabangs_MHCabangId",
                        column: x => x.MHCabangId,
                        principalSchema: "dbo",
                        principalTable: "MHCabangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_THCheckins_MHTables_MHTableId",
                        column: x => x.MHTableId,
                        principalSchema: "dbo",
                        principalTable: "MHTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "THReservations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReservationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReservationDuration = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerPhone = table.Column<string>(type: "text", nullable: false),
                    CustomerTotal = table.Column<int>(type: "integer", nullable: false),
                    DownPayment = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    isFinished = table.Column<bool>(type: "boolean", nullable: false),
                    MHCabangId = table.Column<int>(type: "integer", nullable: false),
                    MHTableId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_THReservations_MHCabangs_MHCabangId",
                        column: x => x.MHCabangId,
                        principalSchema: "dbo",
                        principalTable: "MHCabangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_THReservations_MHTables_MHTableId",
                        column: x => x.MHTableId,
                        principalSchema: "dbo",
                        principalTable: "MHTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
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
                schema: "dbo",
                table: "MHServices",
                columns: new[] { "Id", "ServiceName" },
                values: new object[,]
                {
                    { 1, "order" },
                    { 2, "call" },
                    { 3, "pay" },
                    { 4, "complaint" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
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

            migrationBuilder.CreateIndex(
                name: "IX_MHTables_mhCabangId",
                schema: "dbo",
                table: "MHTables",
                column: "mhCabangId");

            migrationBuilder.CreateIndex(
                name: "IX_THCheckins_MHCabangId",
                schema: "dbo",
                table: "THCheckins",
                column: "MHCabangId");

            migrationBuilder.CreateIndex(
                name: "IX_THCheckins_MHTableId",
                schema: "dbo",
                table: "THCheckins",
                column: "MHTableId");

            migrationBuilder.CreateIndex(
                name: "IX_THReservations_MHCabangId",
                schema: "dbo",
                table: "THReservations",
                column: "MHCabangId");

            migrationBuilder.CreateIndex(
                name: "IX_THReservations_MHTableId",
                schema: "dbo",
                table: "THReservations",
                column: "MHTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MHCustomers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MHFnbs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MHServices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "THCheckins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "THReservations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MHTables",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MHCabangs",
                schema: "dbo");
        }
    }
}
