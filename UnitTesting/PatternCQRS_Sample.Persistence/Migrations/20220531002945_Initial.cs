using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatternCQRS_Sample.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreationDate", "Description", "Price", "PublishDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0af879bf-5642-45a3-b79c-4d7ab2677436"), new DateTime(2022, 5, 30, 19, 29, 45, 359, DateTimeKind.Local).AddTicks(8653), "C# for beginners", 150m, new DateTime(2022, 7, 30, 19, 29, 45, 364, DateTimeKind.Local).AddTicks(7117), "C# Basic" },
                    { new Guid("3360d2ec-f4e9-4407-8ab3-c95c43ec424e"), new DateTime(2022, 5, 30, 19, 29, 45, 366, DateTimeKind.Local).AddTicks(1886), "Go for beginners", 150m, new DateTime(2022, 8, 30, 19, 29, 45, 366, DateTimeKind.Local).AddTicks(1915), "Go Basic" },
                    { new Guid("a64e900c-e9ad-41ef-978e-f235fdc687c2"), new DateTime(2022, 5, 30, 19, 29, 45, 366, DateTimeKind.Local).AddTicks(2041), "Android for beginners", 150m, new DateTime(2022, 9, 30, 19, 29, 45, 366, DateTimeKind.Local).AddTicks(2047), "Android Basic" },
                    { new Guid("b4b4b983-fc65-45e8-87ac-56083ae5d57f"), new DateTime(2022, 5, 30, 19, 29, 45, 366, DateTimeKind.Local).AddTicks(2072), "iOS for beginners", 150m, new DateTime(2022, 10, 30, 19, 29, 45, 366, DateTimeKind.Local).AddTicks(2076), "iOS Basic" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
