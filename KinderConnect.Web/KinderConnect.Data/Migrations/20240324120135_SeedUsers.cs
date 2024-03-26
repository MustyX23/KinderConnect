using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765"), 0, "de322230-6215-45f5-a976-48e32269dc31", "mrpopov@gmail.com", false, false, null, "MRPOPOV@gmail.com", "MR.POPOV", "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==", null, false, "BBFE1B04-2741-4440-9334-595CB40A9F64", false, "Mr.Popov" },
                    { new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a"), 0, "9c3e110a-f818-4fc2-965d-d6dd47767747", "parent2@gmail.com", false, false, null, "PARENT2@GMAIL.COM", "PARENT2", "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==", null, false, "WYSXJ4KMDZB57DCK45U2RKHNRECRLM34", false, "Parent2" },
                    { new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64"), 0, "794155b8-ff8f-4dad-b357-4b54ff8e8cf2", "parent1@gmail.com", false, false, null, "PARENT1@GMAIL.COM", "PARENT1", "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==", null, false, "N4PWLMS5WBIRFFWJFWX64CLD4UCMMNSB", false, "Parent1" },
                    { new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f"), 0, "29cca7f6-3764-42ea-ae37-2d39e469dd09", "mrbuhov@gmail.com", false, false, null, "MRBUHOV@GMAIL.COM", "MR.BUHOV", "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==", null, false, "BBTUYUTJE4SXLOGCMKQHVIEWGSUEOZMD", false, "Mr.Buhov" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f"));
        }
    }
}
