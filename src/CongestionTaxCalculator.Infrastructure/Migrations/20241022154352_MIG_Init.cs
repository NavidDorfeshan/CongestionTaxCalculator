using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CongestionTaxCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MIG_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsTaxFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    MonthName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MonthCode = table.Column<short>(type: "smallint", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    IsHoliday = table.Column<bool>(type: "bit", nullable: false),
                    IsTaxFree = table.Column<bool>(type: "bit", nullable: false),
                    IsWeekend = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calender_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    FromTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ToTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRule_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTrafficHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTrafficHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleTrafficHistory_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleTrafficHistory_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Gothenburg" });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "IsTaxFree", "Name" },
                values: new object[,]
                {
                    { 1, true, "Emergency vehicles" },
                    { 2, true, "Busses" },
                    { 3, true, "Diplomat vehicles" },
                    { 4, true, "Motorcycles" },
                    { 5, true, "Military vehicles" },
                    { 6, true, "Foreign vehicles" },
                    { 7, false, "Car" }
                });

            migrationBuilder.InsertData(
                table: "Calender",
                columns: new[] { "Id", "CityId", "Date", "IsHoliday", "IsTaxFree", "IsWeekend", "MonthCode", "MonthName", "Year" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2013, 1, 1), false, false, false, (short)1, "January", (short)2013 },
                    { 2, 1, new DateOnly(2013, 1, 2), false, false, false, (short)1, "January", (short)2013 },
                    { 3, 1, new DateOnly(2013, 1, 3), false, false, false, (short)1, "January", (short)2013 },
                    { 4, 1, new DateOnly(2013, 1, 4), false, false, false, (short)1, "January", (short)2013 },
                    { 5, 1, new DateOnly(2013, 1, 5), false, true, true, (short)1, "January", (short)2013 },
                    { 6, 1, new DateOnly(2013, 1, 6), false, true, true, (short)1, "January", (short)2013 },
                    { 7, 1, new DateOnly(2013, 1, 7), false, false, false, (short)1, "January", (short)2013 },
                    { 8, 1, new DateOnly(2013, 1, 8), false, false, false, (short)1, "January", (short)2013 },
                    { 9, 1, new DateOnly(2013, 1, 9), false, false, false, (short)1, "January", (short)2013 },
                    { 10, 1, new DateOnly(2013, 1, 10), false, false, false, (short)1, "January", (short)2013 },
                    { 11, 1, new DateOnly(2013, 1, 11), false, false, false, (short)1, "January", (short)2013 },
                    { 12, 1, new DateOnly(2013, 1, 12), false, true, true, (short)1, "January", (short)2013 },
                    { 13, 1, new DateOnly(2013, 1, 13), false, true, true, (short)1, "January", (short)2013 },
                    { 14, 1, new DateOnly(2013, 1, 14), false, false, false, (short)1, "January", (short)2013 },
                    { 15, 1, new DateOnly(2013, 1, 15), false, false, false, (short)1, "January", (short)2013 },
                    { 16, 1, new DateOnly(2013, 1, 16), false, false, false, (short)1, "January", (short)2013 },
                    { 17, 1, new DateOnly(2013, 1, 17), false, false, false, (short)1, "January", (short)2013 },
                    { 18, 1, new DateOnly(2013, 1, 18), false, false, false, (short)1, "January", (short)2013 },
                    { 19, 1, new DateOnly(2013, 1, 19), false, true, true, (short)1, "January", (short)2013 },
                    { 20, 1, new DateOnly(2013, 1, 20), false, true, true, (short)1, "January", (short)2013 },
                    { 21, 1, new DateOnly(2013, 1, 21), false, false, false, (short)1, "January", (short)2013 },
                    { 22, 1, new DateOnly(2013, 1, 22), false, false, false, (short)1, "January", (short)2013 },
                    { 23, 1, new DateOnly(2013, 1, 23), false, false, false, (short)1, "January", (short)2013 },
                    { 24, 1, new DateOnly(2013, 1, 24), false, false, false, (short)1, "January", (short)2013 },
                    { 25, 1, new DateOnly(2013, 1, 25), false, false, false, (short)1, "January", (short)2013 },
                    { 26, 1, new DateOnly(2013, 1, 26), false, true, true, (short)1, "January", (short)2013 },
                    { 27, 1, new DateOnly(2013, 1, 27), false, true, true, (short)1, "January", (short)2013 },
                    { 28, 1, new DateOnly(2013, 1, 28), false, false, false, (short)1, "January", (short)2013 },
                    { 29, 1, new DateOnly(2013, 1, 29), false, false, false, (short)1, "January", (short)2013 },
                    { 30, 1, new DateOnly(2013, 1, 30), false, false, false, (short)1, "January", (short)2013 },
                    { 31, 1, new DateOnly(2013, 1, 31), false, false, false, (short)1, "January", (short)2013 },
                    { 32, 1, new DateOnly(2013, 2, 1), false, false, false, (short)2, "February", (short)2013 },
                    { 33, 1, new DateOnly(2013, 2, 2), false, true, true, (short)2, "February", (short)2013 },
                    { 34, 1, new DateOnly(2013, 2, 3), false, true, true, (short)2, "February", (short)2013 },
                    { 35, 1, new DateOnly(2013, 2, 4), false, false, false, (short)2, "February", (short)2013 },
                    { 36, 1, new DateOnly(2013, 2, 5), false, false, false, (short)2, "February", (short)2013 },
                    { 37, 1, new DateOnly(2013, 2, 6), false, false, false, (short)2, "February", (short)2013 },
                    { 38, 1, new DateOnly(2013, 2, 7), false, false, false, (short)2, "February", (short)2013 },
                    { 39, 1, new DateOnly(2013, 2, 8), false, false, false, (short)2, "February", (short)2013 },
                    { 40, 1, new DateOnly(2013, 2, 9), false, true, true, (short)2, "February", (short)2013 },
                    { 41, 1, new DateOnly(2013, 2, 10), false, true, true, (short)2, "February", (short)2013 },
                    { 42, 1, new DateOnly(2013, 2, 11), false, false, false, (short)2, "February", (short)2013 },
                    { 43, 1, new DateOnly(2013, 2, 12), false, false, false, (short)2, "February", (short)2013 },
                    { 44, 1, new DateOnly(2013, 2, 13), false, false, false, (short)2, "February", (short)2013 },
                    { 45, 1, new DateOnly(2013, 2, 14), false, false, false, (short)2, "February", (short)2013 },
                    { 46, 1, new DateOnly(2013, 2, 15), false, false, false, (short)2, "February", (short)2013 },
                    { 47, 1, new DateOnly(2013, 2, 16), false, true, true, (short)2, "February", (short)2013 },
                    { 48, 1, new DateOnly(2013, 2, 17), false, true, true, (short)2, "February", (short)2013 },
                    { 49, 1, new DateOnly(2013, 2, 18), false, false, false, (short)2, "February", (short)2013 },
                    { 50, 1, new DateOnly(2013, 2, 19), false, false, false, (short)2, "February", (short)2013 },
                    { 51, 1, new DateOnly(2013, 2, 20), false, false, false, (short)2, "February", (short)2013 },
                    { 52, 1, new DateOnly(2013, 2, 21), false, false, false, (short)2, "February", (short)2013 },
                    { 53, 1, new DateOnly(2013, 2, 22), false, false, false, (short)2, "February", (short)2013 },
                    { 54, 1, new DateOnly(2013, 2, 23), false, true, true, (short)2, "February", (short)2013 },
                    { 55, 1, new DateOnly(2013, 2, 24), false, true, true, (short)2, "February", (short)2013 },
                    { 56, 1, new DateOnly(2013, 2, 25), false, false, false, (short)2, "February", (short)2013 },
                    { 57, 1, new DateOnly(2013, 2, 26), false, false, false, (short)2, "February", (short)2013 },
                    { 58, 1, new DateOnly(2013, 2, 27), false, false, false, (short)2, "February", (short)2013 },
                    { 59, 1, new DateOnly(2013, 2, 28), false, false, false, (short)2, "February", (short)2013 },
                    { 60, 1, new DateOnly(2013, 3, 1), false, false, false, (short)3, "March", (short)2013 },
                    { 61, 1, new DateOnly(2013, 3, 2), false, true, true, (short)3, "March", (short)2013 },
                    { 62, 1, new DateOnly(2013, 3, 3), false, true, true, (short)3, "March", (short)2013 },
                    { 63, 1, new DateOnly(2013, 3, 4), false, false, false, (short)3, "March", (short)2013 },
                    { 64, 1, new DateOnly(2013, 3, 5), false, false, false, (short)3, "March", (short)2013 },
                    { 65, 1, new DateOnly(2013, 3, 6), false, false, false, (short)3, "March", (short)2013 },
                    { 66, 1, new DateOnly(2013, 3, 7), false, false, false, (short)3, "March", (short)2013 },
                    { 67, 1, new DateOnly(2013, 3, 8), false, false, false, (short)3, "March", (short)2013 },
                    { 68, 1, new DateOnly(2013, 3, 9), false, true, true, (short)3, "March", (short)2013 },
                    { 69, 1, new DateOnly(2013, 3, 10), false, true, true, (short)3, "March", (short)2013 },
                    { 70, 1, new DateOnly(2013, 3, 11), false, false, false, (short)3, "March", (short)2013 },
                    { 71, 1, new DateOnly(2013, 3, 12), false, false, false, (short)3, "March", (short)2013 },
                    { 72, 1, new DateOnly(2013, 3, 13), false, false, false, (short)3, "March", (short)2013 },
                    { 73, 1, new DateOnly(2013, 3, 14), false, false, false, (short)3, "March", (short)2013 },
                    { 74, 1, new DateOnly(2013, 3, 15), false, false, false, (short)3, "March", (short)2013 },
                    { 75, 1, new DateOnly(2013, 3, 16), false, true, true, (short)3, "March", (short)2013 },
                    { 76, 1, new DateOnly(2013, 3, 17), false, true, true, (short)3, "March", (short)2013 },
                    { 77, 1, new DateOnly(2013, 3, 18), false, false, false, (short)3, "March", (short)2013 },
                    { 78, 1, new DateOnly(2013, 3, 19), false, false, false, (short)3, "March", (short)2013 },
                    { 79, 1, new DateOnly(2013, 3, 20), false, false, false, (short)3, "March", (short)2013 },
                    { 80, 1, new DateOnly(2013, 3, 21), false, false, false, (short)3, "March", (short)2013 },
                    { 81, 1, new DateOnly(2013, 3, 22), false, false, false, (short)3, "March", (short)2013 },
                    { 82, 1, new DateOnly(2013, 3, 23), false, true, true, (short)3, "March", (short)2013 },
                    { 83, 1, new DateOnly(2013, 3, 24), false, true, true, (short)3, "March", (short)2013 },
                    { 84, 1, new DateOnly(2013, 3, 25), false, false, false, (short)3, "March", (short)2013 },
                    { 85, 1, new DateOnly(2013, 3, 26), false, false, false, (short)3, "March", (short)2013 },
                    { 86, 1, new DateOnly(2013, 3, 27), false, false, false, (short)3, "March", (short)2013 },
                    { 87, 1, new DateOnly(2013, 3, 28), false, false, false, (short)3, "March", (short)2013 },
                    { 88, 1, new DateOnly(2013, 3, 29), false, false, false, (short)3, "March", (short)2013 },
                    { 89, 1, new DateOnly(2013, 3, 30), false, true, true, (short)3, "March", (short)2013 },
                    { 90, 1, new DateOnly(2013, 3, 31), false, true, true, (short)3, "March", (short)2013 },
                    { 91, 1, new DateOnly(2013, 4, 1), false, false, false, (short)4, "April", (short)2013 },
                    { 92, 1, new DateOnly(2013, 4, 2), false, false, false, (short)4, "April", (short)2013 },
                    { 93, 1, new DateOnly(2013, 4, 3), false, false, false, (short)4, "April", (short)2013 },
                    { 94, 1, new DateOnly(2013, 4, 4), false, false, false, (short)4, "April", (short)2013 },
                    { 95, 1, new DateOnly(2013, 4, 5), false, false, false, (short)4, "April", (short)2013 },
                    { 96, 1, new DateOnly(2013, 4, 6), false, true, true, (short)4, "April", (short)2013 },
                    { 97, 1, new DateOnly(2013, 4, 7), false, true, true, (short)4, "April", (short)2013 },
                    { 98, 1, new DateOnly(2013, 4, 8), false, false, false, (short)4, "April", (short)2013 },
                    { 99, 1, new DateOnly(2013, 4, 9), false, false, false, (short)4, "April", (short)2013 },
                    { 100, 1, new DateOnly(2013, 4, 10), false, false, false, (short)4, "April", (short)2013 },
                    { 101, 1, new DateOnly(2013, 4, 11), false, false, false, (short)4, "April", (short)2013 },
                    { 102, 1, new DateOnly(2013, 4, 12), false, false, false, (short)4, "April", (short)2013 },
                    { 103, 1, new DateOnly(2013, 4, 13), false, true, true, (short)4, "April", (short)2013 },
                    { 104, 1, new DateOnly(2013, 4, 14), false, true, true, (short)4, "April", (short)2013 },
                    { 105, 1, new DateOnly(2013, 4, 15), false, false, false, (short)4, "April", (short)2013 },
                    { 106, 1, new DateOnly(2013, 4, 16), false, false, false, (short)4, "April", (short)2013 },
                    { 107, 1, new DateOnly(2013, 4, 17), false, false, false, (short)4, "April", (short)2013 },
                    { 108, 1, new DateOnly(2013, 4, 18), false, false, false, (short)4, "April", (short)2013 },
                    { 109, 1, new DateOnly(2013, 4, 19), false, false, false, (short)4, "April", (short)2013 },
                    { 110, 1, new DateOnly(2013, 4, 20), false, true, true, (short)4, "April", (short)2013 },
                    { 111, 1, new DateOnly(2013, 4, 21), false, true, true, (short)4, "April", (short)2013 },
                    { 112, 1, new DateOnly(2013, 4, 22), false, false, false, (short)4, "April", (short)2013 },
                    { 113, 1, new DateOnly(2013, 4, 23), false, false, false, (short)4, "April", (short)2013 },
                    { 114, 1, new DateOnly(2013, 4, 24), false, false, false, (short)4, "April", (short)2013 },
                    { 115, 1, new DateOnly(2013, 4, 25), false, false, false, (short)4, "April", (short)2013 },
                    { 116, 1, new DateOnly(2013, 4, 26), false, false, false, (short)4, "April", (short)2013 },
                    { 117, 1, new DateOnly(2013, 4, 27), false, true, true, (short)4, "April", (short)2013 },
                    { 118, 1, new DateOnly(2013, 4, 28), false, true, true, (short)4, "April", (short)2013 },
                    { 119, 1, new DateOnly(2013, 4, 29), false, false, false, (short)4, "April", (short)2013 },
                    { 120, 1, new DateOnly(2013, 4, 30), false, false, false, (short)4, "April", (short)2013 },
                    { 121, 1, new DateOnly(2013, 5, 1), false, false, false, (short)5, "May", (short)2013 },
                    { 122, 1, new DateOnly(2013, 5, 2), false, false, false, (short)5, "May", (short)2013 },
                    { 123, 1, new DateOnly(2013, 5, 3), false, false, false, (short)5, "May", (short)2013 },
                    { 124, 1, new DateOnly(2013, 5, 4), false, true, true, (short)5, "May", (short)2013 },
                    { 125, 1, new DateOnly(2013, 5, 5), false, true, true, (short)5, "May", (short)2013 },
                    { 126, 1, new DateOnly(2013, 5, 6), false, false, false, (short)5, "May", (short)2013 },
                    { 127, 1, new DateOnly(2013, 5, 7), false, false, false, (short)5, "May", (short)2013 },
                    { 128, 1, new DateOnly(2013, 5, 8), false, false, false, (short)5, "May", (short)2013 },
                    { 129, 1, new DateOnly(2013, 5, 9), false, false, false, (short)5, "May", (short)2013 },
                    { 130, 1, new DateOnly(2013, 5, 10), false, false, false, (short)5, "May", (short)2013 },
                    { 131, 1, new DateOnly(2013, 5, 11), false, true, true, (short)5, "May", (short)2013 },
                    { 132, 1, new DateOnly(2013, 5, 12), false, true, true, (short)5, "May", (short)2013 },
                    { 133, 1, new DateOnly(2013, 5, 13), false, false, false, (short)5, "May", (short)2013 },
                    { 134, 1, new DateOnly(2013, 5, 14), false, false, false, (short)5, "May", (short)2013 },
                    { 135, 1, new DateOnly(2013, 5, 15), false, false, false, (short)5, "May", (short)2013 },
                    { 136, 1, new DateOnly(2013, 5, 16), false, false, false, (short)5, "May", (short)2013 },
                    { 137, 1, new DateOnly(2013, 5, 17), false, false, false, (short)5, "May", (short)2013 },
                    { 138, 1, new DateOnly(2013, 5, 18), false, true, true, (short)5, "May", (short)2013 },
                    { 139, 1, new DateOnly(2013, 5, 19), false, true, true, (short)5, "May", (short)2013 },
                    { 140, 1, new DateOnly(2013, 5, 20), false, false, false, (short)5, "May", (short)2013 },
                    { 141, 1, new DateOnly(2013, 5, 21), false, false, false, (short)5, "May", (short)2013 },
                    { 142, 1, new DateOnly(2013, 5, 22), false, false, false, (short)5, "May", (short)2013 },
                    { 143, 1, new DateOnly(2013, 5, 23), false, false, false, (short)5, "May", (short)2013 },
                    { 144, 1, new DateOnly(2013, 5, 24), false, false, false, (short)5, "May", (short)2013 },
                    { 145, 1, new DateOnly(2013, 5, 25), false, true, true, (short)5, "May", (short)2013 },
                    { 146, 1, new DateOnly(2013, 5, 26), false, true, true, (short)5, "May", (short)2013 },
                    { 147, 1, new DateOnly(2013, 5, 27), false, false, false, (short)5, "May", (short)2013 },
                    { 148, 1, new DateOnly(2013, 5, 28), false, false, false, (short)5, "May", (short)2013 },
                    { 149, 1, new DateOnly(2013, 5, 29), false, false, false, (short)5, "May", (short)2013 },
                    { 150, 1, new DateOnly(2013, 5, 30), false, false, false, (short)5, "May", (short)2013 },
                    { 151, 1, new DateOnly(2013, 5, 31), false, false, false, (short)5, "May", (short)2013 },
                    { 152, 1, new DateOnly(2013, 6, 1), false, true, true, (short)6, "June", (short)2013 },
                    { 153, 1, new DateOnly(2013, 6, 2), false, true, true, (short)6, "June", (short)2013 },
                    { 154, 1, new DateOnly(2013, 6, 3), false, false, false, (short)6, "June", (short)2013 },
                    { 155, 1, new DateOnly(2013, 6, 4), false, false, false, (short)6, "June", (short)2013 },
                    { 156, 1, new DateOnly(2013, 6, 5), false, false, false, (short)6, "June", (short)2013 },
                    { 157, 1, new DateOnly(2013, 6, 6), false, false, false, (short)6, "June", (short)2013 },
                    { 158, 1, new DateOnly(2013, 6, 7), false, false, false, (short)6, "June", (short)2013 },
                    { 159, 1, new DateOnly(2013, 6, 8), false, true, true, (short)6, "June", (short)2013 },
                    { 160, 1, new DateOnly(2013, 6, 9), false, true, true, (short)6, "June", (short)2013 },
                    { 161, 1, new DateOnly(2013, 6, 10), false, false, false, (short)6, "June", (short)2013 },
                    { 162, 1, new DateOnly(2013, 6, 11), false, false, false, (short)6, "June", (short)2013 },
                    { 163, 1, new DateOnly(2013, 6, 12), false, false, false, (short)6, "June", (short)2013 },
                    { 164, 1, new DateOnly(2013, 6, 13), false, false, false, (short)6, "June", (short)2013 },
                    { 165, 1, new DateOnly(2013, 6, 14), false, false, false, (short)6, "June", (short)2013 },
                    { 166, 1, new DateOnly(2013, 6, 15), false, true, true, (short)6, "June", (short)2013 },
                    { 167, 1, new DateOnly(2013, 6, 16), false, true, true, (short)6, "June", (short)2013 },
                    { 168, 1, new DateOnly(2013, 6, 17), false, false, false, (short)6, "June", (short)2013 },
                    { 169, 1, new DateOnly(2013, 6, 18), false, false, false, (short)6, "June", (short)2013 },
                    { 170, 1, new DateOnly(2013, 6, 19), false, false, false, (short)6, "June", (short)2013 },
                    { 171, 1, new DateOnly(2013, 6, 20), false, false, false, (short)6, "June", (short)2013 },
                    { 172, 1, new DateOnly(2013, 6, 21), false, false, false, (short)6, "June", (short)2013 },
                    { 173, 1, new DateOnly(2013, 6, 22), false, true, true, (short)6, "June", (short)2013 },
                    { 174, 1, new DateOnly(2013, 6, 23), false, true, true, (short)6, "June", (short)2013 },
                    { 175, 1, new DateOnly(2013, 6, 24), false, false, false, (short)6, "June", (short)2013 },
                    { 176, 1, new DateOnly(2013, 6, 25), false, false, false, (short)6, "June", (short)2013 },
                    { 177, 1, new DateOnly(2013, 6, 26), false, false, false, (short)6, "June", (short)2013 },
                    { 178, 1, new DateOnly(2013, 6, 27), false, false, false, (short)6, "June", (short)2013 },
                    { 179, 1, new DateOnly(2013, 6, 28), false, false, false, (short)6, "June", (short)2013 },
                    { 180, 1, new DateOnly(2013, 6, 29), false, true, true, (short)6, "June", (short)2013 },
                    { 181, 1, new DateOnly(2013, 6, 30), false, true, true, (short)6, "June", (short)2013 },
                    { 182, 1, new DateOnly(2013, 7, 1), false, true, false, (short)7, "July", (short)2013 },
                    { 183, 1, new DateOnly(2013, 7, 2), false, true, false, (short)7, "July", (short)2013 },
                    { 184, 1, new DateOnly(2013, 7, 3), false, true, false, (short)7, "July", (short)2013 },
                    { 185, 1, new DateOnly(2013, 7, 4), false, true, false, (short)7, "July", (short)2013 },
                    { 186, 1, new DateOnly(2013, 7, 5), false, true, false, (short)7, "July", (short)2013 },
                    { 187, 1, new DateOnly(2013, 7, 6), false, true, true, (short)7, "July", (short)2013 },
                    { 188, 1, new DateOnly(2013, 7, 7), false, true, true, (short)7, "July", (short)2013 },
                    { 189, 1, new DateOnly(2013, 7, 8), false, true, false, (short)7, "July", (short)2013 },
                    { 190, 1, new DateOnly(2013, 7, 9), false, true, false, (short)7, "July", (short)2013 },
                    { 191, 1, new DateOnly(2013, 7, 10), false, true, false, (short)7, "July", (short)2013 },
                    { 192, 1, new DateOnly(2013, 7, 11), false, true, false, (short)7, "July", (short)2013 },
                    { 193, 1, new DateOnly(2013, 7, 12), false, true, false, (short)7, "July", (short)2013 },
                    { 194, 1, new DateOnly(2013, 7, 13), false, true, true, (short)7, "July", (short)2013 },
                    { 195, 1, new DateOnly(2013, 7, 14), false, true, true, (short)7, "July", (short)2013 },
                    { 196, 1, new DateOnly(2013, 7, 15), false, true, false, (short)7, "July", (short)2013 },
                    { 197, 1, new DateOnly(2013, 7, 16), false, true, false, (short)7, "July", (short)2013 },
                    { 198, 1, new DateOnly(2013, 7, 17), false, true, false, (short)7, "July", (short)2013 },
                    { 199, 1, new DateOnly(2013, 7, 18), false, true, false, (short)7, "July", (short)2013 },
                    { 200, 1, new DateOnly(2013, 7, 19), false, true, false, (short)7, "July", (short)2013 },
                    { 201, 1, new DateOnly(2013, 7, 20), false, true, true, (short)7, "July", (short)2013 },
                    { 202, 1, new DateOnly(2013, 7, 21), false, true, true, (short)7, "July", (short)2013 },
                    { 203, 1, new DateOnly(2013, 7, 22), false, true, false, (short)7, "July", (short)2013 },
                    { 204, 1, new DateOnly(2013, 7, 23), false, true, false, (short)7, "July", (short)2013 },
                    { 205, 1, new DateOnly(2013, 7, 24), false, true, false, (short)7, "July", (short)2013 },
                    { 206, 1, new DateOnly(2013, 7, 25), false, true, false, (short)7, "July", (short)2013 },
                    { 207, 1, new DateOnly(2013, 7, 26), false, true, false, (short)7, "July", (short)2013 },
                    { 208, 1, new DateOnly(2013, 7, 27), false, true, true, (short)7, "July", (short)2013 },
                    { 209, 1, new DateOnly(2013, 7, 28), false, true, true, (short)7, "July", (short)2013 },
                    { 210, 1, new DateOnly(2013, 7, 29), false, true, false, (short)7, "July", (short)2013 },
                    { 211, 1, new DateOnly(2013, 7, 30), false, true, false, (short)7, "July", (short)2013 },
                    { 212, 1, new DateOnly(2013, 7, 31), false, true, false, (short)7, "July", (short)2013 },
                    { 213, 1, new DateOnly(2013, 8, 1), false, false, false, (short)8, "August", (short)2013 },
                    { 214, 1, new DateOnly(2013, 8, 2), false, false, false, (short)8, "August", (short)2013 },
                    { 215, 1, new DateOnly(2013, 8, 3), false, true, true, (short)8, "August", (short)2013 },
                    { 216, 1, new DateOnly(2013, 8, 4), false, true, true, (short)8, "August", (short)2013 },
                    { 217, 1, new DateOnly(2013, 8, 5), false, false, false, (short)8, "August", (short)2013 },
                    { 218, 1, new DateOnly(2013, 8, 6), false, false, false, (short)8, "August", (short)2013 },
                    { 219, 1, new DateOnly(2013, 8, 7), false, false, false, (short)8, "August", (short)2013 },
                    { 220, 1, new DateOnly(2013, 8, 8), false, false, false, (short)8, "August", (short)2013 },
                    { 221, 1, new DateOnly(2013, 8, 9), false, false, false, (short)8, "August", (short)2013 },
                    { 222, 1, new DateOnly(2013, 8, 10), false, true, true, (short)8, "August", (short)2013 },
                    { 223, 1, new DateOnly(2013, 8, 11), false, true, true, (short)8, "August", (short)2013 },
                    { 224, 1, new DateOnly(2013, 8, 12), false, false, false, (short)8, "August", (short)2013 },
                    { 225, 1, new DateOnly(2013, 8, 13), false, false, false, (short)8, "August", (short)2013 },
                    { 226, 1, new DateOnly(2013, 8, 14), false, false, false, (short)8, "August", (short)2013 },
                    { 227, 1, new DateOnly(2013, 8, 15), false, false, false, (short)8, "August", (short)2013 },
                    { 228, 1, new DateOnly(2013, 8, 16), false, false, false, (short)8, "August", (short)2013 },
                    { 229, 1, new DateOnly(2013, 8, 17), false, true, true, (short)8, "August", (short)2013 },
                    { 230, 1, new DateOnly(2013, 8, 18), false, true, true, (short)8, "August", (short)2013 },
                    { 231, 1, new DateOnly(2013, 8, 19), false, false, false, (short)8, "August", (short)2013 },
                    { 232, 1, new DateOnly(2013, 8, 20), false, false, false, (short)8, "August", (short)2013 },
                    { 233, 1, new DateOnly(2013, 8, 21), false, false, false, (short)8, "August", (short)2013 },
                    { 234, 1, new DateOnly(2013, 8, 22), false, false, false, (short)8, "August", (short)2013 },
                    { 235, 1, new DateOnly(2013, 8, 23), false, false, false, (short)8, "August", (short)2013 },
                    { 236, 1, new DateOnly(2013, 8, 24), false, true, true, (short)8, "August", (short)2013 },
                    { 237, 1, new DateOnly(2013, 8, 25), false, true, true, (short)8, "August", (short)2013 },
                    { 238, 1, new DateOnly(2013, 8, 26), false, false, false, (short)8, "August", (short)2013 },
                    { 239, 1, new DateOnly(2013, 8, 27), false, false, false, (short)8, "August", (short)2013 },
                    { 240, 1, new DateOnly(2013, 8, 28), false, false, false, (short)8, "August", (short)2013 },
                    { 241, 1, new DateOnly(2013, 8, 29), false, false, false, (short)8, "August", (short)2013 },
                    { 242, 1, new DateOnly(2013, 8, 30), false, false, false, (short)8, "August", (short)2013 },
                    { 243, 1, new DateOnly(2013, 8, 31), false, true, true, (short)8, "August", (short)2013 },
                    { 244, 1, new DateOnly(2013, 9, 1), false, true, true, (short)9, "September", (short)2013 },
                    { 245, 1, new DateOnly(2013, 9, 2), false, false, false, (short)9, "September", (short)2013 },
                    { 246, 1, new DateOnly(2013, 9, 3), false, false, false, (short)9, "September", (short)2013 },
                    { 247, 1, new DateOnly(2013, 9, 4), false, false, false, (short)9, "September", (short)2013 },
                    { 248, 1, new DateOnly(2013, 9, 5), false, false, false, (short)9, "September", (short)2013 },
                    { 249, 1, new DateOnly(2013, 9, 6), false, false, false, (short)9, "September", (short)2013 },
                    { 250, 1, new DateOnly(2013, 9, 7), false, true, true, (short)9, "September", (short)2013 },
                    { 251, 1, new DateOnly(2013, 9, 8), false, true, true, (short)9, "September", (short)2013 },
                    { 252, 1, new DateOnly(2013, 9, 9), false, false, false, (short)9, "September", (short)2013 },
                    { 253, 1, new DateOnly(2013, 9, 10), false, false, false, (short)9, "September", (short)2013 },
                    { 254, 1, new DateOnly(2013, 9, 11), false, false, false, (short)9, "September", (short)2013 },
                    { 255, 1, new DateOnly(2013, 9, 12), false, false, false, (short)9, "September", (short)2013 },
                    { 256, 1, new DateOnly(2013, 9, 13), false, false, false, (short)9, "September", (short)2013 },
                    { 257, 1, new DateOnly(2013, 9, 14), false, true, true, (short)9, "September", (short)2013 },
                    { 258, 1, new DateOnly(2013, 9, 15), false, true, true, (short)9, "September", (short)2013 },
                    { 259, 1, new DateOnly(2013, 9, 16), false, false, false, (short)9, "September", (short)2013 },
                    { 260, 1, new DateOnly(2013, 9, 17), false, false, false, (short)9, "September", (short)2013 },
                    { 261, 1, new DateOnly(2013, 9, 18), false, false, false, (short)9, "September", (short)2013 },
                    { 262, 1, new DateOnly(2013, 9, 19), false, false, false, (short)9, "September", (short)2013 },
                    { 263, 1, new DateOnly(2013, 9, 20), false, false, false, (short)9, "September", (short)2013 },
                    { 264, 1, new DateOnly(2013, 9, 21), false, true, true, (short)9, "September", (short)2013 },
                    { 265, 1, new DateOnly(2013, 9, 22), false, true, true, (short)9, "September", (short)2013 },
                    { 266, 1, new DateOnly(2013, 9, 23), false, false, false, (short)9, "September", (short)2013 },
                    { 267, 1, new DateOnly(2013, 9, 24), false, false, false, (short)9, "September", (short)2013 },
                    { 268, 1, new DateOnly(2013, 9, 25), false, false, false, (short)9, "September", (short)2013 },
                    { 269, 1, new DateOnly(2013, 9, 26), false, false, false, (short)9, "September", (short)2013 },
                    { 270, 1, new DateOnly(2013, 9, 27), false, false, false, (short)9, "September", (short)2013 },
                    { 271, 1, new DateOnly(2013, 9, 28), false, true, true, (short)9, "September", (short)2013 },
                    { 272, 1, new DateOnly(2013, 9, 29), false, true, true, (short)9, "September", (short)2013 },
                    { 273, 1, new DateOnly(2013, 9, 30), false, false, false, (short)9, "September", (short)2013 },
                    { 274, 1, new DateOnly(2013, 10, 1), false, false, false, (short)10, "October", (short)2013 },
                    { 275, 1, new DateOnly(2013, 10, 2), false, false, false, (short)10, "October", (short)2013 },
                    { 276, 1, new DateOnly(2013, 10, 3), false, false, false, (short)10, "October", (short)2013 },
                    { 277, 1, new DateOnly(2013, 10, 4), false, false, false, (short)10, "October", (short)2013 },
                    { 278, 1, new DateOnly(2013, 10, 5), false, true, true, (short)10, "October", (short)2013 },
                    { 279, 1, new DateOnly(2013, 10, 6), false, true, true, (short)10, "October", (short)2013 },
                    { 280, 1, new DateOnly(2013, 10, 7), false, false, false, (short)10, "October", (short)2013 },
                    { 281, 1, new DateOnly(2013, 10, 8), false, false, false, (short)10, "October", (short)2013 },
                    { 282, 1, new DateOnly(2013, 10, 9), false, false, false, (short)10, "October", (short)2013 },
                    { 283, 1, new DateOnly(2013, 10, 10), false, false, false, (short)10, "October", (short)2013 },
                    { 284, 1, new DateOnly(2013, 10, 11), false, false, false, (short)10, "October", (short)2013 },
                    { 285, 1, new DateOnly(2013, 10, 12), false, true, true, (short)10, "October", (short)2013 },
                    { 286, 1, new DateOnly(2013, 10, 13), false, true, true, (short)10, "October", (short)2013 },
                    { 287, 1, new DateOnly(2013, 10, 14), false, false, false, (short)10, "October", (short)2013 },
                    { 288, 1, new DateOnly(2013, 10, 15), false, false, false, (short)10, "October", (short)2013 },
                    { 289, 1, new DateOnly(2013, 10, 16), false, false, false, (short)10, "October", (short)2013 },
                    { 290, 1, new DateOnly(2013, 10, 17), false, false, false, (short)10, "October", (short)2013 },
                    { 291, 1, new DateOnly(2013, 10, 18), false, false, false, (short)10, "October", (short)2013 },
                    { 292, 1, new DateOnly(2013, 10, 19), false, true, true, (short)10, "October", (short)2013 },
                    { 293, 1, new DateOnly(2013, 10, 20), false, true, true, (short)10, "October", (short)2013 },
                    { 294, 1, new DateOnly(2013, 10, 21), false, false, false, (short)10, "October", (short)2013 },
                    { 295, 1, new DateOnly(2013, 10, 22), false, false, false, (short)10, "October", (short)2013 },
                    { 296, 1, new DateOnly(2013, 10, 23), false, false, false, (short)10, "October", (short)2013 },
                    { 297, 1, new DateOnly(2013, 10, 24), false, false, false, (short)10, "October", (short)2013 },
                    { 298, 1, new DateOnly(2013, 10, 25), false, false, false, (short)10, "October", (short)2013 },
                    { 299, 1, new DateOnly(2013, 10, 26), false, true, true, (short)10, "October", (short)2013 },
                    { 300, 1, new DateOnly(2013, 10, 27), false, true, true, (short)10, "October", (short)2013 },
                    { 301, 1, new DateOnly(2013, 10, 28), false, false, false, (short)10, "October", (short)2013 },
                    { 302, 1, new DateOnly(2013, 10, 29), false, false, false, (short)10, "October", (short)2013 },
                    { 303, 1, new DateOnly(2013, 10, 30), false, false, false, (short)10, "October", (short)2013 },
                    { 304, 1, new DateOnly(2013, 10, 31), false, false, false, (short)10, "October", (short)2013 },
                    { 305, 1, new DateOnly(2013, 11, 1), false, false, false, (short)11, "November", (short)2013 },
                    { 306, 1, new DateOnly(2013, 11, 2), false, true, true, (short)11, "November", (short)2013 },
                    { 307, 1, new DateOnly(2013, 11, 3), false, true, true, (short)11, "November", (short)2013 },
                    { 308, 1, new DateOnly(2013, 11, 4), false, false, false, (short)11, "November", (short)2013 },
                    { 309, 1, new DateOnly(2013, 11, 5), false, false, false, (short)11, "November", (short)2013 },
                    { 310, 1, new DateOnly(2013, 11, 6), false, false, false, (short)11, "November", (short)2013 },
                    { 311, 1, new DateOnly(2013, 11, 7), false, false, false, (short)11, "November", (short)2013 },
                    { 312, 1, new DateOnly(2013, 11, 8), false, false, false, (short)11, "November", (short)2013 },
                    { 313, 1, new DateOnly(2013, 11, 9), false, true, true, (short)11, "November", (short)2013 },
                    { 314, 1, new DateOnly(2013, 11, 10), false, true, true, (short)11, "November", (short)2013 },
                    { 315, 1, new DateOnly(2013, 11, 11), false, false, false, (short)11, "November", (short)2013 },
                    { 316, 1, new DateOnly(2013, 11, 12), false, false, false, (short)11, "November", (short)2013 },
                    { 317, 1, new DateOnly(2013, 11, 13), false, false, false, (short)11, "November", (short)2013 },
                    { 318, 1, new DateOnly(2013, 11, 14), false, false, false, (short)11, "November", (short)2013 },
                    { 319, 1, new DateOnly(2013, 11, 15), false, false, false, (short)11, "November", (short)2013 },
                    { 320, 1, new DateOnly(2013, 11, 16), false, true, true, (short)11, "November", (short)2013 },
                    { 321, 1, new DateOnly(2013, 11, 17), false, true, true, (short)11, "November", (short)2013 },
                    { 322, 1, new DateOnly(2013, 11, 18), false, false, false, (short)11, "November", (short)2013 },
                    { 323, 1, new DateOnly(2013, 11, 19), false, false, false, (short)11, "November", (short)2013 },
                    { 324, 1, new DateOnly(2013, 11, 20), false, false, false, (short)11, "November", (short)2013 },
                    { 325, 1, new DateOnly(2013, 11, 21), false, false, false, (short)11, "November", (short)2013 },
                    { 326, 1, new DateOnly(2013, 11, 22), false, false, false, (short)11, "November", (short)2013 },
                    { 327, 1, new DateOnly(2013, 11, 23), false, true, true, (short)11, "November", (short)2013 },
                    { 328, 1, new DateOnly(2013, 11, 24), false, true, true, (short)11, "November", (short)2013 },
                    { 329, 1, new DateOnly(2013, 11, 25), false, false, false, (short)11, "November", (short)2013 },
                    { 330, 1, new DateOnly(2013, 11, 26), false, false, false, (short)11, "November", (short)2013 },
                    { 331, 1, new DateOnly(2013, 11, 27), false, false, false, (short)11, "November", (short)2013 },
                    { 332, 1, new DateOnly(2013, 11, 28), false, false, false, (short)11, "November", (short)2013 },
                    { 333, 1, new DateOnly(2013, 11, 29), false, false, false, (short)11, "November", (short)2013 },
                    { 334, 1, new DateOnly(2013, 11, 30), false, true, true, (short)11, "November", (short)2013 },
                    { 335, 1, new DateOnly(2013, 12, 1), false, true, true, (short)12, "December", (short)2013 },
                    { 336, 1, new DateOnly(2013, 12, 2), false, false, false, (short)12, "December", (short)2013 },
                    { 337, 1, new DateOnly(2013, 12, 3), false, false, false, (short)12, "December", (short)2013 },
                    { 338, 1, new DateOnly(2013, 12, 4), false, false, false, (short)12, "December", (short)2013 },
                    { 339, 1, new DateOnly(2013, 12, 5), false, false, false, (short)12, "December", (short)2013 },
                    { 340, 1, new DateOnly(2013, 12, 6), false, false, false, (short)12, "December", (short)2013 },
                    { 341, 1, new DateOnly(2013, 12, 7), false, true, true, (short)12, "December", (short)2013 },
                    { 342, 1, new DateOnly(2013, 12, 8), false, true, true, (short)12, "December", (short)2013 },
                    { 343, 1, new DateOnly(2013, 12, 9), false, false, false, (short)12, "December", (short)2013 },
                    { 344, 1, new DateOnly(2013, 12, 10), false, false, false, (short)12, "December", (short)2013 },
                    { 345, 1, new DateOnly(2013, 12, 11), false, false, false, (short)12, "December", (short)2013 },
                    { 346, 1, new DateOnly(2013, 12, 12), false, false, false, (short)12, "December", (short)2013 },
                    { 347, 1, new DateOnly(2013, 12, 13), false, false, false, (short)12, "December", (short)2013 },
                    { 348, 1, new DateOnly(2013, 12, 14), false, true, true, (short)12, "December", (short)2013 },
                    { 349, 1, new DateOnly(2013, 12, 15), false, true, true, (short)12, "December", (short)2013 },
                    { 350, 1, new DateOnly(2013, 12, 16), false, false, false, (short)12, "December", (short)2013 },
                    { 351, 1, new DateOnly(2013, 12, 17), false, false, false, (short)12, "December", (short)2013 },
                    { 352, 1, new DateOnly(2013, 12, 18), false, false, false, (short)12, "December", (short)2013 },
                    { 353, 1, new DateOnly(2013, 12, 19), false, false, false, (short)12, "December", (short)2013 },
                    { 354, 1, new DateOnly(2013, 12, 20), false, false, false, (short)12, "December", (short)2013 },
                    { 355, 1, new DateOnly(2013, 12, 21), false, true, true, (short)12, "December", (short)2013 },
                    { 356, 1, new DateOnly(2013, 12, 22), false, true, true, (short)12, "December", (short)2013 },
                    { 357, 1, new DateOnly(2013, 12, 23), false, false, false, (short)12, "December", (short)2013 },
                    { 358, 1, new DateOnly(2013, 12, 24), false, false, false, (short)12, "December", (short)2013 },
                    { 359, 1, new DateOnly(2013, 12, 25), false, false, false, (short)12, "December", (short)2013 },
                    { 360, 1, new DateOnly(2013, 12, 26), false, false, false, (short)12, "December", (short)2013 },
                    { 361, 1, new DateOnly(2013, 12, 27), false, false, false, (short)12, "December", (short)2013 },
                    { 362, 1, new DateOnly(2013, 12, 28), false, true, true, (short)12, "December", (short)2013 },
                    { 363, 1, new DateOnly(2013, 12, 29), false, true, true, (short)12, "December", (short)2013 },
                    { 364, 1, new DateOnly(2013, 12, 30), false, false, false, (short)12, "December", (short)2013 },
                    { 365, 1, new DateOnly(2013, 12, 31), false, false, false, (short)12, "December", (short)2013 }
                });

            migrationBuilder.InsertData(
                table: "TaxRule",
                columns: new[] { "Id", "Amount", "CityId", "FromTime", "ToTime" },
                values: new object[,]
                {
                    { 1, 8, 1, new TimeOnly(6, 0, 0), new TimeOnly(6, 29, 0) },
                    { 2, 13, 1, new TimeOnly(6, 30, 0), new TimeOnly(6, 59, 0) },
                    { 3, 18, 1, new TimeOnly(7, 0, 0), new TimeOnly(7, 59, 0) },
                    { 4, 13, 1, new TimeOnly(8, 0, 0), new TimeOnly(8, 29, 0) },
                    { 5, 8, 1, new TimeOnly(8, 30, 0), new TimeOnly(14, 59, 0) },
                    { 6, 13, 1, new TimeOnly(15, 0, 0), new TimeOnly(15, 29, 0) },
                    { 7, 18, 1, new TimeOnly(15, 30, 0), new TimeOnly(16, 59, 0) },
                    { 8, 13, 1, new TimeOnly(17, 0, 0), new TimeOnly(17, 59, 0) },
                    { 9, 8, 1, new TimeOnly(18, 0, 0), new TimeOnly(18, 29, 0) },
                    { 10, 0, 1, new TimeOnly(18, 30, 0), new TimeOnly(5, 59, 0) }
                });

            migrationBuilder.InsertData(
                table: "VehicleTrafficHistory",
                columns: new[] { "Id", "CityId", "DateTime", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2013, 1, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 2, 1, new DateTime(2013, 1, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 3, 1, new DateTime(2013, 1, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 4, 1, new DateTime(2013, 2, 7, 6, 23, 27, 0, DateTimeKind.Unspecified), 7 },
                    { 5, 1, new DateTime(2013, 2, 7, 15, 27, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 6, 1, new DateTime(2013, 2, 8, 6, 27, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 7, 1, new DateTime(2013, 2, 8, 6, 20, 27, 0, DateTimeKind.Unspecified), 7 },
                    { 8, 1, new DateTime(2013, 2, 8, 14, 35, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 9, 1, new DateTime(2013, 2, 8, 15, 29, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 10, 1, new DateTime(2013, 2, 8, 15, 47, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 11, 1, new DateTime(2013, 2, 8, 16, 1, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 12, 1, new DateTime(2013, 2, 8, 16, 48, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 13, 1, new DateTime(2013, 2, 8, 17, 49, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 14, 1, new DateTime(2013, 2, 8, 18, 29, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 15, 1, new DateTime(2013, 2, 8, 18, 35, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 16, 1, new DateTime(2013, 3, 26, 14, 25, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 17, 1, new DateTime(2013, 3, 28, 14, 7, 27, 0, DateTimeKind.Unspecified), 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calender_CityId",
                table: "Calender",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRule_CityId",
                table: "TaxRule",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTrafficHistory_CityId",
                table: "VehicleTrafficHistory",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTrafficHistory_VehicleTypeId",
                table: "VehicleTrafficHistory",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calender");

            migrationBuilder.DropTable(
                name: "TaxRule");

            migrationBuilder.DropTable(
                name: "VehicleTrafficHistory");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
