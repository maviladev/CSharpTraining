using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectoef.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("1425a7b8-1345-49ad-9755-5095f34f4a02"), "Activities to do", "Personal Activities", 50 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("1425a7b8-1345-49ad-9755-5095f34f4aaf"), "Activities to do", "Pending Activities", 20 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "PriorityTask", "Title" },
                values: new object[] { new Guid("1425a7b8-1345-49ad-9755-5095f34f4a00"), new Guid("1425a7b8-1345-49ad-9755-5095f34f4a02"), new DateTime(2022, 5, 17, 18, 59, 20, 40, DateTimeKind.Local).AddTicks(9460), "Task 2 Desc", 0, "Task 2" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "PriorityTask", "Title" },
                values: new object[] { new Guid("1425a7b8-1345-49ad-9755-5095f34f4a10"), new Guid("1425a7b8-1345-49ad-9755-5095f34f4aaf"), new DateTime(2022, 5, 17, 18, 59, 20, 40, DateTimeKind.Local).AddTicks(9390), "Task 1 Desc", 1, "Task 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("1425a7b8-1345-49ad-9755-5095f34f4a00"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("1425a7b8-1345-49ad-9755-5095f34f4a10"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("1425a7b8-1345-49ad-9755-5095f34f4a02"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("1425a7b8-1345-49ad-9755-5095f34f4aaf"));
        }
    }
}
