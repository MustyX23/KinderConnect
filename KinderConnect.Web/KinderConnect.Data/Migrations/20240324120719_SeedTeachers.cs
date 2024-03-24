using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedTeachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765"),
                column: "ConcurrencyStamp",
                value: "706fb8ac-91c0-4575-850e-633088c49ee6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a"),
                column: "ConcurrencyStamp",
                value: "5ba44547-1846-472d-a871-b15d1779a76e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64"),
                column: "ConcurrencyStamp",
                value: "b1b15f2f-1a28-45dd-9cf6-61e177522d68");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f"),
                column: "ConcurrencyStamp",
                value: "93ef9558-3332-4bc1-b434-0914db0b64d5");

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "FirstName", "Gender", "ImageUrl", "LastName", "QualificationId", "TeacherUserId" },
                values: new object[,]
                {
                    { new Guid("30870b45-707e-4347-855e-db2757ad22b8"), 50, "Mustafa", "male", "https://img.freepik.com/premium-photo/old-male-teacher-portrait-closeup-face-professor-teacher-blackboard-isolated_265223-53892.jpg", "Buhov", 1, new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f") },
                    { new Guid("601edbb4-958e-4b5b-b602-107670cafd6e"), 56, "Lybomir", "male", "https://i.guim.co.uk/img/media/b897974dce4559ebe02af27e10c475068ead46a8/0_0_4000_2400/master/4000.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=a53a3c7714a215af7051daea5b14971c", "Popov", 1, new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("30870b45-707e-4347-855e-db2757ad22b8"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("601edbb4-958e-4b5b-b602-107670cafd6e"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765"),
                column: "ConcurrencyStamp",
                value: "de322230-6215-45f5-a976-48e32269dc31");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a"),
                column: "ConcurrencyStamp",
                value: "9c3e110a-f818-4fc2-965d-d6dd47767747");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64"),
                column: "ConcurrencyStamp",
                value: "794155b8-ff8f-4dad-b357-4b54ff8e8cf2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f"),
                column: "ConcurrencyStamp",
                value: "29cca7f6-3764-42ea-ae37-2d39e469dd09");
        }
    }
}
