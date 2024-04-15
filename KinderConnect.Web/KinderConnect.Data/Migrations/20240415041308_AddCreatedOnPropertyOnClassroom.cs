using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class AddCreatedOnPropertyOnClassroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("632bc679-3cc2-45b7-971b-6a92105321de"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 20, 14, 15, 12, 28, DateTimeKind.Local).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 20, 15, 20, 13, 32, DateTimeKind.Local).AddTicks(3780));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Classrooms");
        }
    }
}
