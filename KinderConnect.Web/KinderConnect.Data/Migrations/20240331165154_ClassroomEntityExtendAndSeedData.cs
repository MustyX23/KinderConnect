using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class ClassroomEntityExtendAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "Classrooms",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaximumAge",
                table: "Classrooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumAge",
                table: "Classrooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalSeats",
                table: "Classrooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TutionFee",
                table: "Classrooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);           
          
            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("632bc679-3cc2-45b7-971b-6a92105321de"),
                columns: new[] { "Information", "MaximumAge", "TotalSeats", "TutionFee" },
                values: new object[] { "Nature walks.Sensory play with natural materials.Learning about different animals and habitats.Creative storytelling sessions", 3, 25, 100m });

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"),
                columns: new[] { "Information", "MaximumAge", "MinimumAge", "TotalSeats", "TutionFee" },
                values: new object[] { "Art studio with easels and drawing tables.Variety of art supplies and materials.Display area for showcasing student artwork.Cozy reading corner for inspiration", 6, 3, 25, 150m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Information",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "MaximumAge",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "MinimumAge",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "TotalSeats",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "TutionFee",
                table: "Classrooms");
        }
    }
}
