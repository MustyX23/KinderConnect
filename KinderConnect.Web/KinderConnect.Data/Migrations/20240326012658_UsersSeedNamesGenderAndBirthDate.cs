using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class UsersSeedNamesGenderAndBirthDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765"),
                columns: new[] { "FirstName", "LastName", "DateOfBirth", "Gender" },
                values: new object[] { "Lyubomir", "Popov", new DateTime(1972, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "male" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a"),
                columns: new[] { "FirstName", "LastName", "DateOfBirth", "Gender" },
                values: new object[] { "Mother", "Ivanova", new DateTime(1992, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "female" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64"),
                columns: new[] { "FirstName", "LastName", "DateOfBirth", "Gender" },
                values: new object[] { "Father", "Mitev", new DateTime(1990, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "male" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f"),
                columns: new[] { "FirstName", "LastName", "DateOfBirth", "Gender" },
                values: new object[] { "Mustafa", "Buhov", new DateTime(1971, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "male" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765"),
                columns: new[] { "FirstName", "LastName", "DateOfBirth", "Gender" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a"),
                columns: new[] { "FirstName", "LastName", "DateOfBirth", "Gender" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64"),
                columns: new[] { "FirstName", "LastName", "DateOfBirth", "Gender" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f"),
                columns: new[] { "FirstName", "LastName", "DateOfBirth", "Gender" },
                values: new object[] { null, null, null, null });
        }
    }
}

