using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedActivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { 1, "Drawing", "We learn to draw circles and triangles :)" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { 2, "Writing", "We learn to write the Alphabet :)" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { 3, "Play", "We play a lot of football and volleyball :)" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
