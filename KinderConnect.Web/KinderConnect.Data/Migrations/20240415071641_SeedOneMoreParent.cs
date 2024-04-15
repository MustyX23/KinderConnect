using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedOneMoreParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("73690111-8cdc-4e37-91c2-143c674f324f"), 0, "07c23bcc-5c0f-40ad-8586-9c3735a742d7", new DateTime(2000, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "parent3@gmail.com", false, "Emily", "female", "Cankova", false, null, "PARENT3@GMAIL.COM", "PARENT3", "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==", null, false, "A2B3C4D5E6F7G8H9I0J1K2L3M4N5O6P", false, "Parent3" });            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("73690111-8cdc-4e37-91c2-143c674f324f"));
        }
    }
}
