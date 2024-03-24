using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedClassrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("632bc679-3cc2-45b7-971b-6a92105321de"), "Little Explorers" });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"), "Doodle Den" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("632bc679-3cc2-45b7-971b-6a92105321de"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"));
        }
    }
}
