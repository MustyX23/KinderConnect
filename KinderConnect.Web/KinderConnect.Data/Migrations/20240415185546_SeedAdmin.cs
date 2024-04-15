using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("30f0662a-29c5-48df-8b57-9c61c671e0fb"), 0, "99fa0334-8b95-44f7-b463-1171d7e48b46", new DateTime(1972, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", false, "Admin", "male", "Admin", false, null, "ADMIN@ADMIN.com", "admin", "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==", null, false, "A1B2C3D4E5F6G7H8I9J0K1L2M3N4O5P\r\n\r\n\r\n\r\n\r\n", false, "Admin" });          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30f0662a-29c5-48df-8b57-9c61c671e0fb"));
        }
    }
}
