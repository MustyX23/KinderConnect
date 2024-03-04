using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedTeachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Teachers");

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "FirstName", "Gender", "ImageUrl", "LastName", "QualificationId", "TeacherUserId" },
                values: new object[] { new Guid("43849457-8db7-4557-a1ed-78fa776b4274"), 56, "Lybomir", "male", "https://i.guim.co.uk/img/media/b897974dce4559ebe02af27e10c475068ead46a8/0_0_4000_2400/master/4000.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=a53a3c7714a215af7051daea5b14971c", "Popov", 1, new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765") });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "FirstName", "Gender", "ImageUrl", "LastName", "QualificationId", "TeacherUserId" },
                values: new object[] { new Guid("a801401d-65f3-4862-9e81-97ce782967a5"), 50, "Mustafa", "male", "https://img.freepik.com/premium-photo/old-male-teacher-portrait-closeup-face-professor-teacher-blackboard-isolated_265223-53892.jpg", "Buhov", 1, new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("43849457-8db7-4557-a1ed-78fa776b4274"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("a801401d-65f3-4862-9e81-97ce782967a5"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Teachers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
