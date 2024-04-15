using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedMoreTeachersUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("31c9d7c4-5b0e-46b5-a6db-0ed766d6b563"), 0, "1b6bbafc-e1e1-4bca-91cb-36f29c303502", new DateTime(2001, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "mrssavka@gmail.com", false, "Savka", "female", "Ivanovich", false, null, "MRSSAVKA@GMAIL.COM", "MRS.SAVKA", "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==", null, false, "J9K8L7M6N5O4P3Q2R1S0T9U8V7W6X5Y", false, "Mrs.Savka" },
                    { new Guid("37ed60d0-efe7-4d5a-89c1-8169c7ae008f"), 0, "d07244b0-5114-4d7a-899e-75a23d555041", new DateTime(1999, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "mrsava@gmail.com", false, "Ava", "female", "Alita", false, null, "MRSAVA@GMAIL.COM", "MRS.AVA", "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==", null, false, "H2G3F4E5D6C7B8A9Z0Y1X2W3V4U5T6S", false, "Mrs.Ava" },
                    { new Guid("47d28c7b-a4fc-4617-bbbd-60b05a0bfd45"), 0, "e3a94711-6c6c-4a92-8031-7ee82410a322", new DateTime(2000, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "mrsamelia@gmail.com", false, "Amelia", "female", "Avita", false, null, "MRSAMELIA@GMAIL.COM", "MRS.AMELIA", "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==", null, false, "Z9Y8X7W6V5U4T3S2R1Q0P9O8N7M6L5K", false, "Mrs.Amelia" },
                    { new Guid("ffa6f8eb-02f7-4246-aa59-f7ce6d2be5ff"), 0, "0835fcc4-1495-4b70-bdda-8a259a865f92", new DateTime(1998, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mrsaurora@gmail.com", false, "Aurora", "female", "Gastambide", false, null, "MRSAURORA@GMAIL.COM", "MRS.AURORA", "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==", null, false, "M1N2O3P4Q5R6S7T8U9V0A1B2C3D4E5F", false, "Mrs.Aurora" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
