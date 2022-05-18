using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectoef.Migrations
{
    public partial class InitialDatav2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("1425a7b8-1345-49ad-9755-5095f34f4a00"),
                column: "CreationDate",
                value: new DateTime(2022, 5, 17, 19, 2, 17, 519, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("1425a7b8-1345-49ad-9755-5095f34f4a10"),
                column: "CreationDate",
                value: new DateTime(2022, 5, 17, 19, 2, 17, 519, DateTimeKind.Local).AddTicks(9010));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("1425a7b8-1345-49ad-9755-5095f34f4a00"),
                column: "CreationDate",
                value: new DateTime(2022, 5, 17, 18, 59, 20, 40, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("1425a7b8-1345-49ad-9755-5095f34f4a10"),
                column: "CreationDate",
                value: new DateTime(2022, 5, 17, 18, 59, 20, 40, DateTimeKind.Local).AddTicks(9390));
        }
    }
}
