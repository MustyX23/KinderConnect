using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class RemoveIsPresentFromChildEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPresent",
                table: "Children");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.AddColumn<bool>(
                name: "IsPresent",
                table: "Children",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
