using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class AddImageUrlToClassroomAndSeedImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Classrooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("632bc679-3cc2-45b7-971b-6a92105321de"),
                column: "ImageUrl",
                value: "https://pbs.twimg.com/profile_images/557241923597914112/wuYMY-Sj_400x400.png");

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"),
                column: "ImageUrl",
                value: "https://www.abnewswire.com/uploads/1692132999.jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Classrooms");
        }
    }
}
